using POP_37_2016.Model;
using POP_37_2016.Util;
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
        public Korisnik IzabraniKorisnik { get; set; }
        public KorisnikProzor()
        {
            InitializeComponent();

            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.DataContext = this;
            dgKorisnik.ItemsSource = Projekat.Instance.Korisnik;

            

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

            
        }

        private void IzmeniKorisnika(object sender, RoutedEventArgs e)
        {
            var kopija = (Korisnik)IzabraniKorisnik.Clone();
            var korisnikProzor = new KorisnikWindow(kopija, KorisnikWindow.Operacija.IZMENA);

            korisnikProzor.Show();


        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void ObrisiKorisnika_Click(object sender, RoutedEventArgs e)
        {
           
            var listaKorisnika = Projekat.Instance.Korisnik;

            if (MessageBox.Show($"Da li zelite da obrisete {IzabraniKorisnik.Ime} {IzabraniKorisnik.Prezime}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var korisnik in listaKorisnika)
                {
                    if (korisnik.Id == IzabraniKorisnik.Id)
                    {
                        korisnik.Obrisan = true;
                        break;
                    }
                }

                GenericSerializer.Serialize("korisnici.xml", listaKorisnika);
                
            }
        }

        private void ZatvoriProzor_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
