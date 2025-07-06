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
