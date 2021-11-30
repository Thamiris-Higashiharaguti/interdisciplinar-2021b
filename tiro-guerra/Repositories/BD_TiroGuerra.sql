drop database BD_TiroGuerra;

CREATE DATABASE BD_TiroGuerra ;
GO 

USE BD_TiroGuerra 
GO 

CREATE TABLE TB_Usuario 
( 

Id			INT		NOT NULL	PRIMARY KEY	IDENTITY, 
Nome		VARCHAR(100)	NOT NULL, 
Status		BIT		NOT NULL, 
CPF			VARCHAR(11)	NOT NULL	UNIQUE, 
RG			VARCHAR(11)	NOT NULL	UNIQUE, 
Senha		VARCHAR(100)	NOT NULL, 
Email		VARCHAR(100)	NOT NULL     UNIQUE
) 

GO 

CREATE TABLE TB_Pelotao 
( 
Id		INT				NOT NULL	PRIMARY KEY IDENTITY, 
Nome	VARCHAR(50)		NOT NULL, 
Ano		DATETIME,	 
) 

GO 

CREATE TABLE TB_Instrutor 
( 
Id_Usuario		INT			NOT NULL	PRIMARY KEY REFERENCES TB_Usuario, 
Graduacao		VARCHAR(50)	NOT NULL	 
) 

GO 

CREATE TABLE TB_Atirador 
( 
Id_Usuario		INT				NOT NULL	PRIMARY KEY REFERENCES TB_Usuario, 
Id_Pelotao		INT				NOT NULL	REFERENCES TB_Pelotao, 
Formacao		VARCHAR(50)		NOT NULL, 
RA				VARCHAR(12)		NOT NULL	UNIQUE, 
GDA_Vermelha	DATETIME, 
GDA_Preta		DATETIME, 
Numero			VARCHAR(3)	NOT NULL, 
) 

GO 

CREATE TABLE TB_Guarnicao 
( 
Id				INT		NOT NULL 	PRIMARY KEY IDENTITY, 
Id_Instrutor	INT		NOT NULL 	REFERENCES TB_Instrutor, 
Data			DATETIME	NOT NULL, 
) 

GO 

CREATE TABLE TB_Guarda 
( 
Id				INT		NOT NULL PRIMARY KEY IDENTITY,
Id_Atirador		INT		NOT NULL REFERENCES TB_Atirador, 
Id_Guarnicao	INT		NOT NULL REFERENCES TB_Guarnicao, 
Presenca		BIT, 
Funcao			VARCHAR(50) NOT NULL, 
) 

Go

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

--------------------------------------------------------------------
--Procedure de Busca de todos os instrutores
CREATE VIEW SEARCH_INSTRUTORES 
AS 
SELECT * FROM TB_Usuario AS usuario  
INNER JOIN TB_Instrutor AS instrutor 
ON (usuario.Id = instrutor.Id_Usuario) 

GO 

-- Procedure de Busca de Instrutor
CREATE PROCEDURE SEARCH_INSTRUTOR 
( 
@id int 
) AS BEGIN 
SELECT U.id, U.Nome, U.CPF, U.RG, U.Senha,U.Email, I.Graduacao 
FROM TB_Instrutor I INNER JOIN TB_Usuario  U ON (I.Id_Usuario = U.Id)
Where U.id = @id; 
END


-- Procedure de Cadastrar Instrutor
 CREATE PROCEDURE CREATE_INSTRUTOR 
( 
    @NOME    varchar(100), 
    @STATUS  bit, 
    @CPF     varchar(11), 
    @RG      varchar(11), 
    @GRADUACAO varchar(50), 
    @SENHA   varchar(100), 
    @Email   varchar(100) 
) 
AS BEGIN 
    insert into TB_Usuario(Nome,Status,CPF,RG,Senha,Email)
	values(@nome,@status,@cpf,@rg,@SENHA,@Email) 
    insert into TB_Instrutor(Id_Usuario,Graduacao) 
    values (@@IDENTITY, @graduacao) 
END 

-- Procedure de Atualizar Instrutor
CREATE PROCEDURE UPDATE_INSTRUTOR 
( 
@Nome varchar(100), 
@Status BIT, 
@CPF Varchar(15), 
@RG varchar(100), 
@Senha varchar(50), 
@Email varchar(100), 
@Graduacao varchar(50), 
@id int 
) AS BEGIN 
UPDATE TB_Usuario SET Nome=@Nome, CPF=@CPF, RG=@RG, Status=@Status, Email=@Email WHERE Id = @id; 
UPDATE TB_Instrutor SET Graduacao=@Graduacao WHERE Id_Usuario = @id; 
END 

-- Procedure de Deletar Instrutor
CREATE PROCEDURE DELETE_INSTRUTOR 
( 
@id int 
) AS BEGIN 
DELETE FROM TB_Instrutor WHERE Id_Usuario = @id; 
DELETE FROM TB_Usuario WHERE Id = @id 
END 

-------------------------------------------------------------------------

-- View de visualização dos atiradores 
CREATE VIEW SEARCH_ATIRADORES 
AS 
SELECT * FROM TB_Usuario AS usuario  
INNER JOIN TB_Atirador AS atirador 
ON (usuario.Id = atirador.Id_Usuario) 

GO 

-- Procedure de Busca de Atirador
CREATE PROCEDURE SEARCH_ATIRADOR 
( 
@id int 
) AS BEGIN 
SELECT U.id, U.Nome, U.CPF, U.RG,u.Email,A.Formacao, A.RA, A.Numero, P.Nome 
FROM TB_Atirador A INNER JOIN TB_Usuario  U ON (A.Id_Usuario = U.Id) 
INNER JOIN TB_Pelotao P ON (A.Id_Pelotao = P.Id) Where U.id = @id; 
END


