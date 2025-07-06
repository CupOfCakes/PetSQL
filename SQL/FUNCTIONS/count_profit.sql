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
