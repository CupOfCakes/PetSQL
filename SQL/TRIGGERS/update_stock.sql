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