-- Procedure de criação do atirador
CREATE PROCEDURE CREATE_ATIRADOR( 
    @Nome varchar(200), 
    @CPF varchar(12), 
    @RG varchar(12), 
    @Status BIT, 
    @Senha varchar(50), 
    @Id_Pelotao int, 
    @Formacao varchar(50), 
    @RA varchar(50), 
    @Numero varchar(50), 
    @Email varchar(100) 
) AS BEGIN 
    Insert into TB_Usuario values (@Nome, @Status,@CPF, @RG, @Senha,@Email) 
    Insert into TB_Atirador values (@@IDENTITY, @Id_Pelotao, @Formacao, @RA,null,null,@Numero) 
END 


--Procedure de alterar atirador
CREATE PROCEDURE UPDATE_ATIRADOR 
( 
@Nome varchar(100), 
@CPF Varchar(15), 
@RG varchar(100), 
@Status BIT, 
@Email varchar(100), 
@Id_Pelotao int, 
@Formacao Varchar(30), 
@RA varchar(15), 
@Numero Varchar(15), 
@id int 
) AS BEGIN 

UPDATE TB_Usuario SET Nome=@Nome, CPF=@CPF, RG=@RG, Status=@Status, Email=@Email WHERE Id = @id; 
UPDATE TB_Atirador SET Formacao=@Formacao, RA=@RA, Numero=@Numero WHERE Id_Usuario = @id; 
END 


-- Procedure de Deletar Atirador
CREATE PROCEDURE DELETE_ATIRADOR 
( 
@id int 
)
AS BEGIN 
DELETE FROM TB_Atirador WHERE Id_Usuario = @id; 
DELETE FROM TB_Chamada WHERE Id_Atirador = @id 
DELETE FROM TB_Usuario WHERE Id = @id  
END 


-------------------------------------------------------------------------------

-- Procedure de busca de Guarniçoes ja formadas
CREATE PROCEDURE SEARCH_GUARNICOES(
@domingo Date,
@sabado Date
)
as begin
select  gr.id [Id Guarnicao],gr.Data, u.Id [Id Instrutor], u.Nome [Nome Instrutor], i.Graduacao [Graduacao Instrutor]
from TB_Instrutor i
 inner join TB_Guarnicao gr on i.Id_Usuario = gr.Id_instrutor
 inner join TB_Usuario u on i.Id_Usuario=u.id
 where gr.Data between @domingo and @sabado
 order by gr.id
end

-- Procedure de criação da guarnição
CREATE PROCEDURE CREATE_GUARNICAO( 
  @id_instrutor int,
  @data datetime
) AS BEGIN 
    Insert into TB_Guarnicao values (@id_instrutor, @data) 
    Select * from TB_Guarnicao where Id = @@IDENTITY
END 


-- Procedure de alterar Guarnição
CREATE PROCEDURE UPDATE_GUARNICAO
(
	@Id int,
	@Id_Instrutor int
) AS BEGIN
	UPDATE TB_Guarnicao SET Id_Instrutor = @Id_Instrutor WHERE Id = @Id
END

------------------------------------------------------------------------------

-- Procedure de busca de Guardas ja formadas
CREATE PROCEDURE SEARCH_GUARDAS(
@domingo Date,
@sabado Date
)
as begin
 select a.Id_Usuario [ID atirador],u.Nome [Nome Atirador], 
		gr.Id [ID da Guarnicao], ga.Funcao [Funcao Guarda], 
		gr.Data [Dia da Guarnicao], ga.Id [Id Guarda]
from TB_Guarda ga
 inner join TB_Guarnicao gr on ga.Id_Guarnicao = gr.Id
 inner join TB_Atirador a on a.Id_Usuario=ga.Id_Atirador
 inner join TB_Usuario u on u.Id =a.Id_Usuario
 where gr.Data between @domingo and @sabado
 order by  gr.Data, ga.Funcao
 
end

-- Criação da Guarda
CREATE PROCEDURE CREATE_GUARDA( 
  @Id_Atirador int,
  @Id_Guarnicao int,
  @Presenca bit,
  @Funcao varchar(100)
) AS BEGIN 
    Insert into TB_Guarda(Id_Atirador,Id_Guarnicao,Presenca,Funcao) values (@Id_Atirador, @Id_Guarnicao, @Presenca, @Funcao) 
END 

-- Procedure de Alterar Guarda
CREATE PROCEDURE UPDATE_GUARDA
(
	@Id int,
	@Id_Atirador int 
) AS BEGIN
	UPDATE TB_Guarda SET Id_Atirador = @Id_Atirador WHERE Id = @Id
END
------------------------------------------------------------------
 
-- Procedure de Cadastrar Chamada
CREATE PROCEDURE create_chamada 
( 
    @Id_atirador int, 
    @Id_responsavel int, 
    @Presenca BIT 
) AS BEGIN 
    Declare @Id_instrucao int 
    SET @Id_instrucao = (Select max(Id) From TB_Instrucao) 
    Insert into TB_Chamada values (@Id_instrucao, @Id_atirador, @Id_responsavel, @Presenca) 
END 


-- Procedure de Atualizar Chamada

CREATE PROCEDURE update_chamada 
( 
    @Presenca BIT, 
    @data DATE, 
    @id int 
) AS BEGIN 
    UPDATE TB_Chamada SET Presenca=@Presenca 
    FROM TB_Chamada as C inner join TB_Instrucao as I on C.Id_Instrucao = I.Id 
    WHERE i.Data = @data and C.Id_Atirador=@id;     
END 