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
    /// Interaction logic for DodatneUslugeProzor.xaml
    /// </summary>
    public partial class DodatneUslugeProzor : Window
    {
        public DodatneUslugeProzor()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        public void OsveziPrikaz()
        {
            lbUsluge.Items.Clear();

            foreach (var usluge in Projekat.Instance.DodatnaUsluga)
            {
                if (usluge.Obrisan == false)
                {
                    lbUsluge.Items.Add(usluge);
                }

            }
            lbUsluge.SelectedIndex = 0;

        }

        private void DodajUslugu(object sender, RoutedEventArgs e)
        {
            var novaUsluga = new DodatnaUsluga()
            {
                NazivUsluge = "",
                Cena = 0

            };
            var uslugaProzor = new DodatneUslugeWindow(novaUsluga, DodatneUslugeWindow.Operacija.DODAVANJE);
            uslugaProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void IzmeniUslugu(object sender, RoutedEventArgs e)
        {
            var izabranaUsluga = (DodatnaUsluga)lbUsluge.SelectedItem;
            var uslugaProzor = new DodatneUslugeWindow(izabranaUsluga, DodatneUslugeWindow.Operacija.IZMENA);

            uslugaProzor.Show();


        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void ObrisiUslugu_Click(object sender, RoutedEventArgs e)
        {
            var izabranaUsluga = (DodatnaUsluga)lbUsluge.SelectedItem;
            var listaUsluga = Projekat.Instance.DodatnaUsluga;

            if (MessageBox.Show($"Da li zelite da obrisete {izabranaUsluga.NazivUsluge} ?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var usluga in listaUsluga)
                {
                    if (usluga.Id == izabranaUsluga.Id)
                    {
                        usluga.Obrisan = true;
                    }
                }

                Projekat.Instance.DodatnaUsluga = listaUsluga;
                OsveziPrikaz();
            }
        }
    }
}
