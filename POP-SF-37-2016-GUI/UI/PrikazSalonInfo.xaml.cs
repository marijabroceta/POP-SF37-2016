using POP_37_2016.Model;
using System;
using System.Windows;

namespace POP_SF_37_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for PrikazSalonInfo.xaml
    /// </summary>
    public partial class PrikazSalonInfo : Window
    {
        public PrikazSalonInfo()
        {
            InitializeComponent();

            tbSalonInfo.Text = SalonInfo();
        }

        private string SalonInfo()
        {
            string tekst = "";
            string linija = new String('-', 44);

            foreach (var salon in Projekat.Instance.Salon)
            {
                tekst += linija +
                    "Naziv: " + salon.Naziv + "\n" +
                     linija + "\n" +
                "Adresa: " + salon.Adresa + "\n" +
                     linija + "\n" +
                "Kontakt elefon: " + salon.Telefon + "\n" +
                linija + "\n" +
                "Email: " + salon.Email + "\n" +
                linija + "\n" +
                "Sajt: " + salon.AdresaInternetSajta + "\n" +
                linija + "\n" +
                "PIB: " + salon.PIB.ToString() + "\n" +
                linija + "\n" +
                "Maticni broj: " + salon.JMBG + "\n" +
                linija + "\n" +
                "Ziro racun: " + salon.BrojZiroRacuna + "\n" +
                linija + "\n";
            }

            return tekst;
        }
    }
}