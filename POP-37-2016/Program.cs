using POP_37_2016.Model;
using POP_37_2016.Util;
using System;
using System.Collections.Generic;

namespace POP_37_2016
{
    internal class Program
    {


        //private static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>();
        //private static List<TipNamestaja> TipoviNamestaja { get; set; } = new List<TipNamestaja>();

        private static void Main(string[] args)
        {
            var s1 = new Salon()
            {
                Id = 1,
                Naziv = "Forma FTNale",
                Adresa = "Trg Dositeja Obradovica ",
                BrojZiroRacuna = "840-0007777-85",
                Email = "kontakt@ftn.uns.ac.rs",
                AdresaInternetSajta = "www.nesto.rs",
                PIB = 458965,
                JMBG = "3004991805059",
                Telefon = "021/555-555"
            };
            /* var tn1 = new TipNamestaja()
             {
                 Id = 1,
                 Naziv = "Podna lampa"
             };
             var n1 = new Namestaj()
             {
                 Id = 1,
                 Naziv = "Socijalno osvetljenje",
                 Sifra = "S001",
                 JedinicnaCena = 1999,
                 KolicinaUMagacinu = 12,
                 TipNamestajaId = 1
             };

             var k1 = new Korisnik()
             {
                 Id = 1,
                 Ime = "Pera",
                 Prezime = "Peric",
                 //TipKorisnika = TipKorisnika.Prodavac


             };

             var ap1 = new AkcijskaProdaja()
             {
                 Id = 1,
                 Popust = 20

             };

             var du1 = new DodatnaUsluga()
             {
                 Id = 1,
                 NazivUsluge = "Montaza"
             };

             var pn1 = new ProdajaNamestaja()
             {
                 Id = 1,
                 BrojRacuna = "5"


             };

             /*
             var ln1 = new List<Namestaj>();
             ln1.Add(n1);

             var ln2 = new List<TipNamestaja>();
             ln2.Add(tn1);

             var lk1 = new List<Korisnik>();
             lk1.Add(k1);

             var lap1 = new List<AkcijskaProdaja>();
             lap1.Add(ap1);

             var ldu1 = new List<DodatnaUsluga>();
             ldu1.Add(du1);

             var lpn1 = new List<ProdajaNamestaja>();
             lpn1.Add(pn1);

             var ls1 = new List<Salon>();
             ls1.Add(s1);

             Console.WriteLine("Serializition....");
             GenericSerializer.Serialize<Namestaj>("namestaj.xml", ln1);
             GenericSerializer.Serialize<TipNamestaja>("tipNamestaja.xml", ln2);
             GenericSerializer.Serialize<Korisnik>("korisnici.xml", lk1);
             GenericSerializer.Serialize<AkcijskaProdaja>("akcijskaProdaja.xml", lap1);
             GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", ldu1);
             GenericSerializer.Serialize<ProdajaNamestaja>("prodajaNamestaja.xml", lpn1);
             GenericSerializer.Serialize<Salon>("salon.xml", ls1);

            
             //var namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");

             Console.WriteLine("Unesite naziv namestaja: ");
             string naziv = Console.ReadLine();

             Console.WriteLine("Unesite id");
             int idTipaNamestaja = int.Parse(Console.ReadLine());

             namestaj.Add(new Namestaj() { Id = 13, Naziv = naziv, TipNamestajaId = idTipaNamestaja });

             TipNamestaja trazeniTip = TipNamestaja.GetById(idTipaNamestaja);

             Projekat.Instance.Namestaj = namestaj;




             //List<Namestaj> ucitanaLista = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");


             Console.WriteLine("Finished");
             Console.ReadLine();
             */

            //PretragaPoTipuNamestaja();

            //Console.WriteLine($"***DOBRODOSLI U SALON NAMESTAJA {s1.Naziv}*** \n");
            //IspisGlavnogMenija();

            /*var lista = Projekat.Instance.Namestaj;
            //lista.RemoveAt(lista.Count -1)
            lista.Add(new Namestaj() { Id = 28, Naziv = "Remix knjaz" });
            Projekat.Instance.Namestaj = lista;

            foreach (var stavka in lista)
            {
                Console.WriteLine($"(stavka.Naziv)");
            }
            Console.ReadLine();

            var lista1 = Projekat.Instance.TipNamestaja;
            lista1.Add(new TipNamestaja() { Id = 12, Naziv = "Fotelja na razvlacenje" });
            Projekat.Instance.TipNamestaja = lista1;

            foreach (var stavka in lista1)
            {
                Console.WriteLine($"(stavka.Naziv)");
            }
            Console.ReadLine();

            var lista2 = Projekat.Instance.Korisnik;
            lista2.Add(new Korisnik() { Id = 12, Ime = "Pera" });
            Projekat.Instance.Korisnik = lista2;

            foreach (var stavka in lista2)
            {
                Console.WriteLine($"(stavka.Ime)");
            }
            Console.ReadLine();*/
            LogIn();
        }




        private static void IspisGlavnogMenija()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===GLAVNI MENI=== \n");
                Console.WriteLine(" 1 - Rad sa namestajem \n");
                Console.WriteLine(" 2 - Rad sa tipom namestaja \n");
                Console.WriteLine(" 3 - Rad sa korisnicima \n");
                Console.WriteLine(" 4 - Rad sa dodatnim uslugama \n");
                Console.WriteLine(" 5 - Rad sa prodajom namestaja \n");
                Console.WriteLine(" 6 - Rad sa akcijskim prodajama \n");
                Console.WriteLine(" 7 - Izlazak iz aplikacije \n");
                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 7);

