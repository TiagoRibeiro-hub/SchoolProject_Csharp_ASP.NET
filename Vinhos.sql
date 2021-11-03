USE master
GO
IF EXISTS (SELECT * FROM sys.databases WHERE name = 'VinhosEFA') 
	DROP DATABASE VinhosEFA
GO
CREATE DATABASE VinhosEFA
GO
USE VinhosEFA
GO
CREATE TABLE Utilizador(
	Id					INT IDENTITY(1,1),
	Nome				NVARCHAR(150) NOT NULL,
	Email				NVARCHAR(150) NOT NULL,
	DataNascimento		DATETIME2,
	UserID				VARCHAR(50),
	CONSTRAINT			pkUtilizador PRIMARY KEY(Id) 
)
CREATE TABLE Produtor(
	Id					INT IDENTITY(1,1),
	Nome				NVARCHAR(250) NOT NULL,
	Morada				NVARCHAR(500),
	CodigoPostal		VARCHAR(8),
	Localidade			NVARCHAR(250),
	Telefone			VARCHAR(15),
	Email				VARCHAR(100),
	Activo				BIT DEFAULT(1),
	URL					NVARCHAR(150),
	CONSTRAINT			pkProdutor PRIMARY KEY(Id) 
)
GO
INSERT Produtor(Nome) VALUES	('CARM'), ('Quinta do Vallado'), ('Casa Ermelinda Freitas'),
								('Quinta da Pacheca'), ('Quinta do Vale Meão')
CREATE TABLE Regiao(
	Id					INT IDENTITY(1,1),
	Nome				NVARCHAR(150) NOT NULL,
	Descricao			NVARCHAR(1000),
	Activo				BIT DEFAULT(1),
	CONSTRAINT			pkRegiao PRIMARY KEY(Id) 
)
GO
INSERT Regiao(Nome) VALUES ('Alentejo'), ('Bairrada'), ('Dão'), ('Douro'), ('Lisboa'), ('Setúbal')  
CREATE TABLE TipoVinho(
	Id					INT IDENTITY(1,1),
	Nome				NVARCHAR(150) NOT NULL,
	Activo				BIT DEFAULT(1),
	CONSTRAINT			pkTipoVinho PRIMARY KEY(Id) 
)
GO
INSERT TipoVinho(Nome) VALUES ('Branco'), ('Tinto'), ('Rosé'), ('Verde'), ('Generoso'), ('Espumante')     
CREATE TABLE Enologo(
	Id					INT IDENTITY(1,1),
	Nome				NVARCHAR(250) NOT NULL,
	Instragram			NVARCHAR(150),
	Activo				BIT DEFAULT(1),
	CONSTRAINT			pkEnologo PRIMARY KEY(Id)
)
GO
INSERT Enologo(Nome) VALUES
	('João Portugal Ramos'), ('Anselmo Mendes'), ('Susana Esteban'),
	('Franscisco Olazabal'), ('Rita Marques'), ('Paulo Laureano'),
	('Sandra Tavares da Silva'), ('Filipa Pato'), ('Carlos Campolargo')
CREATE TABLE Casta(
	Id					INT IDENTITY(1,1),
	Nome				NVARCHAR(250) NOT NULL,
	Caracteristicas		NVARCHAR(1000),
	TipoVinho			INT,
	Activo				BIT DEFAULT(1),
	CONSTRAINT			pkCasta PRIMARY KEY(Id),
	CONSTRAINT			fkCastaTipo FOREIGN KEY(TipoVinho) REFERENCES TipoVinho(Id)
)
GO
INSERT Casta(Nome, TipoVinho) 
VALUES				('Tinta Roriz', 2), ('Touriga Franca', 2), ('Touriga Nacional', 2), ('Syrah', 2), ('Alfrocheiro', 2),
					('Aragonez', 2), ('Tinta caiada', 2), ('Arinto', 1), ('Antão Vaz', 1), ('Alvarinho', 4)
