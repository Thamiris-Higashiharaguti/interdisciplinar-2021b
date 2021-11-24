Drop database BD_TiroGuerra;

CREATE DATABASE BD_TiroGuerra
GO

USE BD_TiroGuerra
GO

CREATE TABLE TB_Usuario
(
	Id			INT				NOT NULL	PRIMARY KEY		IDENTITY,
	Nome		VARCHAR(100)	NOT NULL,
	Status		BIT				NOT NULL,
	CPF			VARCHAR(11)		NOT NULL	UNIQUE,
	RG			VARCHAR(11)		NOT NULL	UNIQUE,
	Senha		VARCHAR(100)	NOT NULL,
	Email       VARCHAR(200)    NOT NULL    UNIQUE,
)
GO

CREATE TABLE TB_Pelotao
(
	Id		INT			NOT NULL	PRIMARY KEY IDENTITY,
	Nome	VARCHAR(50)	NOT NULL,
	Ano		DATETIME,	
)
GO

CREATE TABLE TB_Instrutor
(
	Id_Usuario	INT			NOT NULL	PRIMARY KEY REFERENCES TB_Usuario,
	Graduacao	VARCHAR(50)	NOT NULL	
)
GO

CREATE TABLE TB_Atirador
(
	Id_Usuario		INT		NOT NULL	PRIMARY KEY REFERENCES TB_Usuario,
	Id_Pelotao		INT		NOT NULL	REFERENCES TB_Pelotao,
	Formacao		VARCHAR(50)	NOT NULL,
	RA				VARCHAR(12)	NOT NULL UNIQUE,
	GDA_Vermelha	DATETIME,
	GDA_Preta		DATETIME,
	Numero			VARCHAR(3)	NOT NULL,

)
GO

CREATE TABLE TB_Guarnicao
(
	Id				INT			NOT NULL 	PRIMARY KEY IDENTITY,
	Id_Instrutor	INT			NOT NULL 	REFERENCES TB_Instrutor,
	Data			DATETIME	NOT NULL,
)
GO

CREATE TABLE TB_Guarda
(
	Id_Atirador					INT			NOT NULL REFERENCES TB_Atirador,
	Id_Guarnicao				INT			NOT NULL REFERENCES TB_Guarnicao,
	Presenca					BIT,
	Funcao						VARCHAR(50) NOT NULL,
	PRIMARY KEY (Id_Atirador, Id_Guarnicao)
)
GO

CREATE TABLE TB_Instrucao
(
	Id		INT			NOT NULL PRIMARY KEY IDENTITY,
	Data	DATETIME	NOT NULL
)
GO

CREATE TABLE TB_Chamada
(
	Id_Instrucao		INT		NOT NULL	REFERENCES TB_Instrucao,
	Id_Atirador			INT		NOT NULL	REFERENCES TB_Atirador,
	Id_Responsavel		INT		NOT NULL	REFERENCES TB_Atirador,
	Presenca			BIT,
	PRIMARY KEY (Id_Instrucao, Id_Atirador)
)
GO


--Procedures

CREATE PROCEDURE CREATE_ATIRADOR(
	
    @Nome varchar(200),
	@CPF varchar(12),
	@RG varchar(12),
	@Status BIT,
	@Senha varchar(50),
	@Id_Pelotao int,
	@Formacao varchar(50),
	@RA varchar(50),
	@Numero varchar(50)
    
) AS BEGIN

	Insert into TB_Usuario values (@Nome, @Status,@CPF, @RG, @Senha)
	Insert into TB_Atirador values (@@IDENTITY, @Id_Pelotao, @Formacao, @RA,null,null,@Numero)
    
END
GO

CREATE VIEW SEARCH_ATIRADORES
AS
select * from TB_Usuario us, TB_Atirador at where us.Id=at.Id_Usuario
GO

SELECT * FROM SEARCH_ATIRADORES
GO

create procedure CREATE_INSTRUTOR
(
	@NOME varchar(100),
	@STATUS bit,
	@CPF varchar(11),
	@RG  varchar(11),
	@GRADUACAO varchar(50),
	@SENHA varchar(100)
)
as 
begin
	insert into TB_Usuario(Nome,Status,CPF,RG,Senha)
	values(@nome,@status,@cpf,@rg,@SENHA)

	insert into TB_Instrutor(Id_Usuario,Graduacao)
	values (@@IDENTITY, @graduacao)
end
go

EXEC CREATE_INSTRUTOR 'Jose',1,'123','456','Tenente','123';
go


CREATE VIEW SEARCH_INSTRUTORES
AS
select * from TB_Usuario us, TB_Instrutor it where us.Id=it.Id_Usuario
GO

SELECT * FROM SEARCH_INSTRUTORES
GO
--Inserts

insert into TB_Pelotao(Nome,Ano) values('Azul','2018');
insert into TB_Pelotao(Nome,Ano) values('Amarelo','2018');
insert into TB_Pelotao(Nome,Ano) values('Vermelho','2018');

select * from TB_Pelotao
select * from SEARCH_ATIRADORES;


