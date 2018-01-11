using POP_37_2016.Model;
using POP_37_2016.Util;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

        ICollectionView view;
        ICollectionView viewPretraga;

        public Korisnik IzabraniKorisnik { get; set; }
        public KorisnikProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Korisnici);

            view.Filter = PrikazFilter;

            dgKorisnik.IsSynchronizedWithCurrentItem = true;
            dgKorisnik.DataContext = this;
            dgKorisnik.ItemsSource = view;

            

        }

        private bool PrikazFilter(object obj)
        {
            return !((Korisnik)obj).Obrisan;
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
            try
            {
                var kopija = (Korisnik)IzabraniKorisnik.Clone();
                var korisnikProzor = new KorisnikWindow(kopija, KorisnikWindow.Operacija.IZMENA);

                korisnikProzor.Show();
            }
            catch
            {
                MessageBox.Show("Morate obeleziti red koji zelite da menjate", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            


        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void ObrisiKorisnika_Click(object sender, RoutedEventArgs e)
        {
           
            var listaKorisnika = Projekat.Instance.Korisnici;

            if (MessageBox.Show($"Da li zelite da obrisete {IzabraniKorisnik.Ime} {IzabraniKorisnik.Prezime}?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var korisnik in listaKorisnika)
                {
                    if (korisnik.Id == IzabraniKorisnik.Id)
                    {
                        Korisnik.Delete(korisnik);
                        view.Refresh();
                        break;
                    }
                }              
                
            }
        }

        private void ZatvoriProzor_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void PretraziKorisnika_Click(object sender, RoutedEventArgs e)
        {
            if(cbPretraga.SelectedIndex == 0)
            {
                string ime = tbPretraga.Text;
                viewPretraga = CollectionViewSource.GetDefaultView(Korisnik.PretragaKorisnika(ime, Korisnik.TipPretrage.IME));
                dgKorisnik.ItemsSource = viewPretraga;
            }
            else if(cbPretraga.SelectedIndex == 1)
            {
                string prezime = tbPretraga.Text;
                viewPretraga = CollectionViewSource.GetDefaultView(Korisnik.PretragaKorisnika(prezime, Korisnik.TipPretrage.PREZIME));
                dgKorisnik.ItemsSource = viewPretraga;
            }
            else if (cbPretraga.SelectedIndex == 2)
            {
                string korisnickoIme = tbPretraga.Text;
                viewPretraga = CollectionViewSource.GetDefaultView(Korisnik.PretragaKorisnika(korisnickoIme, Korisnik.TipPretrage.KORISNICKOIME));
                dgKorisnik.ItemsSource = viewPretraga;
            }

        }

        private void SortirajKorisnika_Click(object sender, RoutedEventArgs e)
        {
            if (cbSortiranje.SelectedIndex == 0)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgKorisnik.Items.SortDescriptions.Clear();
                    dgKorisnik.Items.SortDescriptions.Add(new SortDescription("Ime", ListSortDirection.Descending));
                    dgKorisnik.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgKorisnik.Items.SortDescriptions.Clear();
                    dgKorisnik.Items.SortDescriptions.Add(new SortDescription("Ime", ListSortDirection.Ascending));
                    dgKorisnik.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 1)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgKorisnik.Items.SortDescriptions.Clear();
                    dgKorisnik.Items.SortDescriptions.Add(new SortDescription("Prezime", ListSortDirection.Descending));
                    dgKorisnik.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgKorisnik.Items.SortDescriptions.Clear();
                    dgKorisnik.Items.SortDescriptions.Add(new SortDescription("Prezime", ListSortDirection.Ascending));
                    dgKorisnik.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 2)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgKorisnik.Items.SortDescriptions.Clear();
                    dgKorisnik.Items.SortDescriptions.Add(new SortDescription("KorisnickoIme", ListSortDirection.Descending));
                    dgKorisnik.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgKorisnik.Items.SortDescriptions.Clear();
                    dgKorisnik.Items.SortDescriptions.Add(new SortDescription("KorisnickoIme", ListSortDirection.Ascending));
                    dgKorisnik.ItemsSource = view;
                }
            }
        }
    }
}
