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
    /// Interaction logic for ProdajaNamestajaProzor.xaml
    /// </summary>
    public partial class ProdajaNamestajaProzor : Window
    {
        public ProdajaNamestajaProzor()
        {
            InitializeComponent();
            OsveziPrikaz();
        }

        public void OsveziPrikaz()
        {
            lbProdajaNamestaja.Items.Clear();

            foreach (var prodaja in Projekat.Instance.ProdajaNamestaja)
            {
                lbProdajaNamestaja.Items.Add(prodaja);

            }
            lbProdajaNamestaja.SelectedIndex = 0;

        }

        private void DodajProdaju(object sender, RoutedEventArgs e)
        {
            var novaProdaja = new ProdajaNamestaja()
            {
                NamestajZaProdajuId = new List<int>(),
                DatumProdaje = DateTime.Today,
                BrojRacuna = "",
                Kupac = "",
                DodatnaUslugaId = new List<int>(),
                UkupnaCena = 0

            };
            var prodajaNamestajaProzor = new ProdajaNamestajaWindow(novaProdaja, ProdajaNamestajaWindow.Operacija.DODAVANJE);
            prodajaNamestajaProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void IzmeniProdaju(object sender, RoutedEventArgs e)
        {
            var izabranaProdaja = (ProdajaNamestaja)lbProdajaNamestaja.SelectedItem;
            var prodajaProzor = new ProdajaNamestajaWindow(izabranaProdaja, ProdajaNamestajaWindow.Operacija.IZMENA);

            prodajaProzor.Show();
        }

        private void ZatvoriProzor_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
