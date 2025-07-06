-- trigger and IF
-- atualiza  o estoque se tiver sido usado algum item
go
create trigger atualizaEstoque
on agendamentos  
after insert
as
begin
	if exists (select 1 from inserted where id_item is not null)
	begin
		update e
        set e.quantidade = e.quantidade - i.quantidade_item
        from estoque e
        join inserted i on e.id = i.id_item
	end
end
go

-- while
--verifica cada item no estoque e avisa se tiver algum com menos de 10 quantidades
--da um break se alguem medicamento estiver com 5 ou menos em quantidade 
--continue se não tiver item com o proximo id, caso de tabela mal organizada
declare @id_item int = 1;
declare @id_item_max int;
declare @nome_item varchar(100);
select @id_item_max = MAX(id) from estoque
	
while @id_item <= @id_item_max
begin
	declare @estoque int;
	declare @estoque_minimo int = 10;

	select @estoque = quantidade, @nome_item = nome from estoque where id = @id_item;

	-- se o item não existir, caso de id não sequencial, pula
	if @estoque is NULL
		begin
			set @id_item = @id_item + 1;
			continue;
		end

	if exists (select 1 from estoque where id = @id_item and id_categoria = 4 and quantidade < @estoque_minimo/2 ) 
		begin
			print 'Medicamento controlado com estoque crítico: '+ @nome_item + ' (ID: ' + cast(@id_item as varchar) + ')';
			break;
		end
	
	if @estoque <= @estoque_minimo
		begin
			print 'produto com falta de estoque: ' + @nome_item + ' (ID: ' + cast(@id_item as varchar) + ')';
		end

	set @id_item = @id_item + 1;

end



--função
--conta o lucro entre datas
go
CREATE OR ALTER FUNCTION dbo.total_vendas
(
    @data_inicio DATE,
    @data_fim DATE
)
RETURNS DECIMAL(12,2)
AS
BEGIN
    DECLARE @total DECIMAL(12,2);
    
    IF @data_inicio > @data_fim
    BEGIN
        RETURN -1; 
    END
    
    SELECT @total = ISNULL(SUM(ISNULL(e.preco_unitario, 0) * ISNULL(a.quantidade_item, 0) 
                            + ISNULL(o.custo, 0)), 0)
    FROM agendamentos a
    LEFT JOIN operacao o ON a.id_operacao = o.id
    LEFT JOIN estoque e ON a.id_item = e.id
	WHERE CAST(a.horario_marcado AS DATE) BETWEEN @data_inicio AND @data_fim;

    RETURN @total;
END;

go

--uso da função
--mostra o lucro de cada mes e total do ano da variavel @ano apartir da variavel @mes

DECLARE @ano INT = 2024;
DECLARE @mes INT = 1;

-- Criar tabela temporária para armazenar os resultados mensais
CREATE TABLE #LucrosMensais (
    mes VARCHAR(20),
    total_vendas DECIMAL(12,2)
);

-- Loop através de cada mês do ano
WHILE @mes <= 12
BEGIN
    -- Calcular o primeiro e último dia do mês
    DECLARE @primeiro_dia DATE = DATEFROMPARTS(@ano, @mes, 1);
    DECLARE @ultimo_dia DATE = EOMONTH(@primeiro_dia);
    
    -- Nome do mês para exibição
    DECLARE @nome_mes VARCHAR(20) = DATENAME(MONTH, @primeiro_dia);
    
    -- Inserir na tabela temporária o resultado da função para o mês
    INSERT INTO #LucrosMensais (mes, total_vendas)
    SELECT @nome_mes, dbo.total_vendas(@primeiro_dia, @ultimo_dia);
    
    -- Incrementar para o próximo mês
    SET @mes = @mes + 1;
END

-- Exibir os resultados
SELECT 
    mes AS 'Mês',
    total_vendas AS 'Total de Vendas'
FROM #LucrosMensais
ORDER BY MONTH(CONVERT(DATETIME, '01 ' + mes + ' 2024'));

-- Incluir total anual
SELECT 'TOTAL' AS 'Mês', SUM(total_vendas) AS 'Total de Vendas'
FROM #LucrosMensais;

-- Limpar tabela temporária
DROP TABLE #LucrosMensais;



