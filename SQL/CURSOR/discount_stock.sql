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
