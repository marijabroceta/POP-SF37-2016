--seed.sql

INSERT INTO TipNamestaja (Naziv,Obrisan) VALUES ('Polica',0);
INSERT INTO TipNamestaja (Naziv,Obrisan) VALUES ('Regal',0);
INSERT INTO TipNamestaja (Naziv,Obrisan) VALUES ('Ugaona garnitura',0);
INSERT INTO TipNamestaja (Naziv,Obrisan) VALUES ('Krevet',0);

INSERT INTO Namestaj (TipNamestajaId,Naziv,Sifra,Cena,Kolicina,Obrisan)
VALUES (1,'Ultra polica','UL1PO', 123.5, 2, 0);
INSERT INTO Namestaj (TipNamestajaId,Naziv,Sifra,Cena,Kolicina,Obrisan)
VALUES (1,'Ultra regal','UL1PO', 124.5, 3, 0);
INSERT INTO Namestaj (TipNamestajaId,Naziv,Sifra,Cena,Kolicina,Obrisan)
VALUES (1,'Ultra ugaona','UL1PO', 126.5, 4, 0);
INSERT INTO Namestaj (TipNamestajaId,Naziv,Sifra,Cena,Kolicina,Obrisan)
VALUES (1,'Ultra krevet','UL1PO', 129.5, 5, 0);

INSERT INTO DodatnaUsluga(Naziv,Obrisan) VALUES ('Prevoz',0);
INSERT INTO DodatnaUsluga(Naziv,Obrisan) VALUES ('Montaza',0);
INSERT INTO DodatnaUsluga(Naziv,Obrisan) VALUES ('Pakovanje',0);


INSERT INTO Korisnik(Ime,Prezime,KorisnickoIme,Lozinka,TipKorisnika,Obrisan) 
VALUES ('Marija','Broceta','mara','mara123','Administrator',0)
INSERT INTO Korisnik(Ime,Prezime,KorisnickoIme,Lozinka,TipKorisnika,Obrisan) 
VALUES ('Janko','Jankovic','janko','janko123','Prodavac',0)


