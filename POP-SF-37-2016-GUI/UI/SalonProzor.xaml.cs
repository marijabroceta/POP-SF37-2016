using POP_37_2016.Model;
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
    /// Interaction logic for SalonProzor.xaml
    /// </summary>
    public partial class SalonProzor : Window
    {
        ICollectionView view;

        public Salon IzabraniSalon { get; set; }

        public SalonProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Salon);
            //view.Filter = PrikazFilter;

            dgSalon.IsSynchronizedWithCurrentItem = true;
            dgSalon.DataContext = this;
            dgSalon.ItemsSource = view;
        }

        private void DodajSalon_Click(object sender, RoutedEventArgs e)
        {
            var noviSalon = new Salon()
            {
                Naziv = "",
                Adresa = "",
                Telefon = "",
                Email = "",
                AdresaInternetSajta = "",
                PIB = 0,
                JMBG = "",
                BrojZiroRacuna = ""
            };

            var salonProzor = new SalonWindow(noviSalon, SalonWindow.Operacija.DODAVANJE);
            salonProzor.ShowDialog();
        }

        private void IzmeniSalon_Click(object sender, RoutedEventArgs e)
        {
            var kopija = (Salon)IzabraniSalon.Clone();
            var salonProzor = new SalonWindow(kopija, SalonWindow.Operacija.IZMENA);

            salonProzor.ShowDialog();
        }
    }
}