--PROCEDURE
--calcula o lucro de cada mes de um ano informado
GO
CREATE OR ALTER PROCEDURE dbo.calcular_lucros_anuais
    @ano INT
AS
BEGIN
    SET NOCOUNT ON;
    DECLARE @mes INT = 1;
    DECLARE @primeiro_dia DATE;
    DECLARE @ultimo_dia DATE;
    DECLARE @nome_mes VARCHAR(20);
    DECLARE @total_mes DECIMAL(12,2);
    DECLARE @total_anual DECIMAL(12,2) = 0;

    -- Tabela temporária
    CREATE TABLE #Lucros (
        mes VARCHAR(20),
        total_vendas DECIMAL(12,2)
    );

    BEGIN TRY
        BEGIN TRANSACTION;

        WHILE @mes <= 12
        BEGIN
            SET @primeiro_dia = DATEFROMPARTS(@ano, @mes, 1);
            SET @ultimo_dia = EOMONTH(@primeiro_dia);
            SET @nome_mes = DATENAME(MONTH, @primeiro_dia);

            SELECT @total_mes = ISNULL(SUM(ISNULL(e.preco_unitario, 0) * ISNULL(a.quantidade_item, 0) 
                                        + ISNULL(o.custo, 0)), 0)
            FROM agendamentos a
            LEFT JOIN operacao o ON a.id_operacao = o.id
            LEFT JOIN estoque e ON a.id_item = e.id
            WHERE CAST(a.horario_marcado AS DATE) BETWEEN @primeiro_dia AND @ultimo_dia;

            INSERT INTO #Lucros (mes, total_vendas)
            VALUES (@nome_mes, @total_mes);

            SET @total_anual += @total_mes;
            SET @mes += 1;
        END

        -- Total anual
        INSERT INTO #Lucros (mes, total_vendas)
        VALUES ('TOTAL', @total_anual);

        COMMIT;

        -- Resultado final
        SELECT * FROM #Lucros;

    END TRY
    BEGIN CATCH
        ROLLBACK;
        THROW;
    END CATCH
END
GO

EXEC dbo.calcular_lucros_anuais @ano = 2025;

--CURSOR
--Produtos com pouco estoque mas alto valor recebem um desconto de 20%
--Produtos nunca vendidos recebem um desconto de 30%
--Produtos que já foram vendido, mas muito pouco são apenas identificados através de uma mensagem

DECLARE @id INT, @nome NVARCHAR(100), @quantidade INT, @preco Decimal(10,2);
DECLARE cursor_estoque CURSOR FOR
SELECT id, nome, quantidade, preco_unitario from estoque;

OPEN cursor_estoque;

FETCH NEXT FROM cursor_estoque INTO @id, @nome, @quantidade, @preco;

WHILE @@FETCH_STATUS = 0
BEGIN
	DECLARE @vendas INT;

	SELECT @vendas = COUNT(*)
	FROM agendamentos
	WHERE id_item = @id;

	IF @quantidade < 5 AND @preco > 100
	BEGIN
		UPDATE estoque
		SET preco_unitario = preco_unitario * 0.8
		WHERE id = @id;
	END
	ELSE IF @vendas = 0
	BEGIN
		UPDATE estoque
		SET preco_unitario = preco_unitario * 0.7
		WHERE id = @id;
	END
	ELSE IF @vendas IS NOT NULL AND @vendas > 0
	BEGIN
		PRINT 'Produto com poucas vendas: ' + @nome;
	END

	FETCH NEXT FROM cursor_estoque INTO @id, @nome, @quantidade, @preco;
END
CLOSE cursor_estoque;
DEALLOCATE cursor_estoque;


--MINERAÇÃO
--verifica qual raça faz mais check ups e exames de sangue em relação a todas as operações
--ESTRATEGIA: dar desconto em operações basicas para bulldogs
SELECT 
    raca_animal,
    COUNT(CASE WHEN operacao IN ('check up', 'exame de sangue') THEN 1 END) * 100.0 / COUNT(*) AS percentual_basicas
FROM 
    agendamento_detalhado
GROUP BY 
    raca_animal
ORDER BY 
    percentual_basicas DESC;
