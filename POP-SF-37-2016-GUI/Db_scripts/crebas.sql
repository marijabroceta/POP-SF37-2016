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
	AkcijskaProdajaId INT,
	Naziv VARCHAR(100),
	Sifra VARCHAR(20),
	Cena NUMERIC(9,2),
	Kolicina INT,
	Obrisan BIT,
	FOREIGN KEY (TipNamestajaId) REFERENCES TipNamestaja(Id) ,
	FOREIGN KEY (AkcijskaProdajaId) REFERENCES AkcijskaProdaja(Id)
);
GO

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

CREATE TABLE NaAkciji(
	NamestajId INT,
	AkcijskaProdajaId INT,
	FOREIGN KEY (NamestajId) REFERENCES Namestaj(Id) ,
	FOREIGN KEY (AkcijskaProdajaId) REFERENCES AkcijskaProdaja(Id)

);
GO

CREATE TABLE StavkaProdaje(
	Id INT PRIMARY KEY IDENTITY(1,1),
	ProdajaNamestajaId INT,
	NamestajId INT,
	Kolicina INT,
	FOREIGN KEY (NamestajId) REFERENCES Namestaj(Id),
	FOREIGN KEY (ProdajaNamestajaId) REFERENCES ProdajaNamestaja(Id)
);
GO

CREATE TABLE ProdajaNamestaja(
	Id INT PRIMARY KEY IDENTITY(1,1),
	DatumProdaje DATETIME,
	BrojRacuna VARCHAR(100),
	Kupac VARCHAR(80),
	UkupnaCenaSaPDV NUMERIC(9,2),
	UkupnaCenaBezPDV NUMERIC(9,2),
	
);
GO

CREATE TABLE ProdataUsluga(
	StavkaProdajeId INT,
	ProdajaNamestajaId INT,
	DodatnaUslugaId INT,
	FOREIGN KEY (StavkaProdajeId) REFERENCES StavkaProdaje(Id),
	FOREIGN KEY (ProdajaNamestajaId) REFERENCES ProdajaNamestaja(Id),
	FOREIGN KEY (DodatnaUslugaId) REFERENCES DodatnaUsluga(Id)
);









