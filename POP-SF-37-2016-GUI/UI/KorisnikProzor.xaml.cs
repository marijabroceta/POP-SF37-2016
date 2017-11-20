using POP_37_2016.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace POP_SF_37_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for KorisnikProzor.xaml
    /// </summary>
    public partial class KorisnikProzor : Window
    {
        public KorisnikProzor()
        {
            InitializeComponent();
            OsveziPrikaz();
        }

        public void OsveziPrikaz()
        {
            lbKorisnik.Items.Clear();

            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                if (korisnik.Obrisan == false)
                {
                    lbKorisnik.Items.Add(korisnik);
                }

            }
            lbKorisnik.SelectedIndex = 0;

        }

        private void DodajKorisnika(object sender, RoutedEventArgs e)
        {
            var noviKorisnik = new Korisnik()
            {
                Ime = "",
                Prezime = "",
                KorisnickoIme = "",
                Lozinka = "",
                TipKorisnika = TipKorisnika.Administrator
            };
            var korisnikProzor = new KorisnikWindow(noviKorisnik, KorisnikWindow.Operacija.DODAVANJE);
            korisnikProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void IzmeniKorisnika(object sender, RoutedEventArgs e)
        {
            var izabraniKorisnik = (Korisnik)lbKorisnik.SelectedItem;
            var korisnikProzor = new KorisnikWindow(izabraniKorisnik, KorisnikWindow.Operacija.IZMENA);

            korisnikProzor.Show();


        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void ObrisiKorisnika_Click(object sender, RoutedEventArgs e)
        {
            var izabraniKorisnik = (Korisnik)lbKorisnik.SelectedItem;
            var listaKorisnika = Projekat.Instance.Korisnik;

            if (MessageBox.Show($"Da li zelite da obrisete {izabraniKorisnik.Ime} {izabraniKorisnik.Prezime}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var korisnik in listaKorisnika)
                {
                    if (korisnik.Id == izabraniKorisnik.Id)
                    {
                        korisnik.Obrisan = true;
                    }
                }

                Projekat.Instance.Korisnik = listaKorisnika;
                OsveziPrikaz();
            }
        }

        private void ZatvoriProzor_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