CREATE TABLE Vinho(
	Id					INT IDENTITY(1,1),
	Nome				NVARCHAR(250) NOT NULL,
	Foto				NVARCHAR(200),
	Regiao				INT,
	Produtor			INT,
	TipoVinho			INT,
	Volume				DECIMAL(4,2),
	TeorAlcoolico		DECIMAL(4,2),
	Temperatura			DECIMAL(4,2),
	Ano					INT,
	Utilizador			INT,
	Activo				BIT DEFAULT(1),
	CONSTRAINT			pkVinho PRIMARY KEY(Id),
	CONSTRAINT			fkVinhoRegiao FOREIGN KEY(Regiao) REFERENCES Regiao(Id),
	CONSTRAINT			fkVinhoProdutor FOREIGN KEY(Produtor) REFERENCES Produtor(Id),
	CONSTRAINT			fkVinhoTipo FOREIGN KEY(TipoVinho) REFERENCES TipoVinho(Id),
	CONSTRAINT			fkVinhoUtilizador FOREIGN KEY(Utilizador) REFERENCES Utilizador(Id)
)
GO
CREATE TABLE VinhoCasta(
	Id					INT IDENTITY(1,1),
	Vinho				INT,
	Casta				INT,
	CONSTRAINT			pkVinhoCasta PRIMARY KEY(Id),
	CONSTRAINT			fkVinhoCasta FOREIGN KEY(Vinho) REFERENCES Vinho(Id),
	CONSTRAINT			fkCastaVinho FOREIGN KEY(Casta) REFERENCES Casta(Id)
)
GO
CREATE TABLE VinhoEnologo(
	Id					INT IDENTITY(1,1),
	Vinho				INT,
	Enologo				INT,
	CONSTRAINT			pkVinhoEnologo PRIMARY KEY(Id),
	CONSTRAINT			fkVinhoEnologo FOREIGN KEY(Vinho) REFERENCES Vinho(Id),
	CONSTRAINT			fkEnologoVinho FOREIGN KEY(Enologo) REFERENCES Enologo(Id)
)
GO

CREATE TABLE VinhoProva(
	Id					INT IDENTITY(1,1),
	Vinho				INT,
	Utilizador			INT,
	Comentario			NVARCHAR(500),
	Classificacao		TINYINT,
	CONSTRAINT			pkVinhoProva PRIMARY KEY(Id),
	CONSTRAINT			fkVinhoProva FOREIGN KEY(Vinho) REFERENCES Vinho(Id),
	CONSTRAINT			fkUtilizadorProva FOREIGN KEY(Utilizador) REFERENCES Utilizador(Id)
)
GO

-----------------------
-----------------------
SET IDENTITY_INSERT dbo.Produtor ON 
INSERT Produtor(Id, Nome)
VALUES
	(100, 'Quinta Vale das Escadinhas'),
	(101, 'Quinta da Fata'),
	(102, 'Quinta da Pellada'),
	(103, 'Quinta de Lemos'),
	(104, 'Symington Family Estates'),
	(105, 'Casa Agrícola Roboredo Madeira'),
	(106, 'Quinta do Crasto'), 
	(107, 'Tavfer Vinhos'),
	(108, 'Prats & Symington'),
	(109, 'Quinta de La Rosa'),
	(110, 'Real Companhia Velha'),
	(111, 'Fundaçãoo Eugénio de Almeida'),
	(112, 'Cortes de Cima'),
	(113, 'Esporão')

SET IDENTITY_INSERT dbo.Produtor OFF 

