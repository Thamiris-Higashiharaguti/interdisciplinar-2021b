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


--exec CREATE_ATIRADOR 'Andre','478524','85787',1,'senha',1,'Comandante','123466','01';

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


create procedure CREATE_GUARNICAO
(
	@Id_Instrutor varchar(100),
	@data DATE
)AS BEGIN
	insert into TB_Guarnicao(@Id_Instrutor,@data)

end

CREATE PROCEDURE UPDATE_ATIRADOR
(
	@Nome varchar(100),
	@CPF Varchar(15),
	@RG varchar(100),
	@Status BIT,
	@Id_Pelotao int,
	@Formacao Varchar(30),
	@RA varchar(15),
	@Numero Varchar(15),
	@id int
) AS BEGIN
	UPDATE TB_Usuario SET Nome=@Nome, CPF=@CPF, RG=@RG, Status=@Status WHERE Id = @id;
	UPDATE TB_Atirador SET Formacao=@Formacao, RA=@RA, Numero=@Numero WHERE Id_Usuario = @id;
    
END
go


CREATE PROCEDURE SEARCH_ATIRADOR_LOGIN
(
	@CPF Varchar(15),
	@Senha varchar(100)
) AS BEGIN
	SELECT U.id, U.Nome, U.CPF, U.RG,A.Formacao, A.RA, A.Numero, P.Nome FROM TB_Atirador A INNER JOIN TB_Usuario  U ON (A.Id_Usuario = U.Id) INNER JOIN TB_Pelotao P ON (A.Id_Pelotao = P.Id) Where U.CPF = @CPF AND U.Senha = @Senha;

END
go
EXEC '13245678912','123';


UPDATE TB_Chamada SET Id_Responsavel=@Id_Responsavel, Presenca=@Presenca
FROM TB_Chamada as C inner join TB_Instrucao as I on C.Id_Instrucao = I.Id
WHERE i.Data = @data and Id_Atirador=@Id_Atirador;