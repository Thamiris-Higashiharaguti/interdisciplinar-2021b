CREATE DATABASE BD_TiroGuerra
GO

USE BD_TiroGuerra
GO

CREATE TABLE TB_Usuario
(
	Id		INT				NOT NULL	PRIMARY KEY		IDENTITY,
	Nome	VARCHAR(100)	NOT NULL,
	Status	VARCHAR(7)		NOT NULL,
	CPF		VARCHAR(11)		NOT NULL	UNIQUE,
	RG		VARCHAR(11)		NOT NULL	UNIQUE,
)
GO

CREATE TABLE TB_Pelotao
(
	Id		INT				NOT NULL	PRIMARY KEY IDENTITY,
	Nome	VARCHAR(50)		NOT NULL,
	Ano		datetime,
)
GO

CREATE TABLE TB_Instrutor
(
	Id_Usuario	INT				NOT NULL	PRIMARY KEY REFERENCES TB_Usuario,
	Graduacao	VARCHAR(50)		NOT NULL	
)
GO

CREATE TABLE TB_Atirador
(
	Id_Usuario		INT			NOT NULL	PRIMARY KEY REFERENCES TB_Usuario,
	Id_Pelotao		INT			NOT NULL	REFERENCES TB_Pelotao,
	Formacao		VARCHAR(50)	NOT NULL,
	RA				VARCHAR(12)	NOT NULL UNIQUE,
	GDA_Vermelha	DATETIME,
	GDA_Preta		DATETIME,
	Numero			VARCHAR(3)	NOT NULL,

)
GO

CREATE TABLE TB_Guarnicao
(
	Id				INT			NOT NULL PRIMARY KEY IDENTITY,
	Id_Instrutor	INT			NOT NULL REFERENCES TB_Instrutor,
	Data			DATETIME	NOT NULL,
)
GO

CREATE TABLE TB_Guarda
(
	Id_Atirador		INT			NOT NULL REFERENCES TB_Atirador,
	Id_Guarnicao	INT			NOT NULL REFERENCES TB_Guarnicao,
	Presenca		BIT,
	Funcao			VARCHAR(50) NOT NULL,
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
	Id_Instrucao	INT		NOT NULL	REFERENCES TB_Instrucao,
	Id_Atirador		INT		NOT NULL	REFERENCES TB_Atirador,
	Id_Responsavel	INT		NOT NULL	REFERENCES TB_Atirador,
	Presenca		BIT,
	PRIMARY KEY (Id_Instrucao, Id_Atirador)
)
Go