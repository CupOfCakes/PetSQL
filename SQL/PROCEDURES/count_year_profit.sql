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
