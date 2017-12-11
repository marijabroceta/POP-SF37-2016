using POP_37_2016.Model;
using POP_SF_37_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
        public ProdajaNamestaja IzabranaProdaja { get; set; }
        
        public ProdajaNamestajaProzor()
        {
            InitializeComponent();

            dgProdajaNamestaja.IsSynchronizedWithCurrentItem = true;
            dgProdajaNamestaja.DataContext = this;
            dgProdajaNamestaja.ItemsSource = Projekat.Instance.ProdajaNamestaja;
            
        }
        

        private void DodajProdaju(object sender, RoutedEventArgs e)
        {
            var novaProdaja = new ProdajaNamestaja()
            {

                DatumProdaje = DateTime.Today,
                
                Kupac = "",
                
                //NamestajZaProdaju = new ObservableCollection<Namestaj>(),
                //DodatnaUslugaZaProdaju = new ObservableCollection<DodatnaUsluga>(),
                UkupnaCenaSaPDV = 0,
                UkupnaCenaBezPDV = 0

            };
            var prodajaNamestajaProzor = new ProdajaNamestajaWindow(novaProdaja, ProdajaNamestajaWindow.Operacija.DODAVANJE);
            prodajaNamestajaProzor.ShowDialog();

            
        }

        private void IzmeniProdaju(object sender, RoutedEventArgs e)
        {
            var kopija = (ProdajaNamestaja)IzabranaProdaja.Clone();
            var prodajaProzor = new ProdajaNamestajaWindow(kopija, ProdajaNamestajaWindow.Operacija.IZMENA);

            prodajaProzor.Show();
        }

        private void ZatvoriProzor_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
        /*
                private void OtvoriRacun_Click(object sender, RoutedEventArgs e)
                {
                    var izabranaUsluga = IzabranaProdaja.DodatnaUslugaZaProdaju;
                    var izabraniNamestaj = IzabranaProdaja.NamestajZaProdaju;
                    var prodajaN = IzabranaProdaja;
                    var prikazWindow = new PrikazProdatog(izabraniNamestaj,izabranaUsluga,IzabranaProdaja);

                    prikazWindow.Show();

                }*/

        private void OtvoriRacun_Click(object sender, RoutedEventArgs e)
        {
            /*
            var izabranaUsluga = IzabranaProdaja.DodatnaUslugaZaProdaju;
            var izabraniNamestaj = IzabranaProdaja.NamestajZaProdaju;
            var prodajaN = IzabranaProdaja;
            var prikazWindow = new PrikazProdatog(izabraniNamestaj, izabranaUsluga, IzabranaProdaja);

            prikazWindow.Show();*/

        }

       
    }
}
