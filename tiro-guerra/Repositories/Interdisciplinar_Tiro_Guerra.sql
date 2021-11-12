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

create procedure Cadastrar_Instrutor
(
	@nome varchar(100),
	@status bit,
	@cpf varchar(11),
	@rg  varchar(11),
	@graduacao varchar(50)
)
as 
begin
	insert into TB_Usuario(Nome,Status,CPF,RG)
	values(@nome,@status,@cpf,@rg)

	insert into TB_Instrutor(Id_Usuario,Graduacao)
	values (@@IDENTITY, @graduacao)
end
go

CREATE PROCEDURE CREATE_ATIRADOR(
	Declare @Id_Usuario int
    @Nome varchar(200),
	@CPF varchar(12),
	@RG varchar(12),
	@Status BIT,
	@Senha varchar(50),
	@Id_Pelotao int,
	@Formacao varchar(50),
	@RA varchar(50),
	@Numero varchar(50),

    
) AS BEGIN
	Insert into TB_Usuario values (@Nome, @Status,@CPF, @RG)
	SET @Id_Usuario = (Select id From TB_Usuario where CPF = @CPF)
	Insert into TB_Atirador values (@Id_Usuario, @Id_Pelotao, @Formacao, @RA,null,null,@Numero)
    
END
GO