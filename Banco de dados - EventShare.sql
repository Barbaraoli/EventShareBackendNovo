create database EventShare

use EventShare;

create table usuario_tipo_tbl (
	tipo_id int identity primary key not null,
	tipo_nome varchar(50) not null
);

create table evento_categoria_tbl (
	categoria_id int identity primary key not null,
	categoria_nome varchar(50) not null
);

create table evento_espaco_tbl (
	espaco_id int identity primary key not null,
	espaco_nome varchar(50) not null
);

create table evento_status_tbl (
	evento_status_id int identity primary key not null,
	evento_status_nome varchar(50) not null
);

create table usuario_tbl (
	usuario_id int identity primary key not null,
	usuario_nome varchar(50) not null,
	usuario_email varchar(100) not null,
	usuario_comunidade varchar(100),
	usuario_senha varchar(255) not null,
	usuario_tipo_id int foreign key references usuario_tipo_tbl(tipo_id) not null
);


create table evento_tbl (
	evento_id int identity primary key not null,
	evento_nome varchar(100) not null,
	evento_data date not null,
	evento_horario_comeco varchar(50) not null,
	evento_horario_fim varchar(50) not null,
	evento_descricao text not null,
	evento_categoria_id int foreign key references evento_categoria_tbl(categoria_id) not null,
	evento_espaco_id int foreign key references evento_espaco_tbl(espaco_id) not null,
	evento_status_id int foreign key references evento_status_tbl(evento_status_id) not null,
	criador_usuario_id int foreign key references usuario_tbl(usuario_id) not null,
	responsavel_usuario_id int foreign key references usuario_tbl(usuario_id) not null
);

insert into usuario_tipo_tbl (tipo_nome) values ('Administrador'), ('Funcionário'), ('Comunidade');

insert into evento_categoria_tbl (categoria_nome) values ('Tecnologia'), ('Idiomas'), ('Cultura'), ('Carreiras e Negócios');

insert into evento_espaco_tbl (espaco_nome) values ('Lounge'), ('Sala de Reuniões');

insert into evento_status_tbl (evento_status_nome) values ('Aprovado'), ('Reprovado'), ('Aguardando Aprovação'), ('Editado');

insert into usuario_tbl (usuario_nome, usuario_email, usuario_comunidade, usuario_senha, usuario_tipo_id) 
values ('Bárbara', 'barbara@gmail.com', 'Developers Circle', '18273645', 1),
('Catharina', 'catharina@gmail.com', 'Thoughtwors', '182736432', 2),
('Alex', 'alex@gmail.com', 'Itau', '18533645', 3);


insert into evento_tbl (evento_nome, evento_data, evento_horario_comeco, evento_horario_fim, evento_descricao, evento_categoria_id, evento_espaco_id, evento_status_id, criador_usuario_id, responsavel_usuario_id)
values ('Fórum Cultura Mais Diversidade São Paulo', '06-11-2019', '20h00', '22h00', 'Vamos mostrar que inclusão e ações afirmativas voltadas ao público-alvo estão longe de ser filantropia ou assistencialismo', 3, 1, 4, 3, 2),
('JavaScript', '04-11-2019', '19h30', '22h00', 'JavaScript é uma linguagem de programação interpretada estruturada', 1, 1, 1, 1, 2);


select * from usuario_tipo_tbl;
select * from evento_categoria_tbl;
select * from evento_espaco_tbl;
select * from evento_status_tbl;
select * from usuario_tbl;
select * from evento_tbl;

alter table evento_tbl add evento_imagem varchar(250)

