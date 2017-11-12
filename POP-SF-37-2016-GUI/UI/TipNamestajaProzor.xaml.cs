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
    /// Interaction logic for TipNamestajaProzor.xaml
    /// </summary>
    public partial class TipNamestajaProzor : Window
    {
        public TipNamestajaProzor()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        public void OsveziPrikaz()
        {
            lbTipNamestaja.Items.Clear();

            foreach (var tipNamestaja in Projekat.Instance.TipNamestaja)
            {
                lbTipNamestaja.Items.Add(tipNamestaja);

            }
            lbTipNamestaja.SelectedIndex = 0;

        }

        private void DodajTipNamestaja(object sender, RoutedEventArgs e)
        {
            var noviTipNamestaja = new TipNamestaja()
            {
                Naziv = ""
            };
            var tipNamestajaProzor = new TipNamestajaWindow(noviTipNamestaja, TipNamestajaWindow.Operacija.DODAVANJE);
            tipNamestajaProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void IzmeniTipNamestaja(object sender, RoutedEventArgs e)
        {
            var izabraniTipNamestaja = (TipNamestaja)lbTipNamestaja.SelectedItem;
            var tipNamestajaProzor = new TipNamestajaWindow(izabraniTipNamestaja, TipNamestajaWindow.Operacija.IZMENA);

            tipNamestajaProzor.Show();
        }

        private void ZatvoriTipProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
