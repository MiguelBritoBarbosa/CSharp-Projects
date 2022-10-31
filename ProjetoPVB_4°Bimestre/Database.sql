create database Projeto;
use Projeto;

create table Tabela1(
	Codigo varchar(45) primary key not null,
    Cpf varchar(14) not null,
    Nome varchar(45),
    Cidade varchar(45) not null,
    Bairro varchar(45) not null,
    Telefone varchar(15) not null,
    Foto varchar(60) not null
);