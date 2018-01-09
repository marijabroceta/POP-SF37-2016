--crebas.sql

CREATE TABLE TipNamestaja(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(80),
	Obrisan BIT 

);
GO

CREATE TABLE Namestaj(
	Id INT PRIMARY KEY IDENTITY(1,1),
	TipNamestajaId INT,
	AkcijskaProdajaId INT DEFAULT(0),
	Naziv VARCHAR(100),
	Sifra VARCHAR(20),
	Cena NUMERIC(9,2),
	Kolicina INT,
	CenaNaAkciji NUMERIC (9,2),
	Obrisan BIT,
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id) ,
	FOREIGN KEY (AkcijskaProdajaId) REFERENCES AkcijskaProdaja(Id)
);
GO

DROP TABLE Namestaj

CREATE TABLE DodatnaUsluga(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(80),
	Cena NUMERIC(9,2),
	Obrisan BIT 
);
GO



CREATE TABLE Korisnik(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Ime VARCHAR(20),
	Prezime VARCHAR(30),
	KorisnickoIme VARCHAR(30),
	Lozinka VARCHAR(30),
	TipKorisnika VARCHAR(20) CHECK(TipKorisnika IN ('Administrator','Prodavac')),
	Obrisan BIT
);
GO


CREATE TABLE AkcijskaProdaja(
	Id INT PRIMARY KEY IDENTITY(1,1),
	Naziv VARCHAR(30),
	Popust INT,
	DatumPocetka DATETIME,
	DatumZavrsetka DATETIME,
	Obrisan BIT
);
GO 
DROP TABLE AkcijskaProdaja

CREATE TABLE NaAkciji(
	Id INT PRIMARY KEY IDENTITY(1,1),
	NamestajId INT,
	AkcijskaProdajaId INT,
	Obrisan BIT,
	FOREIGN KEY (NamestajId) REFERENCES Namestaj(Id) ,
	FOREIGN KEY (AkcijskaProdajaId) REFERENCES AkcijskaProdaja(Id)

);
GO
DROP TABLE NaAkciji


CREATE TABLE StavkaProdaje(
	Id INT PRIMARY KEY IDENTITY (1,1),
	ProdajaNamestajaId INT,
	NamestajId INT,
	Kolicina INT,
	Cena NUMERIC(9,2),
	Obrisan BIT,
	FOREIGN KEY (ProdajaNamestajaId) REFERENCES ProdajaNamestaja(Id),
	FOREIGN KEY (NamestajId) REFERENCES Namestaj(Id)
	
);
GO
DROP TABLE StavkaProdaje

CREATE TABLE ProdajaNamestaja(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DatumProdaje DATETIME,
	BrojRacuna VARCHAR(100),
	Kupac VARCHAR(80),
	UkupnaCenaSaPDV NUMERIC(9,2),
	UkupnaCenaBezPDV NUMERIC(9,2),
	
);
GO

DROP TABLE ProdajaNamestaja

CREATE TABLE ProdataUsluga(
	Id INT PRIMARY KEY IDENTITY(1,1),
	ProdajaNamestajaId INT,
	DodatnaUslugaId INT,
	Obrisan BIT,
	FOREIGN KEY (ProdajaNamestajaId) REFERENCES ProdajaNamestaja(Id),
	FOREIGN KEY (DodatnaUslugaId) REFERENCES DodatnaUsluga(Id)
);


DROP TABLE ProdataUsluga

CREATE TABLE Salon(
	 Id INT PRIMARY KEY IDENTITY(1,1),
	 Naziv VARCHAR(50),
	 Adresa VARCHAR(80),
	 Telefon VARCHAR(20),
	 Email VARCHAR(50),
	 WebSajt VARCHAR(80),
	 PIB INT,
	 JMBG VARCHAR(13),
	 BrojZiroRacuna VARCHAR(50),
	 Obrisan BIT
        
);


