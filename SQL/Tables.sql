-- criação das tabelas
create table cliente(
id int identity(1,1) primary key not null,
nome varchar(50) not null,
endereco varchar(100) not null
)

-- depende de cliente
create table telefone(
id int primary key identity(1,1) not null,
id_cliente int not null references cliente,
telefone varchar(20) not null)

create table especie(
id int primary key identity(1,1) not null,
especie varchar(max) not null)

-- depende de especie
create table raca(
id int primary key identity(1,1) not null,
id_especie int not null references especie,
raca varchar(max) not null)

--depende de cliente e raca
create table animal(
id int identity(1,1) primary key not null,
id_cliente int not null references cliente,
nome varchar(50) not null,
idade int not null,
id_raca int not null references raca
)

create table cargos(
id int primary key identity(1,1) not null,
descricao varchar(max) not null)

-- depende de cargos
create table funcionario(
id int identity(1,1) primary key not null,
id_cargo int not null references cargos,
nome varchar(50) not null,
salario varchar(15) not null
)

create table operacao(
id int identity(1,1) primary key not null,
exame varchar(100) not null,
custo decimal(10, 2) not null,
duracao int not null,
)

create table salas(
id int identity(1,1) primary key not null,
numero_sala int not null,
funcionalidade varchar(100) not null,
)

create table categoria_estoque(
id int primary key identity(1,1) not null,
categoria varchar(max) not null)

--depende de categoria_estoque
CREATE TABLE estoque (
id int identity(1,1) primary key not null, 
nome varchar(100) not null, 
descricao varchar(200), 
quantidade int NOT NULL, 
preco_unitario decimal(10, 2) NOT NULL, 
data_validade date not null, 
fornecedor varchar(100) not null, 
data_entrega date NOT NULL, 
id_categoria int not null references categoria_estoque
)

-- depende de salas, animal, funcionario, operacao, estoque
create table agendamentos(
id int identity(1,1) primary key not null,
horario_marcado datetime not null,
id_sala int not null references salas,
id_animal int not null references animal,
id_veterinario int not null references funcionario,
id_operacao int not null references operacao,
id_item int references estoque,
quantidade_item int
)

--indice
-- cria a tabela de historico_checkups e o index idx_historico_checkups_paciente
CREATE TABLE historico_checkups (
cliente_id INT NOT NULL references cliente,
animal_id int not null references animal,
Veterinario_id INT NOT NULL references funcionario,
DataAtendimento DATE NOT NULL,
DiagnosticoPrincipal VARCHAR(200) not null,
PesoRegistrado DECIMAL(5,2) null,
status_exame_hemograma varchar(100),
status_exame_bioquimico varchar(100),
status_exame_ultrassom varchar(100),
Observacoes varchar(max)
);

create clustered index idx_historico_checkups_paciente on historico_checkups(cliente_id, dataAtendimento desc)

--herança e constraint unique

CREATE TABLE pessoa_fisica (
id_funcionario INT PRIMARY KEY REFERENCES funcionario(id),
cpf VARCHAR(14) NOT NULL UNIQUE,
rg VARCHAR(20),
data_nascimento DATE,
genero CHAR(1),
estado_civil VARCHAR(20),
    
CONSTRAINT uq_cpf UNIQUE (cpf)
);

-- Tabela especializada para pessoas jurídicas
CREATE TABLE pessoa_juridica (
id_funcionario INT PRIMARY KEY REFERENCES funcionario(id),
cnpj VARCHAR(18) NOT NULL,
razao_social VARCHAR(200) NOT NULL,
nome_fantasia VARCHAR(100),
inscricao_estadual VARCHAR(20),
data_fundacao DATE,
representante_legal VARCHAR(100),
   
CONSTRAINT uq_cnpj UNIQUE (cnpj)
);
