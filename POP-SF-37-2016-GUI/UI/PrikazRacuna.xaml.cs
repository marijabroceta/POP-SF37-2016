using POP_37_2016.Model;
using POP_SF_37_2016_GUI.Model;
using System;
using System.Windows;

namespace POP_SF_37_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for PrikazRacuna.xaml
    /// </summary>
    public partial class PrikazRacuna : Window
    {
        public ProdajaNamestaja prodajaNamestaja;

        public PrikazRacuna(ProdajaNamestaja prodajaNamestaja)
        {
            InitializeComponent();

            this.prodajaNamestaja = prodajaNamestaja;
            tbRacun.Text = Racun();
        }

        public string Racun()
        {
            var prodavac = Korisnik.GetKorisnik(MainWindow.TrenutnoLogovan);
            var stavke = StavkaProdaje.GetAllId(prodajaNamestaja.Id);
            var usluge = ProdataUsluga.GetAllId(prodajaNamestaja.Id);
            var salon = Projekat.Instance.Salon;

            string tekst = "";
            string linija = new String('-', 55);

            tekst += linija + "\n";
            foreach (var s in salon)
            {
                tekst += "\t" + s.Naziv + "\n" +
                    "\t" + s.Adresa + "\n\n" +
                    "PIB:" + s.PIB + "\n" +
                    "Broj racuna:" + prodajaNamestaja.BrojRacuna + "\n" +
                    "" + linija + "\n";
            }
            foreach (var stavka in stavke)
            {
                tekst += "" + stavka.Namestaj.Naziv + "\n" +
                    "\t" + stavka.Kolicina + "x" + "\t";
                if (stavka.Namestaj.CenaNaAkciji > 0)
                {
                    tekst += "" + stavka.Namestaj.CenaNaAkciji + "\t\t" + stavka.Cena + "\n";
                }
                else
                {
                    tekst += "" + stavka.Namestaj.JedinicnaCena + "\t\t" + stavka.Cena + "\n";
                }
            }
            if (usluge != null)
            {
                foreach (var usluga in usluge)
                {
                    tekst += "" + usluga.DodatnaUsluga.Naziv + "\n" +
                       "\t" + "1x" + "\t" + usluga.DodatnaUsluga.Cena + "\t\t" + usluga.DodatnaUsluga.Cena + "\n";
                }
            }
            else
            {
                tekst += linija + "\n";
            }

            tekst += "" + linija + "\n";
            tekst += "PDV: " + 20 + "%" + "\n";
            tekst += "Ukupan iznos: " + prodajaNamestaja.UkupnaCenaBezPDV + " " + "RSD" + "\n";
            tekst += "Ukupan iznos sa PDV-om: " + prodajaNamestaja.UkupnaCenaSaPDV + " " + "RSD" + "\n";
            tekst += "Datum: " + prodajaNamestaja.DatumProdaje.ToShortDateString() + "\n";
            tekst += "Prodavac: " + prodavac.Ime + " " + prodavac.Prezime + "\n";
            tekst += linija;

            return tekst;
        }
    }
}