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
    /// Interaction logic for DodatneUslugeProzor.xaml
    /// </summary>
    public partial class DodatneUslugeProzor : Window
    {
        public DodatnaUsluga IzabranaUsluga { get; set; }
        public DodatneUslugeProzor()
        {
            InitializeComponent();

            dgUsluge.IsSynchronizedWithCurrentItem = true;
            dgUsluge.DataContext = this;
            dgUsluge.ItemsSource = Projekat.Instance.DodatnaUsluga;

            

        }

        

        private void DodajUslugu(object sender, RoutedEventArgs e)
        {
            var novaUsluga = new DodatnaUsluga()
            {
                Naziv = "",
                Cena = 0

            };
            var uslugaProzor = new DodatneUslugeWindow(novaUsluga, DodatneUslugeWindow.Operacija.DODAVANJE);
            uslugaProzor.ShowDialog();

            
        }

        private void IzmeniUslugu(object sender, RoutedEventArgs e)
        {
            var kopija = (DodatnaUsluga)IzabranaUsluga.Clone();
            var uslugaProzor = new DodatneUslugeWindow(kopija, DodatneUslugeWindow.Operacija.IZMENA);

            uslugaProzor.Show();


        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void ObrisiUslugu_Click(object sender, RoutedEventArgs e)
        {
            
            var listaUsluga = Projekat.Instance.DodatnaUsluga;

            if (MessageBox.Show($"Da li zelite da obrisete {IzabranaUsluga.Naziv} ?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var usluga in listaUsluga)
                {
                    if (usluga.Id == IzabranaUsluga.Id)
                    {
                        usluga.Obrisan = true;
                        break;
                    }
                }

                GenericSerializer.Serialize("dodatnaUsluga.xml", listaUsluga);
                
            }
        }
    }
}
