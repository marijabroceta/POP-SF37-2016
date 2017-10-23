using POP_37_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_37_2016
{
    class Program
    {
        static List<Namestaj> Namestaj { get; set; } = new List<Namestaj>();
        static List<TipNamestaja> TipoviNamestaja { get; set; } = new List<TipNamestaja>();

        static void Main(string[] args)
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

            
            Console.WriteLine("Dobrodosli u salon nameštaja.");
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

            switch(izbor)
            {
                case 0:
                    IspisGlavnogMenija();
                    break;
                case 1:
                    IspisMeniNamestaja();
                    break;
                case 2:
                    break;
                case 3:
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

                
                
                switch(izbor)
                {
                    case 0:
                        IspisMeniNamestaja();
                        break;
                    case 1:
                    IzlistajNamestaj();
                        break;
                    case 2:
                    DodavanjeNamestaja();
                    break;
                    case 3:
                    Izmena
                    
                        break;
                    case 4:
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
                //komadNamestaja.Id = Namestaj.Count + 1;
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
                string tipoviNamestaja = Console.ReadLine();

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
                foreach (Namestaj n in Namestaj)
                {
                    Console.WriteLine(n.Id);
                    Console.WriteLine(n.Naziv);
                    Console.WriteLine(n.Sifra);
                    Console.WriteLine(n.JedinicnaCena);
                    Console.WriteLine(n.KolicinaUMagacinu);
                    Console.WriteLine(n.TipNamestaja);
                    
                    Console.ReadLine();
                }

                



            



            }
        private static void IzlistajNamestaj()
        {
            Console.WriteLine("===IZLISTAVANJE NAMESTAJA===");
            for (int i = 0; i < Namestaj.Count; i++)
            {
                if(!Namestaj[i].Obrisan)
                {
                    Console.WriteLine($"{i + 1}.{Namestaj[i].Naziv},cena:{Namestaj[i].JedinicnaCena}, tip namestaja:{Namestaj[i].TipNamestaja}");
                }
                
            }
            IspisMeniNamestaja();

        }

        private static void IzmenaNamestaja()
        {
            Console.WriteLine("===IZMENA POSTOJECEG NAMESTAJA===");
            Namestaj trazeniNamestaj = null;
            string nazivTrazenogNamestaja = "";
            do
            {
                Console.WriteLine("Unesite naziv namestaja koji zelite da menjate ");
                nazivTrazenogNamestaja = Console.ReadLine();
                foreach (var namestaj in Namestaj)
                {
                    if (namestaj.Naziv == nazivTrazenogNamestaja)
                    {
                        trazeniNamestaj = namestaj;

                    }

                }




            } while (trazeniNamestaj == null);
            Console.WriteLine("Unesite novi naziv namestaja:  ");
            trazeniNamestaj.Naziv = Console.ReadLine();

            
            Console.WriteLine("Unesite novu cenu: ");
            Console.WriteLine("Unesite novu kolicinu: ");
            Console.WriteLine("Unesite novi tip namestaja");

            IspisMeniNamestaja();


        }

        private static void BrisanjeNamestaja()
        {
            
        }
            
        
        
    }
}
