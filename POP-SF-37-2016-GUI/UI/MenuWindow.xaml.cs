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
    /// Interaction logic for MenuWindow.xaml
    /// </summary>
    public partial class MenuWindow : Window
    {
        public MenuWindow()
        {
            InitializeComponent();
        }

        
        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Namestaj(object sender, RoutedEventArgs e)
        {
            var namestajProzor = new NamestajProzor();
            namestajProzor.Show();

        }

        private void TipNamestaja(object sender, RoutedEventArgs e)
        {
            var tipNamestajaProzor = new TipNamestajaProzor();
            tipNamestajaProzor.Show();
        }

        private void Korisnici(object sender, RoutedEventArgs e)
        {
            var korisnikProzor = new KorisnikProzor();
            korisnikProzor.Show();
        }

        private void Akcije(object sender, RoutedEventArgs e)
        {
            var akcijaProzor = new AkcijaProzor();
            akcijaProzor.Show();

        }

        private void DodatneUsluge(object sender, RoutedEventArgs e)
        {
            var uslugeProzor = new DodatneUslugeProzor();
            uslugeProzor.Show();
        }

        private void ProdajaNamestaja(object sender, RoutedEventArgs e)
        {
            var prodajaProzor = new ProdajaNamestajaProzor();
            prodajaProzor.Show();
        }





        /*
        private void Window_Activated(object sender, EventArgs e)
        {
            Console.WriteLine("Osvezio se prikaz za glavni prozorcic");
            OsveziPrikaz();
        }*/

    }
}
