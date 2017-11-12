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
    /// Interaction logic for NamestajProzor.xaml
    /// </summary>
    public partial class NamestajProzor : Window
    {
        public NamestajProzor()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        public void OsveziPrikaz()
        {
            lbNamestaj.Items.Clear();

            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                lbNamestaj.Items.Add(namestaj);

            }
            lbNamestaj.SelectedIndex = 0;

        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();

            OsveziPrikaz();


        }
        
        private void IzmeniNamestaj(object sender, RoutedEventArgs e)
        {
            var izabraniNamestaj =(Namestaj) lbNamestaj.SelectedItem;
            var namestajProzor = new NamestajWindow(izabraniNamestaj, NamestajWindow.Operacija.IZMENA);
            
            namestajProzor.Show();

            
        }
        
        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {

            this.Close();
        }
        
    }
}