SET IDENTITY_INSERT dbo.Vinho ON 
INSERT Vinho(Id, Nome, Foto, Regiao, TipoVinho, Produtor) 
VALUES 	
	(100, 'Quinta da Falorca', '/Imagens/imagensVinhos/QuintadaFalorca.jpg', 3, 2, 100),
	(101, 'Quinta da Fata', '/Imagens/imagensVinhos/QuintadaFata.jpg', 3, 2, 101),
	(102, 'Quinta da Pellada', '/Imagens/imagensVinhos/QuintadaPellada.jpg', 3, 2, 102),
	(104, 'Quinta da Lemos', '/Imagens/imagensVinhos/QuintadeLemos.jpg', 3, 2, 103),
	(105, 'Altano', '/Imagens/imagensVinhos/altano.jpg', 4, 2, 104),
	(106, 'CARM', '/Imagens/imagensVinhos/CARM.jpg', 4, 2, 105),
	(107, 'CARM Reserva', '/Imagens/imagensVinhos/CARM_reserva.jpg', 4, 2, 105),
	(108, 'Crasto', '/Imagens/imagensVinhos/crasto.jpg', 4, 2, 106),
	(109, 'Duvalley', '/Imagens/imagensVinhos/Duvalley.jpg', 4, 2, 107),
	(110, 'Duvalley Grande Reserva', '/Imagens/imagensVinhos/Duvalley_reserva.jpg', 4, 2, 107),
	(111, 'Post Scriptum', '/Imagens/imagensVinhos/PostScriptum.jpg', 4, 2, 108),
	(112, 'Quinta de La Rosa', '/Imagens/imagensVinhos/QuintadeLaRosa.jpg', 4, 2, 109),
	(113, 'Evel Reserva', '/Imagens/imagensVinhos/evel_reserva.jpg', 4, 2, 110),
	(114, 'Cartuxa', '/Imagens/imagensVinhos/cartuxa.jpg', 1, 2, 111),
	(115, 'Cortes de Cima', '/Imagens/imagensVinhos/CortesdeCima.jpg', 1, 2, 112),
	(116, 'Quatro Castas', '/Imagens/imagensVinhos/QuatroCastas.jpg', 1, 2, 113),
	(117, 'Esporão Colheita', '/Imagens/imagensVinhos/esporao_colheita.jpg', 1, 1, 113),
	(118, 'Esporão Verdelho', '/Imagens/imagensVinhos/esporao_verdelho.jpg', 1, 1, 113),
	(119, 'Quinta da Falorca Encruzado', '/Imagens/imagensVinhos/QuintadaFalorcaEncruzado.jpg', 3, 1, 100),
	(120, 'Quinta de Saes Encruzado', '/Imagens/imagensVinhos/QuintadeSaesEncruzado.jpg', 3, 1, 102),
	(121, 'Esporão Reserva', '/Imagens/imagensVinhos/esporao_reserva.jpg', 1, 2, 113)

SET IDENTITY_INSERT dbo.Vinho OFF 

------------------------------
--Stored Procedures

CREATE PROCEDURE usp_GetIDUtilizador(@id VARCHAR(50))
AS
	SELECT Id FROM Utilizador WHERE UserID = @id
GO

CREATE PROCEDURE usp_VinhoInsert(
	@nome					NVARCHAR(250),
	@foto					NVARCHAR(200),
	@regiao					INT,
	@produtor				INT,
	@tipo					INT,
	@volume					DECIMAL(4,2),
	@teorAlcoolico			DECIMAL(4,2),
	@ano					INT,
	@utilizador				INT
)
AS
BEGIN
	INSERT Vinho(Nome, Foto, Regiao, Produtor, TipoVinho, Volume, TeorAlcoolico, Ano, Utilizador)
	VALUES (@nome, @foto, @regiao, @produtor, @tipo, @volume, @teorAlcoolico, @ano, @utilizador)
	SELECT IDENT_CURRENT('Vinho')
END
GO

CREATE PROCEDURE usp_AssociarCastas(
	@vinho		INT,					
	@castas		VARCHAR(1000))			
