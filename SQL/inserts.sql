-- INSERTS
--insert cliente
INSERT INTO cliente (nome, endereco)
VALUES ('João', 'Rua Americas, 123');

INSERT INTO cliente (nome, endereco)
VALUES ('Maria', 'Av. Brasil, 456');

INSERT INTO cliente (nome, endereco)
VALUES ('Carlos', 'Rua do Chico, 789');

-- Insert telefone
INSERT INTO telefone VALUES (1, '11987654321');
INSERT INTO telefone VALUES (2, '11976543210');
INSERT INTO telefone VALUES (3, '11965432109');

-- Insert especie
INSERT INTO especie VALUES ('cachorro');
INSERT INTO especie VALUES ('gato');

-- Insert raca
INSERT INTO raca VALUES (1, 'pastor alemão');
INSERT INTO raca VALUES (1, 'poodle');
INSERT INTO raca VALUES (2, 'siamês');
INSERT INTO raca VALUES (2, 'ragdoll');

--insert animal
INSERT INTO animal (id_cliente, nome, idade, id_raca)
VALUES (1, 'Rex', 3, 1);

INSERT INTO animal (id_cliente, nome, idade, id_raca)
VALUES (2, 'Bela', 2, 3);

INSERT INTO animal (id_cliente, nome, idade, id_raca)
VALUES (3, 'Nina', 4, 2);

INSERT INTO animal (id_cliente, nome, idade, id_raca)
VALUES (3, 'Miau', 4, 4);


-- Insert cargos
INSERT INTO cargos VALUES ('veterinário');
INSERT INTO cargos VALUES ('atendente');
INSERT INTO cargos VALUES ('veterinário-cirurgião');
INSERT INTO cargos VALUES ('zelador');

--insert funcionario
INSERT INTO funcionario (nome, salario, id_cargo)
VALUES ('Pedro', '5000.00', 1);

INSERT INTO funcionario (nome, salario, id_cargo)
VALUES ('Ana', '3000.00', 2);

INSERT INTO funcionario (nome, salario, id_cargo)
VALUES ('Lucas', '5500.00', 3);

INSERT INTO funcionario (nome, salario, id_cargo)
VALUES ('Marcos', '5500.00', 4);

INSERT INTO funcionario (nome, salario, id_cargo)
VALUES ('Maria', '5500.00', 1);

--insert operacao
INSERT INTO operacao (exame, custo, duracao)
VALUES ('check up', 150.00, 30);

INSERT INTO operacao (exame, custo, duracao)
VALUES ('exame de sangue', 120.00, 40);

INSERT INTO operacao (exame, custo, duracao)
VALUES ('cirurgia de castração', 800.00, 120);


--insert salas
INSERT INTO salas (numero_sala, funcionalidade)
VALUES (1, 'consultorio veterinario');

INSERT INTO salas (numero_sala, funcionalidade)
VALUES (2, 'Sala de Exames');

INSERT INTO salas (numero_sala, funcionalidade)
VALUES (3, 'Sala de Cirurgia');

-- Insert categoria_estoque
INSERT INTO categoria_estoque VALUES ('vacina');
INSERT INTO categoria_estoque VALUES ('ração');
INSERT INTO categoria_estoque VALUES ('medicamento');
INSERT INTO categoria_estoque VALUES ('medicamento controlado')

-- Insert estoque
INSERT INTO estoque (nome, descricao, quantidade, preco_unitario, data_validade, fornecedor, data_entrega, id_categoria)
VALUES ('Vacina Antirrábica', 'Vacina para prevenção de raiva', 50, 45.00, '2025-12-31', 'Fornecedor Alpha', '2024-01-01', 1);

INSERT INTO estoque (nome, descricao, quantidade, preco_unitario, data_validade, fornecedor, data_entrega, id_categoria)
VALUES ('Ração Premium', 'Ração para cães de pequeno porte', 30, 120.00, '2024-09-30', 'Fornecedor Beta', '2024-02-15', 2);

INSERT INTO estoque (nome, descricao, quantidade, preco_unitario, data_validade, fornecedor, data_entrega, id_categoria)
VALUES ('Antipulgas', 'Remédio contra pulgas para cães', 100, 35.00, '2024-06-01', 'Fornecedor Cachorro Mania', '2024-03-10', 3);

INSERT INTO estoque (nome, descricao, quantidade, preco_unitario, data_validade, fornecedor, data_entrega, id_categoria)
VALUES ('Anestesia', 'Para animais de até 10 Kg', 50, 195.00, '2025-03-01', 'Fornecedor Alpha', '2024-10-18', 1);

INSERT INTO estoque 
VALUES ('Gabapentina', 'uso em caso de dores crônicas e ansiedade de gatos', 1, 3, '2025-10-12', 'Fornecedor Gama', '2025-03-21', 4);


-- Insert agendamentos
INSERT INTO agendamentos (horario_marcado, id_sala, id_animal, id_veterinario, id_operacao)
VALUES ('2024-20-10 14:00', 1, 1, 1, 1);

INSERT INTO agendamentos (horario_marcado, id_sala, id_animal, id_veterinario, id_operacao)
VALUES ('2024-21-10 10:30', 1, 2, 1, 1);

INSERT INTO agendamentos (horario_marcado, id_sala, id_animal, id_veterinario, id_operacao, id_item, quantidade_item)
VALUES ('2024-22-10 16:00', 3, 3, 3, 3, 4, 1);

INSERT INTO agendamentos (horario_marcado, id_sala, id_animal, id_veterinario, id_operacao, id_item, quantidade_item)
VALUES ('2024-22-10 17:00', 3, 3, 3, 1, 2, 1);

INSERT INTO agendamentos (horario_marcado, id_sala, id_animal, id_veterinario, id_operacao)
VALUES ('2024-22-10 17:00', 1, 1, 3, 2);
