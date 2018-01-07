--seed.sql

INSERT INTO TipNamestaja (Naziv,Obrisan) VALUES ('Polica',0);
INSERT INTO TipNamestaja (Naziv,Obrisan) VALUES ('Regal',0);
INSERT INTO TipNamestaja (Naziv,Obrisan) VALUES ('Ugaona garnitura',0);
INSERT INTO TipNamestaja (Naziv,Obrisan) VALUES ('Krevet',0);

INSERT INTO Namestaj (TipNamestajaId,AkcijskaProdajaId,Naziv,Sifra,Cena,Kolicina,CenaNaAkciji,Obrisan)
VALUES (1,1,'Ultra polica','UL1PO', 13999, 2,0, 0);
INSERT INTO Namestaj (TipNamestajaId,AkcijskaProdajaId,Naziv,Sifra,Cena,Kolicina,CenaNaAkciji,Obrisan)
VALUES (2,2,'Ultra regal','UL2RE', 18999, 3,227999 ,0);
INSERT INTO Namestaj (TipNamestajaId,AkcijskaProdajaId,Naziv,Sifra,Cena,Kolicina,CenaNaAkciji,Obrisan)
VALUES (3,1,'Ultra ugaona','UL3UG', 21999, 4, 0,0);
INSERT INTO Namestaj (TipNamestajaId,AkcijskaProdajaId,Naziv,Sifra,Cena,Kolicina,CenaNaAkciji,Obrisan)
VALUES (4,2,'Ultra krevet','UL4KR', 23999, 5,287999, 0);

INSERT INTO DodatnaUsluga (Naziv,Cena,Obrisan) VALUES ('Prevoz',2000,0);
INSERT INTO DodatnaUsluga (Naziv,Cena,Obrisan) VALUES ('Montaza',1500,0);
INSERT INTO DodatnaUsluga (Naziv,Cena,Obrisan) VALUES ('Pakovanje',1000,0);


INSERT INTO Korisnik(Ime,Prezime,KorisnickoIme,Lozinka,TipKorisnika,Obrisan) 
VALUES ('Marija','Broceta','mara','mara123','Administrator',0)
INSERT INTO Korisnik(Ime,Prezime,KorisnickoIme,Lozinka,TipKorisnika,Obrisan) 
VALUES ('Janko','Jankovic','janko','janko123','Prodavac',0)

INSERT INTO AkcijskaProdaja(Naziv,Popust,DatumPocetka,DatumZavrsetka,Obrisan)
VALUES('Novogodisnja akcija',20,'2017-12-18','2017-12-26',0);
INSERT INTO AkcijskaProdaja(Naziv,Popust,DatumPocetka,DatumZavrsetka,Obrisan)
VALUES('Bozicna akcija',20,'2018-01-01','2018-01-09',0);

INSERT INTO NaAkciji(NamestajId,AkcijskaProdajaId,Obrisan)
VALUES(1,1,0)
INSERT INTO NaAkciji(NamestajId,AkcijskaProdajaId,Obrisan)
VALUES(2,2,0)
INSERT INTO NaAkciji(NamestajId,AkcijskaProdajaId,Obrisan)
VALUES(3,1,0)
INSERT INTO NaAkciji(NamestajId,AkcijskaProdajaId,Obrisan)
VALUES(4,2,0)

INSERT INTO ProdajaNamestaja(DatumProdaje,BrojRacuna,Kupac,UkupnaCenaBezPDV,UkupnaCenaSaPDV)
VALUES('2017-12-25','FTN1965','Pera Peric', 18999,20800)
INSERT INTO ProdajaNamestaja(DatumProdaje,BrojRacuna,Kupac,UkupnaCenaBezPDV,UkupnaCenaSaPDV)
VALUES('2017-12-25','FTN2065','Janko Jankovic', 18999,20800)

INSERT INTO StavkaProdaje(ProdajaNamestajaId,NamestajId,Kolicina,Cena,Obrisan)
VALUES(1,1,1,18999,0)

INSERT INTO StavkaProdaje(ProdajaNamestajaId,NamestajId,Kolicina,Cena,Obrisan)
VALUES(2,2,2,38000,0)

INSERT INTO ProdataUsluga(ProdajaNamestajaId,DodatnaUslugaId,Obrisan)
VALUES(1,3,0)

INSERT INTO Salon(Naziv,Adresa,Telefon,Email,WebSajt,PIB,JMBG,BrojZiroRacuna,Obrisan)
VALUES('FTNale','Trg Dositeja Obradovica 6','021/333-444','ftnale@uns.ac.rs','www.ftnale.rs',753159,'3004991805059','840-0007777-85',0)