AS 
BEGIN
	CREATE TABLE #temp(Id VARCHAR(5))
	INSERT #temp(Id) 
		SELECT value FROM string_split(@castas, ',');
	DECLARE @id_casta INT;
	WHILE EXISTS(SELECT * FROM #temp)
	BEGIN
		SELECT TOP 1 @id_casta = Id FROM #temp
		INSERT VinhoCasta(Vinho, Casta) VALUES(@vinho, @id_casta)  
		DELETE #temp WHERE Id = @id_casta
	END
	DROP TABLE #temp
END
GO

CREATE PROCEDURE usp_DissociarCastas(
	@vinho		INT,
	@castas		VARCHAR(1000))
AS 
BEGIN
	CREATE TABLE #temp(Id VARCHAR(5))
	INSERT #temp(Id) 
		SELECT value FROM string_split(@castas, ',');
	DECLARE @id_casta INT;
	WHILE EXISTS(SELECT * FROM #temp)
	BEGIN
		SELECT TOP 1 @id_casta = Id FROM #temp
		DELETE VinhoCasta WHERE Vinho = @vinho AND Casta= @id_casta
		DELETE #temp WHERE Id = @id_casta
	END
	DROP TABLE #temp
END
GO


CREATE PROCEDURE usp_AssociarEnologo(
	@vinho			INT,					
	@enologo		VARCHAR(1000))			
AS 
BEGIN
	CREATE TABLE #temp(Id VARCHAR(5))
	INSERT #temp(Id) 
		SELECT value FROM string_split(@enologo, ',');
	DECLARE @id_enologo INT;
	WHILE EXISTS(SELECT * FROM #temp)
	BEGIN
		SELECT TOP 1 @id_enologo = Id FROM #temp
		INSERT VinhoEnologo(Vinho, Enologo) VALUES(@vinho, @id_enologo)  
		DELETE #temp WHERE Id = @id_enologo
	END
	DROP TABLE #temp
END
GO

CREATE PROCEDURE usp_DissociarEnologo(
	@vinho		INT,
	@enologo	VARCHAR(1000))
AS 
BEGIN
	CREATE TABLE #temp(Id VARCHAR(5))
	INSERT #temp(Id) 
		SELECT value FROM string_split(@enologo, ',');
	DECLARE @id_enologo INT;
	WHILE EXISTS(SELECT * FROM #temp)
	BEGIN
		SELECT TOP 1 @id_enologo = Id FROM #temp
		DELETE VinhoEnologo WHERE Vinho = @vinho AND Enologo= @id_enologo
		DELETE #temp WHERE Id = @id_enologo
	END
	DROP TABLE #temp
END


GO


CREATE PROCEDURE usp_GetListaVinhos
AS
	SELECT				V.Id, V.Nome, V.Foto, P.Nome 'Produtor', R.Nome 'Regiao', T.Nome 'TipoVinho', 
							V.Ano, V.Volume, V.TeorAlcoolico, V.Temperatura, V.Activo, V.Utilizador, V.Activo
	FROM				Vinho V JOIN Produtor P ON V.Produtor = P.Id
						JOIN Regiao R ON V.Regiao = R.Id
						JOIN TipoVinho T ON V.TipoVinho = T.Id
	ORDER BY			V.Nome

GO

CREATE PROCEDURE usp_GetVinhoById
(@id INT)
AS 
	SELECT				V.Id, V.Nome, V.Foto, P.Nome 'Produtor', R.Nome 'Regiao', T.Nome 'TipoVinho',
							V.Ano, V.Volume, V.TeorAlcoolico, V.Temperatura, V.Activo, V.Utilizador, V.Activo
	FROM				Vinho V JOIN Produtor P ON V.Produtor = P.Id
						JOIN Regiao R ON V.Regiao = R.Id
						JOIN TipoVinho T ON V.TipoVinho = T.Id
	WHERE				V.Id = @id
	ORDER BY			V.Nome

GO

CREATE PROCEDURE usp_GetVinhoByUser
(@id INT)
AS 
	select v.Id, v.Nome, v.Foto, p.Nome 'Produtor', r.Nome 'Regiao', tv.Nome 'TipoVinho',
							v.Ano, v.Volume, v.TeorAlcoolico, v.Temperatura, v.Activo, v.Utilizador, (select Nome from Utilizador where Id = v.Utilizador) 'User Nome', V.Activo
	from Vinho v join Produtor p on v.Produtor = p.Id
					join Regiao r on v.Regiao = r.Id
					join TipoVinho tv on v.TipoVinho = tv.Id
	where v.Utilizador = @id

GO
--------------------------
select * from Enologo
select * from TipoVinho
select * from Regiao
select * from Vinho 
select * from Produtor order by Nome
select * from VinhoCasta
select * from casta
select * from VinhoEnologo 
select * from Utilizador
select * from Users
select * from VinhoProva

select Enologo.Nome from Enologo join VinhoEnologo on enologo.Id = VinhoEnologo.Enologo
where VinhoEnologo.Vinho = 4

select Produtor.Id, Vinho.Id, Vinho.Activo from Produtor join Vinho on Produtor.id = Vinho.Produtor
where Produtor.Id = 2

update TipoVinho set Activo = 0 where nome = 'Verde'

update Casta set Activo = 0 where Nome = 'testeB'

update Produtor set URL='https://www.esporao.com/pt-pt/' where Nome = 'Esporão'

update Vinho set Ano = 2000, Temperatura = 12, TeorAlcoolico=17, Volume = 0.75, Utilizador = 1 where Nome ='Altano'
update Vinho set Ano = 2000, Temperatura = 12, TeorAlcoolico=17, Volume = 0.75, Utilizador = 1 where Nome ='CARM'
update Vinho set Ano = 2000, Temperatura = 12, TeorAlcoolico=17, Volume = 0.75, Utilizador = 1 where Nome ='CARM Reserva'
update Vinho set Ano = 2000, Temperatura = 12, TeorAlcoolico=17, Volume = 0.75, Utilizador = 1 where Nome ='Esporão Colheita'
update Vinho set Ano = 2000, Temperatura = 12, TeorAlcoolico=17, Volume = 0.75, Utilizador = 1 where Nome ='Esporão Verdelho'
update Vinho set Ano = 2000, Temperatura = 12, TeorAlcoolico=17, Volume = 0.75, Utilizador = 1 where Nome ='Crasto'

insert into VinhoProva(Vinho, Utilizador, Comentario, Classificacao) values(105,1, 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb
bbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbbb', 4)
insert into VinhoProva(Vinho, Utilizador, Comentario, Classificacao) values(106,1, 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', 4)
insert into VinhoProva(Vinho, Utilizador, Comentario, Classificacao) values(107,1, 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', 4)
insert into VinhoProva(Vinho, Utilizador, Comentario, Classificacao) values(108,1, 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', 4)
insert into VinhoProva(Vinho, Utilizador, Comentario, Classificacao) values(117,1, 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', 4)
insert into VinhoProva(Vinho, Utilizador, Comentario, Classificacao) values(118,1, 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa', 4)
insert into VinhoProva(Vinho, Utilizador, Comentario, Classificacao) values(125,2, 'aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa
cccccccccccccccccccccccccccccccccccccccccccccccccccccccccccc', 1)

update Utilizador set Email = 'testeAdmin@gmail.com' where Nome = 'tiago'


select v.Nome, p.Nome, r.Nome, tv.Nome, (select Nome from Utilizador where Id = v.Utilizador) 'U'
from Vinho v join Produtor p on v.Produtor = p.Id
				join Regiao r on v.Regiao = r.Id
				join TipoVinho tv on v.TipoVinho = tv.Id

				
select c.Nome
from VinhoCasta vc join Casta c on vc.Casta = c.Id 


select v.Nome, v.Regiao, v.Produtor, v.TipoVinho
from Vinho v join Utilizador u on v.Utilizador = u.Id
where u.Id = 1

select nome from Utilizador

select v.Nome, c.Nome
from Vinho v join VinhoCasta vc on v.Id = vc.Vinho
				join Casta c on vc.Casta = c.Id
where c.Id = 125

select e.Nome
from VinhoEnologo ve join Enologo e on ve.Enologo = e.Id
where ve.Vinho = 106


select v.Nome, p.Nome, r.Nome, tv.Nome, c.Nome, e.Nome
from Vinho v join Produtor p on v.Produtor = p.Id
				join Regiao r on v.Regiao = r.Id
				join TipoVinho tv on v.TipoVinho = tv.Id
				join VinhoCasta vc on v.id = vc.Vinho
				join VinhoEnologo ve on v.Id = ve.Vinho
				join Casta c on vc.Casta = c.Id
				join Enologo e on ve.Enologo = e.id
where c.Id = 5