            switch (izbor)
            {


                case 1:
                    IspisMeniNamestaja();
                    break;

                case 2:
                    IspisMeniTipNamestaja();
                    break;

                case 3:
                    IspisMeniKorisnika();
                    break;
                case 4:
                    IspisMeniDodatnihUsluga();
                    break;
                case 5:
                    IspisMeniProdajeNamestaja();
                    break;
                case 6:
                    IspisMeniAkcije();
                    break;
                case 7:
                    break;


                case 0:
                    IspisGlavnogMenija();
                    break;

                default:
                    break;
            }
        }

        private static void IspisMeniNamestaja()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===MENI NAMESTAJA=== \n");
                Console.WriteLine(" 1 - Izlistajte namestaj \n");
                Console.WriteLine(" 2 - Dodajte novi komad namestaja \n");
                Console.WriteLine(" 3 - Izmenite postojeci namestaj \n");
                Console.WriteLine(" 4 - Obrisite postojeci namestaj \n");
                Console.WriteLine(" 5 - Pretraga namestaja \n");


                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 5);

            switch (izbor)
            {


                case 1:
                    IzlistajNamestaj();
                    break;

                case 2:
                    DodavanjeNamestaja();
                    break;

                case 3:
                    IzmenaNamestaja();

                    break;

                case 4:
                    BrisanjeNamestaja();
                    break;
                case 5:
                    MeniPretrageNamestaja();
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;

                default:

                    break;
            }
        }

        private static void DodavanjeNamestaja()
        {
            Console.WriteLine("===DODAVANJE NAMESTAJA===");

            var listaNamestaja = Projekat.Instance.Namestaj;

            var komadNamestaja = new Namestaj();

            //Console.WriteLine("Unestite id:");
            komadNamestaja.Id = listaNamestaja.Count + 1;
            int idTipaNamestaja = 0;

            // komadNamestaja.Id = komadNamestaja.GetHashCode();

            Console.WriteLine("Unesite naziv: ");
            komadNamestaja.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite sifru: ");
            komadNamestaja.Sifra = Console.ReadLine();
            Console.WriteLine("Unesite cenu: ");
            komadNamestaja.JedinicnaCena = double.Parse(Console.ReadLine());
            Console.WriteLine("Koliko komada namestaja se nalazi u magacinu? : ");
            komadNamestaja.KolicinaUMagacinu = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite ID tipa namestaja: ");
            idTipaNamestaja = int.Parse(Console.ReadLine());

            var listaTipovaNamestaja = Projekat.Instance.TipNamestaja;
            TipNamestaja trazeniTipNamestaja;

            foreach (var tipNamestaja in listaTipovaNamestaja)
            {
                if (tipNamestaja.Id == idTipaNamestaja)
                {
                    trazeniTipNamestaja = tipNamestaja;
                    komadNamestaja.TipNamestajaId = idTipaNamestaja;

                }
            }

            /*   do
               {
                   Console.WriteLine("Unesite ID tipa namestaja: ");
                   idTipaNamestaja = int.Parse(Console.ReadLine());

                   foreach (var tipNamestaja in listaTipovaNamestaja)
                   {
                       if (tipNamestaja.Id == idTipaNamestaja)
                       {
                           trazeniTipNamestaja = tipNamestaja;
                       }
                   }
               } while (trazeniTipNamestaja == null);*/


            listaNamestaja.Add(komadNamestaja);
            GenericSerializer.Serialize<Namestaj>("namestaj.xml", listaNamestaja);


            IspisMeniNamestaja();

        }

        private static void IzlistajNamestaj()
        {
            Console.WriteLine("===IZLISTAVANJE NAMESTAJA===");
            var listaNamestaja = Projekat.Instance.Namestaj;
            for (int i = 0; i < listaNamestaja.Count; i++)
            {
                if (!listaNamestaja[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{listaNamestaja[i].Naziv},cena:{listaNamestaja[i].JedinicnaCena}, tip namestaja: {TipNamestaja.GetById(listaNamestaja[i].TipNamestajaId).Naziv}");
                }
            }
            IspisMeniNamestaja();
        }

        private static void IzmenaNamestaja()
        {
            Console.WriteLine("===IZMENA POSTOJECEG NAMESTAJA===");

            Namestaj trazeniNamestaj = null;
            int idTrazenogNamestaja = 0;
            var listaNamestaja = Projekat.Instance.Namestaj;

            do
            {
                Console.WriteLine("Unesite ID namestaja koji zelite da menjate :");
                idTrazenogNamestaja = int.Parse(Console.ReadLine());
                foreach (var namestaj in listaNamestaja)
                {
                    if (namestaj.Id == idTrazenogNamestaja)
                    {
                        trazeniNamestaj = namestaj;
                    }
                }
            } while (trazeniNamestaj == null);

            Console.WriteLine("Unesite novi naziv namestaja:  ");
            trazeniNamestaj.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite novu cenu: ");
            trazeniNamestaj.JedinicnaCena = int.Parse(Console.ReadLine());
            Console.WriteLine("Unesite novu kolicinu: ");
            trazeniNamestaj.KolicinaUMagacinu = int.Parse(Console.ReadLine());
            var listaTipovaNamestaja = Projekat.Instance.TipNamestaja;
            int idTipaNamestaja = 0;
            TipNamestaja trazeniTipNamestaja = null;

            do
            {
                Console.WriteLine("Unesite tip namestaja: ");
                idTipaNamestaja = int.Parse(Console.ReadLine());

                foreach (var tipNamestaja in listaTipovaNamestaja)
                {
                    if (tipNamestaja.Id == idTipaNamestaja)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);

            GenericSerializer.Serialize<Namestaj>("namestaj.xml", listaNamestaja);
            IspisMeniNamestaja();
        }

        private static void BrisanjeNamestaja()
        {
            Console.WriteLine("===BRISANJE NAMESTAJA===");
            Namestaj trazeniNamestaj = null;
            int idTrazenogNamestaja = 0;
            var listaNamestaja = Projekat.Instance.Namestaj;

            do
            {
                Console.WriteLine("Unesite ID namestaja koji zelite da brisete ");
                idTrazenogNamestaja = int.Parse(Console.ReadLine());

                foreach (var namestaj in listaNamestaja)
                {
                    if (namestaj.Id == idTrazenogNamestaja)
                    {
                        trazeniNamestaj = namestaj;
                        namestaj.Obrisan = true;
                    }
                }
            } while (trazeniNamestaj == null);


            GenericSerializer.Serialize<Namestaj>("namestaj.xml", listaNamestaja);
            IspisMeniNamestaja();



        }

        private static void IspisMeniTipNamestaja()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===MENI TIPA NAMESTAJA=== \n");
                Console.WriteLine(" 1 - Izlistajte tipove namestaja \n");
                Console.WriteLine(" 2 - Dodajte novi tip namestaja \n");
                Console.WriteLine(" 3 - Izmenite postojeci tip namestaj \n");
                Console.WriteLine(" 4 - Obrisite postojeci tip namestaj \n");

                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 4);

            switch (izbor)
            {


                case 1:
                    IzlistajTipoveNamestaja();
                    break;

                case 2:
                    DodavanjeTipaNamestaja();
                    break;

                case 3:
                    IzmenaTipaNamestaja();
                    break;

                case 4:
                    BrisanjeTipaNamestaja();
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;

                default:

                    break;
            }
        }
        private static void IzlistajTipoveNamestaja()
        {
            Console.WriteLine("===IZLISTAVANJE TIPA NAMESTAJA===");
            var listaTipovaNamestaja = Projekat.Instance.TipNamestaja;
            for (int i = 0; i < listaTipovaNamestaja.Count; i++)
            {
                if (!listaTipovaNamestaja[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{listaTipovaNamestaja[i].Naziv}");
                }
            }
            IspisMeniTipNamestaja();
        }
        private static void DodavanjeTipaNamestaja()
        {
            var listaTipovaNamestaja = Projekat.Instance.TipNamestaja;
            var noviTipNamestaja = new TipNamestaja();

            Console.WriteLine("===DODAVANJE TIPA NAMESTAJA===");

            noviTipNamestaja.Id = listaTipovaNamestaja.Count + 1;

            Console.WriteLine("Unesite naziv tipa namestaja: ");
            noviTipNamestaja.Naziv = Console.ReadLine();

            listaTipovaNamestaja.Add(noviTipNamestaja);
            GenericSerializer.Serialize<TipNamestaja>("tipNamestaja.xml", listaTipovaNamestaja);
            IspisMeniTipNamestaja();


        }

        private static void IzmenaTipaNamestaja()
        {
            Console.WriteLine("===IZMENA POSTOJECEG TIPA NAMESTAJA===");
            TipNamestaja trazeniTipNamestaja = null;
            int idTrazenogTipaNamestaja = 0;
            var listaTipovaNamestaja = Projekat.Instance.TipNamestaja;


            do
            {
                Console.WriteLine("Unesite ID tipa namestaja koji zelite da menjate : ");
                idTrazenogTipaNamestaja = int.Parse(Console.ReadLine());

                foreach (var tipNamestaja in listaTipovaNamestaja)
                {
                    if (tipNamestaja.Id == idTrazenogTipaNamestaja)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);

            Console.WriteLine("Unesite novi naziv tipa namestaja:  ");
            trazeniTipNamestaja.Naziv = Console.ReadLine();

            GenericSerializer.Serialize<TipNamestaja>("tipNamestaj.xml", listaTipovaNamestaja);

            IspisMeniTipNamestaja();
        }
        private static void BrisanjeTipaNamestaja()
        {
            Console.WriteLine("===BRISANJE TIPA NAMESTAJA===");

            TipNamestaja trazeniTip = null;
            var listaTipovaNamestaja = Projekat.Instance.TipNamestaja;
            int idTrazenogTipaNamestaja = 0;

            Console.WriteLine("Unesite ID  tipa namestaja koji zelite da brisete: ");
            idTrazenogTipaNamestaja = int.Parse(Console.ReadLine());
            foreach (var tipNamestaja in listaTipovaNamestaja)
            {
                if (tipNamestaja.Id == idTrazenogTipaNamestaja)
                {
                    trazeniTip = tipNamestaja;
                    tipNamestaja.Obrisan = true;
                }
            }

            GenericSerializer.Serialize<TipNamestaja>("tipNamestaja.xml", listaTipovaNamestaja);
            IzlistajTipoveNamestaja();

        }

        private static void IspisMeniKorisnika()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===MENI KORISNIKA=== \n");
                Console.WriteLine(" 1 - Izlistajte korisnike \n");
                Console.WriteLine(" 2 - Dodajte novog korisnika \n");
                Console.WriteLine(" 3 - Izmenite postojeceg korisnika \n");
                Console.WriteLine(" 4 - Obrisite postjeceg korisnika \n");
                Console.WriteLine(" 5 - Pretraga korisnika \n");

                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 5);

            switch (izbor)
            {


                case 1:
                    IzlistajKorisnike();
                    break;

                case 2:
                    DodavanjeKorisnika();
                    break;

                case 3:
                    IzmenaKorisnika();

                    break;

                case 4:
                    BrisanjeKorisnika();
                    break;
                case 5:
                    MeniPretragaKorisnika();
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;

                default:

                    break;
            }
        }
        private static void IzlistajKorisnike()
        {
            Console.WriteLine("===IZLISTAVANJE KORISNIKA===");
            var listaKorisnika = Projekat.Instance.Korisnik;
            for (int i = 0; i < listaKorisnika.Count; i++)
            {
                if (!listaKorisnika[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. Ime: {listaKorisnika[i].Ime},Prezime:{listaKorisnika[i].Prezime} ");
                }
            }

            IspisMeniKorisnika();

        }

        private static void DodavanjeKorisnika()
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            var noviKorisnik = new Korisnik();

            Console.WriteLine("===DODAVANJE NOVOG KORISNIKA===");

            noviKorisnik.Id = listaKorisnika.Count + 1;

            Console.WriteLine("Unesite ime: ");
            noviKorisnik.Ime = Console.ReadLine();
            Console.WriteLine("Unesite prezime: ");
            noviKorisnik.Prezime = Console.ReadLine();
            Console.WriteLine("Unesite korisnicko ime: ");
            noviKorisnik.KorisnickoIme = Console.ReadLine();
            Console.WriteLine("Unesite lozinku: ");
            noviKorisnik.Lozinka = Console.ReadLine();
            Console.WriteLine("Izaberite tip korisnika Administrator ili Prodavac: ");
            noviKorisnik.TipKorisnika = (TipKorisnika)Enum.Parse(typeof(TipKorisnika), Console.ReadLine());

            listaKorisnika.Add(noviKorisnik);
            GenericSerializer.Serialize<Korisnik>("korisnici.xml", listaKorisnika);
            IspisMeniKorisnika();

        }

        private static void IzmenaKorisnika()
        {
            Console.WriteLine("===IZMENA POSTOJECEG KORISNIKA===");
            var listaKorisnika = Projekat.Instance.Korisnik;
            Korisnik trazeniKorisnik = null;
            int idTrazenogKorisnika = 0;

            do
            {
                Console.WriteLine("Unesite ID korisnika koji zelite da menjate : ");
                idTrazenogKorisnika = int.Parse(Console.ReadLine());

                foreach (var korisnik in listaKorisnika)
                {
                    if (korisnik.Id == idTrazenogKorisnika)
                    {
                        trazeniKorisnik = korisnik;
                    }
                }
            } while (trazeniKorisnik == null);

            Console.WriteLine("Unesite novo ime:  ");
            trazeniKorisnik.Ime = Console.ReadLine();
            Console.WriteLine("Unesite novo prezime: ");
            trazeniKorisnik.Prezime = Console.ReadLine();
            Console.WriteLine("Unesite novo korisnicko ime: ");
            trazeniKorisnik.KorisnickoIme = Console.ReadLine();
            Console.WriteLine("Unesite novu lozinku: ");
            trazeniKorisnik.Lozinka = Console.ReadLine();


            GenericSerializer.Serialize<Korisnik>("korisnici.xml", listaKorisnika);
            IspisMeniKorisnika();
        }

        private static void BrisanjeKorisnika()
        {
            Console.WriteLine("===BRISANJE KORISNIKA===");

            Korisnik trazeniKorisnik = null;
            var listaKorisnika = Projekat.Instance.Korisnik;
            int idTrazenogKorisnika = 0;

            Console.WriteLine("Unesite ID korisnika koji zelite da brisete: ");
            idTrazenogKorisnika = int.Parse(Console.ReadLine());
            foreach (var korisnik in listaKorisnika)
            {
                if (korisnik.Id == idTrazenogKorisnika)
                {
                    trazeniKorisnik = korisnik;
                    korisnik.Obrisan = true;
                }
            }

            GenericSerializer.Serialize<Korisnik>("korisnici.xml", listaKorisnika);
            IspisMeniKorisnika();
        }

        private static void IspisMeniDodatnihUsluga()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===MENI DODATNE USLUGE=== \n");
                Console.WriteLine(" 1 - Izlistajte dodatne usluge \n");
                Console.WriteLine(" 2 - Dodajte novu dodatnu uslugu \n");
                Console.WriteLine(" 3 - Izmenite postojecu dodatnu uslugu \n");
                Console.WriteLine(" 4 - Obrisite postojecu dodatnu uslugu \n");

                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 4);

            switch (izbor)
            {


                case 1:
                    IzlistavanjeDodatnihUsluga();
                    break;

                case 2:
                    DodavanjeUsluge();
                    break;

                case 3:
                    IzmenaDodatnihUsluga();

                    break;

                case 4:
                    BrisanjeDodatneUsluge();
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;

                default:

                    break;
            }
        }

        public static void IzlistavanjeDodatnihUsluga()
        {
            Console.WriteLine("===IZLISTAVANJE DODATNIH USLUGA===");
            var listaUsluga = Projekat.Instance.DodatnaUsluga;
            for (int i = 0; i < listaUsluga.Count; i++)
            {
                if (!listaUsluga[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. Naziv: {listaUsluga[i].NazivUsluge},Cena:{listaUsluga[i].Cena} ");
                }
            }

            IspisMeniDodatnihUsluga();


        }
        public static void DodavanjeUsluge()
        {
            var listaUsluga = Projekat.Instance.DodatnaUsluga;
            var novaUsluga = new DodatnaUsluga();

            Console.WriteLine("===DODAVANJE DODATNIH USLUGA===");
            novaUsluga.Id = listaUsluga.Count + 1;

            Console.WriteLine("Unesite naziv usluge: ");
            novaUsluga.NazivUsluge = Console.ReadLine();
            Console.WriteLine("Unesite cenu usluge: ");
            novaUsluga.Cena = double.Parse(Console.ReadLine());

            listaUsluga.Add(novaUsluga);
            GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", listaUsluga);

            IspisMeniDodatnihUsluga();
        }

        public static void IzmenaDodatnihUsluga()
        {
            Console.WriteLine("===IZMENA POSTOJECIH DODATNIH USLUGA===");
            var listaUsluga = Projekat.Instance.DodatnaUsluga;


            DodatnaUsluga trazenaUsluga = null;
            int idTrazeneUsluge = 0;

            do
            {
                Console.WriteLine("Unesite ID korisnika koji zelite da menjate : ");
                idTrazeneUsluge = int.Parse(Console.ReadLine());

                foreach (var dodatnaUsluga in listaUsluga)
                {
                    if (dodatnaUsluga.Id == idTrazeneUsluge)
                    {
                        trazenaUsluga = dodatnaUsluga;
                    }
                }
            } while (trazenaUsluga == null);

            Console.WriteLine("Unesite novi naziv:  ");
            trazenaUsluga.NazivUsluge = Console.ReadLine();
            Console.WriteLine("Unesite novu cenu: ");
            trazenaUsluga.Cena = int.Parse(Console.ReadLine());


            GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", listaUsluga);

            IspisMeniDodatnihUsluga();
        }

        private static void BrisanjeDodatneUsluge()
        {
            Console.WriteLine("===BRISANJE DODATNE USLUGE===");

            DodatnaUsluga trazenaUsluga = null;
            var listaUsluga = Projekat.Instance.DodatnaUsluga;
            int idTrazeneUsluge = 0;

            Console.WriteLine("Unesite ID korisnika koji zelite da brisete: ");
            idTrazeneUsluge = int.Parse(Console.ReadLine());
            foreach (var dodatnaUsluga in listaUsluga)
            {
                if (dodatnaUsluga.Id == idTrazeneUsluge)
                {
                    trazenaUsluga = dodatnaUsluga;
                    dodatnaUsluga.Obrisan = true;
                }
            }

            GenericSerializer.Serialize<DodatnaUsluga>("dodatnaUsluga.xml", listaUsluga);
            IspisMeniDodatnihUsluga();


        }

        private static void IspisMeniProdajeNamestaja()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===MENI PRODAJE NAMESTAJA=== \n");
                Console.WriteLine(" 1 - Izlistajte prodaju namestaja \n");
                Console.WriteLine(" 2 - Dodajte novu prodaju namestaja \n");
                Console.WriteLine(" 3 - Izmenite postojecu prodaju namestaja \n");
                Console.WriteLine(" 4 - Pretraga prodaje namestaja \n");


                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 4);

            switch (izbor)
            {


                case 1:
                    IzlistavanjeProdajeNamestaja();
                    break;

                case 2:
                    DodavanjeProdajeNamestaja();
                    break;

                case 3:
                    IzmenaProdajeNamestaja();

                    break;
                case 4:
                    MeniPretrageProdajeNamestaja();
                    break;

                case 0:
                    IspisGlavnogMenija();
                    break;

                default:

                    break;
            }
        }
        private static void IzlistavanjeProdajeNamestaja()
        {
            Console.WriteLine("===IZLISTAVANJE PRODAJE NAMESTAJA===");
            var listaProdaje = Projekat.Instance.ProdajaNamestaja;
            for (int i = 0; i < listaProdaje.Count; i++)
            {
                Console.WriteLine($"{i + 1}. Datum: {listaProdaje[i].DatumProdaje}, Broj racuna: {listaProdaje[i].BrojRacuna}, Kupac: {listaProdaje[i].Kupac}, Ukupna cena: {listaProdaje[i].UkupnaCena} ");
            }
            IspisMeniProdajeNamestaja();
        }

        private static void DodavanjeProdajeNamestaja()
        {
            Console.WriteLine("===DODAVANJE PRODAJE NAMESTAJA===");
            var listaProdaje = Projekat.Instance.ProdajaNamestaja;
            var novaProdaja = new ProdajaNamestaja();
            // List<int> NamestajZaProdajuId = null;
            novaProdaja.Id = listaProdaje.Count + 1;

            //Console.WriteLine("Unesite ID namestaja za prodaju: ");

            novaProdaja.DatumProdaje = DateTime.Today;
            Console.WriteLine("Unesite broj racuna: ");
            novaProdaja.BrojRacuna = Console.ReadLine();
            Console.WriteLine("Unesite kupca: ");
            novaProdaja.Kupac = Console.ReadLine();
            //Console.WriteLine("Unesite ID za dodatnu uslugu ");
            //novaProdaja.DodatnaUslugaId = new List<int>();
            Console.WriteLine("Unesite cenu: ");
            novaProdaja.UkupnaCena = double.Parse(Console.ReadLine()) * ProdajaNamestaja.PDV;

            listaProdaje.Add(novaProdaja);
            GenericSerializer.Serialize<ProdajaNamestaja>("prodajaNamestaja.xml", listaProdaje);

            IspisMeniProdajeNamestaja();

        }

        private static void IzmenaProdajeNamestaja()
        {
            Console.WriteLine("===IZMENA PRODAJE NAMESTAJA===");
            var listaProdaje = Projekat.Instance.ProdajaNamestaja;
            ProdajaNamestaja trazenaProdaja = null;
            int idTrazeneProdaje = 0;

            do
            {
                Console.WriteLine("Unesite ID prodaje koju zelite da menjate : ");
                idTrazeneProdaje = int.Parse(Console.ReadLine());

                foreach (var prodajaNamestaja in listaProdaje)
                {
                    if (prodajaNamestaja.Id == idTrazeneProdaje)
                    {
                        trazenaProdaja = prodajaNamestaja;
                    }
                }
            } while (trazenaProdaja == null);

            //Console.WriteLine("Unesite novi ID namestaja za prodaju: ");
            //trazenaProdaja.NamestajZaProdajuId = new List<int>();
            Console.WriteLine("Unesite novi broj racuna:  ");
            trazenaProdaja.BrojRacuna = Console.ReadLine();
            Console.WriteLine("Unesite novog kupca: ");
            trazenaProdaja.Kupac = Console.ReadLine();
            //Console.WriteLine("Unesite novi ID za dodatne usluge: ");
            //trazenaProdaja.DodatnaUslugaId = new List<int>();
            Console.WriteLine("Unesite novu cenu: ");
            trazenaProdaja.UkupnaCena = double.Parse(Console.ReadLine()) * ProdajaNamestaja.PDV;


            GenericSerializer.Serialize<ProdajaNamestaja>("prodajaNamestaja.xml", listaProdaje);

            IspisMeniProdajeNamestaja();
        }

        private static void IspisMeniAkcije()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===MENI AKCIJE=== \n");
                Console.WriteLine(" 1 - Izlistajte akcije \n");
                Console.WriteLine(" 2 - Dodajte novu akciju \n");
                Console.WriteLine(" 3 - Izmenite postojecu akciju \n");
                Console.WriteLine(" 4 - Brisanje akcije \n");
                Console.WriteLine(" 5 - Prikaz trenutnih akcija \n");



                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 4);

            switch (izbor)
            {


                case 1:
                    IzlistajAkcije();
                    break;

                case 2:
                    DodavanjeAkcije();
                    break;

                case 3:
                    IzmenaAkcije();

                    break;
                case 4:
                    BrisanjeAkcije();
                    break;
                case 5:
                    //PrikazAktuelnihAkcija();
                    break;

                case 0:
                    IspisGlavnogMenija();
                    break;

                default:

                    break;
            }
        }
        private static void IzlistajAkcije()
        {
            Console.WriteLine("===IZLISTAVANJE AKCIJA===");
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;
            for (int i = 0; i < listaAkcija.Count; i++)
            {
                if (!listaAkcija[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}. Datum pocetka akcije: {listaAkcija[i].DatumPocetka}, Datum zavrsteka akcije: {listaAkcija[i].DatumZavrsetka}");
                }
            }
            IspisMeniAkcije();
        }

        private static void DodavanjeAkcije()
        {
            Console.WriteLine("===DODAVANJE AKCIJE===");
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;
            var novaAkcija = new AkcijskaProdaja();

            novaAkcija.Id = listaAkcija.Count + 1;

            Console.WriteLine("Unesite koliki je popust: ");
            novaAkcija.Popust = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Unesite datum pocetka akcije u formatu dd.MM.yyyy.: ");
            novaAkcija.DatumPocetka = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy.", null);
            Console.WriteLine("Unesite datum zavrsetka akcije u formatu dd.MM.yyyy. :");
            novaAkcija.DatumZavrsetka = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy.", null);

            listaAkcija.Add(novaAkcija);
            GenericSerializer.Serialize<AkcijskaProdaja>("akcijskaProdaja.xml", listaAkcija);

            IspisMeniAkcije();
        }

        private static void IzmenaAkcije()
        {
            Console.WriteLine("===IZMENA AKCIJE===");
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;
            AkcijskaProdaja trazenaAkcija = null;
            int idTrazeneAkcije = 0;

            do
            {
                Console.WriteLine("Unesite ID akcije koju zelite da menjate : ");
                idTrazeneAkcije = int.Parse(Console.ReadLine());

                foreach (var akcija in listaAkcija)
                {
                    if (akcija.Id == idTrazeneAkcije)
                    {
                        trazenaAkcija = akcija;
                    }
                }
            } while (trazenaAkcija == null);

            Console.WriteLine("Izmenite popust akcije: ");
            trazenaAkcija.Popust = decimal.Parse(Console.ReadLine());
            Console.WriteLine("Izmenite datum pocetka akcije: ");
            trazenaAkcija.DatumPocetka = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy.", null);
            Console.WriteLine("Izmenite datum zavrsetka acije: ");
            trazenaAkcija.DatumZavrsetka = DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy.", null);

            GenericSerializer.Serialize<AkcijskaProdaja>("akcijskaProdaja.xml", listaAkcija);

            IspisMeniAkcije();
        }

        private static void BrisanjeAkcije()
        {
            Console.WriteLine("===BRISANJE AKCIJE===");
            
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;
            //AkcijskaProdaja trazenaAkcija = null;
            foreach (var datum in listaAkcija)
            {
                if (DateTime.Today > datum.DatumZavrsetka)
                {
                    //trazenaAkcija = datum;
                    datum.Istekla = true;
                    Console.WriteLine("Akcija je obrisana");
                }
            }
            GenericSerializer.Serialize<AkcijskaProdaja>("akcijskaProdaja.xml", listaAkcija);

/*
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;

            AkcijskaProdaja trazenaAkcija = null;

            int idTrazeneAkcije = 0;

            Console.WriteLine("Unesite ID akcije koju zelite da brisete: ");
            idTrazeneAkcije = int.Parse(Console.ReadLine());
            foreach (var akcija in listaAkcija)
            {
                if (akcija.Id == idTrazeneAkcije)
                {
                    trazenaAkcija = akcija;
                    akcija.Obrisan = true;
                }
            }*/

            GenericSerializer.Serialize<AkcijskaProdaja>("akcijskaProdaja.xml", listaAkcija);

            IspisMeniAkcije();
        }

        private static void LogIn()
        {
            Console.WriteLine("===LOG IN===");
            var korisnici = Projekat.Instance.Korisnik;
            Console.WriteLine("Unesite korisnicko ime: ");
            var korisnickoIme = Console.ReadLine();
            Console.WriteLine("Unesite lozinku: ");
            var lozinka = Console.ReadLine();
            TipKorisnika tipKorisnika;

            foreach (var korisnik in korisnici)
            {
                if (!korisnik.Obrisan && korisnik.KorisnickoIme == korisnickoIme && korisnik.Lozinka == lozinka)
                {
                    tipKorisnika = korisnik.TipKorisnika;

                    switch (tipKorisnika)
                    {
                        case TipKorisnika.Administrator:
                            Console.WriteLine("ADMINISTRATOR");
                            break;
                        case TipKorisnika.Prodavac:
                            Console.WriteLine("PRODAVAC");
                            break;
                        default:
                            break;
                    }

                    Console.WriteLine($"***DOBRODOSLI U SALON NAMESTAJA*** \n");
                    IspisGlavnogMenija();
                }
                else
                {
                    LogIn();
                }


            }
        }

        private static void GlavniMeniPretrage()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===GLAVNI MENI PRETRAGE== \n");
                Console.WriteLine(" 1 - Pretraga namestaja  \n");
                Console.WriteLine(" 2 - Pretraga prodaje namestaja  \n");
                Console.WriteLine(" 3 - Pretraga korisnika \n");
                Console.WriteLine(" 4 - Pretraga akcija \n");


                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 3);

            switch (izbor)
            {


                case 1:
                    PretragaPoImenu();
                    break;
                case 2:
                    PretragaPoPrezimenu();
                    break;
                case 3:
                    PretragaPoKorisnickoImenu();
                    break;
                case 4:
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;

                default:

                    break;
            }
        }
        private static void MeniPretrageNamestaja()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===MENI PRETRAGE NAMESTAJA=== \n");
                Console.WriteLine(" 1 - Pretraga po tipu namestaja \n");
                Console.WriteLine(" 2 - Pretraga po sifri \n");
                Console.WriteLine(" 3 - Pretraga po nazivu \n");



                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 3);

            switch (izbor)
            {


                case 1:
                    PretragaPoTipuNamestaja();
                    break;

                case 2:
                    PretragaPoSifri();
                    break;

                case 3:
                    PretragaPoNazivu();

                    break;


                case 0:
                    IspisGlavnogMenija();
                    break;

                default:

                    break;
            }
        }

        private static void PretragaPoTipuNamestaja()
        {
            var listaNamestaja = Projekat.Instance.Namestaj;

            foreach (var namestaj in listaNamestaja)
            {
                Console.WriteLine("Unesite ID tipa namestaja: ");
                if (int.Parse(Console.ReadLine()) == namestaj.TipNamestajaId)
                {
                    for (int i = 0; i < listaNamestaja.Count; i++)
                    {
                        if (!listaNamestaja[i].Obrisan)
                        {
                            Console.WriteLine($"{i + 1}.{listaNamestaja[i].Naziv},cena:{listaNamestaja[i].JedinicnaCena}, tip namestaja: {TipNamestaja.GetById(listaNamestaja[i].TipNamestajaId).Naziv}");
                        }
                    }
                }
            }

            MeniPretrageNamestaja();


        }

        private static void PretragaPoSifri()
        {
            var listaNamestaja = Projekat.Instance.Namestaj;

            foreach (var namestaj in listaNamestaja)
            {
                Console.WriteLine("Unesite sifru namestaja: ");
                if (Console.ReadLine() == namestaj.Sifra)
                {
                    for (int i = 0; i < listaNamestaja.Count; i++)
                    {
                        if (!listaNamestaja[i].Obrisan)
                        {
                            Console.WriteLine($"{i + 1}.{listaNamestaja[i].Naziv},cena:{listaNamestaja[i].JedinicnaCena}, tip namestaja: {TipNamestaja.GetById(listaNamestaja[i].TipNamestajaId).Naziv}");
                        }
                    }
                }
            }
        }

        private static void PretragaPoNazivu()
        {
            var listaNamestaja = Projekat.Instance.Namestaj;

            foreach (var namestaj in listaNamestaja)
            {
                Console.WriteLine("Unesite naziv namestaja: ");
                if (Console.ReadLine() == namestaj.Naziv)
                {
                    for (int i = 0; i < listaNamestaja.Count; i++)
                    {
                        if (!listaNamestaja[i].Obrisan)
                        {
                            Console.WriteLine($"{i + 1}.{listaNamestaja[i].Naziv},cena:{listaNamestaja[i].JedinicnaCena}, tip namestaja: {TipNamestaja.GetById(listaNamestaja[i].TipNamestajaId).Naziv}");
                        }
                    }
                }

            }
        }

        private static void MeniPretrageProdajeNamestaja()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===MENI PRETRAGE NAMESTAJA=== \n");
                Console.WriteLine(" 1 - Pretraga po imenu ili prezimenu kupca \n");
                Console.WriteLine(" 2 - Pretraga po broju racuna \n");
                Console.WriteLine(" 3 - Pretraga po prodatom komadu namestaja \n");
                Console.WriteLine(" 4 - Pretraga po datumu prodaje  \n");




                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 3);

            switch (izbor)
            {


                case 1:

                    break;

                case 2:

                    break;

                case 3:


                    break;
                case 4:
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;

                default:

                    break;
            }
        }

        private static void PretragaPoKupcu()
        {
            var listaProdaje = Projekat.Instance.ProdajaNamestaja;
            foreach (var prodaja in listaProdaje)
            {
                Console.WriteLine("Unesite ime ili prezime kupca: ");
                if (Console.ReadLine() == prodaja.Kupac)
                {
                    for (int i = 0; i < listaProdaje.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Datum: {listaProdaje[i].DatumProdaje}, Broj racuna: {listaProdaje[i].BrojRacuna}, Kupac: {listaProdaje[i].Kupac}, Ukupna cena: {listaProdaje[i].UkupnaCena} ");
                    }
                }

            }

        }

        private static void PretragaPoBrojuRacuna()
        {
            var listaProdaje = Projekat.Instance.ProdajaNamestaja;
            foreach (var prodaja in listaProdaje)
            {
                Console.WriteLine("Unesite broj racuna: ");
                if (Console.ReadLine() == prodaja.BrojRacuna)
                {
                    for (int i = 0; i < listaProdaje.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Datum: {listaProdaje[i].DatumProdaje}, Broj racuna: {listaProdaje[i].BrojRacuna}, Kupac: {listaProdaje[i].Kupac}, Ukupna cena: {listaProdaje[i].UkupnaCena} ");
                    }
                }

            }
        }

        private static void PretragaPoDatumu()
        {
            var listaProdaje = Projekat.Instance.ProdajaNamestaja;
            foreach (var prodaja in listaProdaje)
            {
                Console.WriteLine("Unesite datum u formatu dd.MM.yyyy. : ");
                if (DateTime.ParseExact(Console.ReadLine(), "dd.MM.yyyy.", null) == prodaja.DatumProdaje)
                {
                    for (int i = 0; i < listaProdaje.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. Datum: {listaProdaje[i].DatumProdaje}, Broj racuna: {listaProdaje[i].BrojRacuna}, Kupac: {listaProdaje[i].Kupac}, Ukupna cena: {listaProdaje[i].UkupnaCena} ");
                    }
                }

            }
        }

        private static void MeniPretragaKorisnika()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===MENI PRETRAGE KORISNIKA=== \n");
                Console.WriteLine(" 1 - Pretraga po imenu  \n");
                Console.WriteLine(" 2 - Pretraga po prezimenu \n");
                Console.WriteLine(" 3 - Pretraga po korisnickom imenu \n");

                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 3);

            switch (izbor)
            {


                case 1:
                    PretragaPoImenu();
                    break;
                case 2:
                    PretragaPoPrezimenu();
                    break;
                case 3:
                    PretragaPoKorisnickoImenu();
                    break;
                case 0:
                    IspisGlavnogMenija();
                    break;

                default:

                    break;
            }
        }

        private static void PretragaPoImenu()
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            foreach (var korisnik in listaKorisnika)
            {
                Console.WriteLine("Unesite ime korisnika : ");
                if (Console.ReadLine() == korisnik.Ime)
                {
                    for (int i = 0; i < listaKorisnika.Count; i++)
                    {
                        if (!listaKorisnika[i].Obrisan)
                        {
                            Console.WriteLine($"{i + 1}. Ime: {listaKorisnika[i].Ime},Prezime:{listaKorisnika[i].Prezime}, Korisnicko ime: {listaKorisnika[i].KorisnickoIme} ");
                        }
                    }

                }

            }
        }

        private static void PretragaPoPrezimenu()
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            foreach (var korisnik in listaKorisnika)
            {
                Console.WriteLine("Unesite prezime korisnika : ");
                if (Console.ReadLine() == korisnik.Prezime)
                {

                    for (int i = 0; i < listaKorisnika.Count; i++)
                    {
                        if (!listaKorisnika[i].Obrisan)
                        {
                            Console.WriteLine($"{i + 1}. Ime: {listaKorisnika[i].Ime},Prezime:{listaKorisnika[i].Prezime}, Korisnicko ime: {listaKorisnika[i].KorisnickoIme} ");
                        }
                    }
                }

            }
        }

        private static void PretragaPoKorisnickoImenu()
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            foreach (var korisnik in listaKorisnika)
            {
                Console.WriteLine("Unesite korisnicko ime korisnika : ");
                if (Console.ReadLine() == korisnik.KorisnickoIme)
                {
                    for (int i = 0; i < listaKorisnika.Count; i++)
                    {
                        if (!listaKorisnika[i].Obrisan)
                        {
                            Console.WriteLine($"{i + 1}. Ime: {listaKorisnika[i].Ime},Prezime:{listaKorisnika[i].Prezime}, Korisnicko ime: {listaKorisnika[i].KorisnickoIme} ");
                        }
                    }
                }

            }
        }
        /*
        private static void PrikazAktuelnihAkcija()
        {
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;
            //AkcijskaProdaja trazenaAkcija = null;
            foreach (var datum in listaAkcija)
            {
                if (DateTime.Today < datum.DatumZavrsetka)
                {
                    for (int i = 0; i < listaAkcija.Count; i++)
                    {
                        if (!listaAkcija[i].Obrisan)
                        {
                            Console.WriteLine($"{i + 1}. Datum pocetka: {listaAkcija[i].DatumPocetka},datum zavrsetka:{listaAkcija[i].DatumZavrsetka}");
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Trenutno nema akcija");
                }
            }

        }*/
    }
}

