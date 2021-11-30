
--Inser��o na Tabela Pelotao
insert into TB_Pelotao(Nome, Ano) values ('Azul',2021);
insert into TB_Pelotao(Nome, Ano) values ('Amarelo',2021);
insert into TB_Pelotao(Nome, Ano) values ('Vermelho',2020);

go

--Inser��o na Tabela Atirador
EXEC CREATE_ATIRADOR 'Matheus Amaro Santos', '12312312346','123456789', 1,'12345', 1, 'Atirador','12345678', '66', 'amaro@email.com' 
exec CREATE_ATIRADOR 'Andre','47852497810','582198823',1,'123',1,'Cabo','01','10','andreluis@gmail.com';
exec CREATE_ATIRADOR 'Luis','47852497811','582198824',1,'123',2,'Cabo','02','11','Luis@gmail.com';
exec CREATE_ATIRADOR 'Mario','47852497812','582198825',1,'123',3,'Cabo','03','12','Mario@gmail.com';

exec CREATE_ATIRADOR 'Felipe','47852497813','582198826',1,'123',1,'Comandante','04','13','Felipe@gmail.com';
exec CREATE_ATIRADOR 'Daniel','47852497814','582198827',1,'123',2,'Comandante','05','14','Daniel@gmail.com';
exec CREATE_ATIRADOR 'Carlos','47852497815','582198828',1,'123',3,'Comandante','06','15','Carlos@gmail.com';

exec CREATE_ATIRADOR 'Julio','47852497816','582198829',1,'123',1,'Sentinela','07','16','Julio@gmail.com';
exec CREATE_ATIRADOR 'Jo�o','47852497817','582198830',1,'123',1,'Sentinela','08','17','Jo�o@gmail.com';
exec CREATE_ATIRADOR 'Roberto','47852497818','582198831',1,'123',2,'Sentinela','09','18','Roberto@gmail.com';
exec CREATE_ATIRADOR 'Fernando','47852497819','582198832',1,'123',2,'Sentinela','10','19','Fernando@gmail.com';
exec CREATE_ATIRADOR 'Patrick','47852497820','582198833',1,'123',3,'Sentinela','11','20','Patrick@gmail.com';
exec CREATE_ATIRADOR 'Sergio','47852497821','582198834',1,'123',3,'Sentinela','12','21','Sergio@gmail.com';
exec CREATE_ATIRADOR 'Sidney','47852497999','582198888',1,'123',3,'Sentinela','13','21','Sidney@gmail.com';
exec CREATE_ATIRADOR 'Coelho','47852497888','582198777',1,'123',3,'Sentinela','14','21','Coelho@gmail.com';
go

--Inser��o na Tabela Instrutor
EXEC CREATE_INSTRUTOR 'Jos� da Silva',1,'123456712','32132112','SubTenente','123','Jose@outlook.com'; 
EXEC CREATE_INSTRUTOR 'Marcos',1,'11111112','111122','Tenente','123','Marcos@outlook.com'; 
EXEC CREATE_INSTRUTOR 'Vitor',1,'22222223','222233','General','123','Vitor@outlook.com';
