﻿using POP_37_2016.Model;
using System;
using System.Collections.Generic;

namespace POP_37_2016
{
    internal class Program
    {
        private static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>();
        private static List<TipNamestaja> TipoviNamestaja { get; set; } = new List<TipNamestaja>();

        private static void Main(string[] args)
        {
            var s1 = new Salon()
            {
                Id = 1,
                Naziv = "FTNale",
                Adresa = "Trg Dositeja Obradovica ",
                BrojZiroRacuna = "840-0007777-85",
                Email = "kontakt@ftn.uns.ac.rs",
                AdresaInternetSajta = "www.nesto.rs",
                PIB = 458965,
                JMBG = "3004991805059",
                Telefon = "021/555-555"
            };
            var tn1 = new TipNamestaja()
            {
                Id = 1,
                Naziv = "Bracni"
            };
            var n1 = new Namestaj()
            {
                Id = 1,
                Naziv = "Krevet",
                Sifra = "K001",
                JedinicnaCena = 11999,
                KolicinaUMagacinu = 12,
                TipNamestaja = tn1
            };

            Namestaj.Add(n1);
            TipoviNamestaja.Add(tn1);

            Console.WriteLine($"***DOBRODOSLI U SALON NAMESTAJA {s1.Naziv}*** \n");
            IspisGlavnogMenija();
        }

        private static void IspisGlavnogMenija()
        {
            int izbor = 0;

            do
            {
                Console.WriteLine("===GLAVNI MENI=== \n");
                Console.WriteLine(" 1 - Rad sa namestajem \n");
                Console.WriteLine(" 2 - Rad sa tipom namestaja \n");
                Console.WriteLine(" 3 - Izlazak iz aplikacije \n");
                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 3);

            switch (izbor)
            {
                

                case 1:
                    IspisMeniNamestaja();
                    break;

                case 2:
                    IspisMeniTipNamestaja();
                    break;

                case 3:
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

                Console.WriteLine(" 0 - Povratak u glavni meni");

                izbor = int.Parse(Console.ReadLine());
            }
            while (izbor < 0 || izbor > 4);

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

            var komadNamestaja = new Namestaj();

            //Console.WriteLine("Unestite id:");
            komadNamestaja.Id = Namestaj.Count + 1;
            // komadNamestaja.Id = komadNamestaja.GetHashCode();

            Console.WriteLine("Unesite naziv: ");
            komadNamestaja.Naziv = Console.ReadLine();
            Console.WriteLine("Unesite sifru: ");
            komadNamestaja.Sifra = Console.ReadLine();
            Console.WriteLine("Unesite cenu: ");
            komadNamestaja.JedinicnaCena = double.Parse(Console.ReadLine());
            Console.WriteLine("Koliko komada namestaja se nalazi u magacinu? : ");
            komadNamestaja.KolicinaUMagacinu = int.Parse(Console.ReadLine());

            string nazivTipaNamestaja = "";
            TipNamestaja trazeniTipNamestaja = null;

            do
            {
                Console.WriteLine("Unesite tip namestaja: ");
                nazivTipaNamestaja = Console.ReadLine();

                foreach (var tipNamestaja in TipoviNamestaja)
                {
                    if (tipNamestaja.Naziv == nazivTipaNamestaja)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);

            komadNamestaja.TipNamestaja = trazeniTipNamestaja;
            Namestaj.Add(komadNamestaja);
            IspisMeniNamestaja();
            
        }

        private static void IzlistajNamestaj()
        {
            Console.WriteLine("===IZLISTAVANJE NAMESTAJA===");
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if (!Namestaj[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{Namestaj[i].Naziv},cena:{Namestaj[i].JedinicnaCena}, tip namestaja:{Namestaj[i].TipNamestaja.Naziv}");
                }
            }
            IspisMeniNamestaja();
        }

        private static void IzmenaNamestaja()
        {
            Console.WriteLine("===IZMENA POSTOJECEG NAMESTAJA===");
            Namestaj trazeniNamestaj = null;
            int idTrazenogNamestaja = 0;
            do
            {
                Console.WriteLine("Unesite ID namestaja koji zelite da menjate :");
                idTrazenogNamestaja = int.Parse(Console.ReadLine());
                foreach (var namestaj in Namestaj)
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

            string nazivTipaNamestaja = "";
            TipNamestaja trazeniTipNamestaja = null;

            do
            {
                Console.WriteLine("Unesite tip namestaja: ");
                nazivTipaNamestaja = Console.ReadLine();

                foreach (var tipNamestaja in TipoviNamestaja)
                {
                    if (tipNamestaja.Naziv == nazivTipaNamestaja)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);

            IspisMeniNamestaja();
        }

        private static void BrisanjeNamestaja()
        {
            Console.WriteLine("===BRISANJE NAMESTAJA===");
            
            
            int idTrazenogNamestaja = 0;
           
            Console.WriteLine("Unesite ID namestaja koji zelite da menjate ");
            idTrazenogNamestaja = int.Parse(Console.ReadLine());
            foreach (var namestaj in Namestaj)
            {
                if (namestaj.Id == idTrazenogNamestaja)
                {
                        namestaj.Obrisan = true;
                }
            }
            IzlistajNamestaj();

            

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
            for (int i = 0; i < TipoviNamestaja.Count; i++)
            {
                if (!TipoviNamestaja[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{TipoviNamestaja[i].Naziv}");
                }
            }
            IspisMeniTipNamestaja();
        }
        private static void DodavanjeTipaNamestaja()
        {
            var noviTipNamestaja = new TipNamestaja();

            Console.WriteLine("===DODAVANJE TIPA NAMESTAJA===");

            noviTipNamestaja.Id = TipoviNamestaja.Count + 1;

            Console.WriteLine("Unesite naziv tipa namestaja: ");
            noviTipNamestaja.Naziv = Console.ReadLine();

            TipoviNamestaja.Add(noviTipNamestaja);
            IspisMeniTipNamestaja();


        }

        private static void IzmenaTipaNamestaja()
        {
            Console.WriteLine("===IZMENA POSTOJECEG TIPA NAMESTAJA===");
            TipNamestaja trazeniTipNamestaja = null;
            int idTrazenogTipaNamestaja = 0;
            

            do
            {
                Console.WriteLine("Unesite ID tipa namestaja koji zelite da menjate : ");
                idTrazenogTipaNamestaja = int.Parse(Console.ReadLine());

                foreach (var tipNamestaja in TipoviNamestaja)
                {
                    if (tipNamestaja.Id == idTrazenogTipaNamestaja)
                    {
                        trazeniTipNamestaja = tipNamestaja;
                    }
                }
            } while (trazeniTipNamestaja == null);

            Console.WriteLine("Unesite novi naziv tipa namestaja:  ");
            trazeniTipNamestaja.Naziv = Console.ReadLine();

            IspisMeniTipNamestaja();
        }

        private static void BrisanjeTipaNamestaja()
        {
            Console.WriteLine("===BRISANJE TIPA NAMESTAJA===");

            int idTrazenogTipaNamestaja = 0;

            Console.WriteLine("Unesite ID  tipa namestaja koji zelite da menjate ");
            idTrazenogTipaNamestaja = int.Parse(Console.ReadLine());
            foreach (var tipNamestaja in Namestaj)
            {
                if (tipNamestaja.Id == idTrazenogTipaNamestaja)
                {
                    tipNamestaja.Obrisan = true;
                }
            }
            IzlistajTipoveNamestaja();

        }
    }
}

