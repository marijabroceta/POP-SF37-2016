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
    /// Interaction logic for TipNamestajaProzor.xaml
    /// </summary>
    public partial class TipNamestajaProzor : Window
    {
        public TipNamestaja IzabraniTipNamestaja { get; set; }

        public TipNamestajaProzor()
        {
            InitializeComponent();

            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.ItemsSource = Projekat.Instance.TipNamestaja;

            


        }

        

        private void DodajTipNamestaja(object sender, RoutedEventArgs e)
        {
            var noviTipNamestaja = new TipNamestaja()
            {
                Naziv = ""
            };
            var tipNamestajaProzor = new TipNamestajaWindow(noviTipNamestaja, TipNamestajaWindow.Operacija.DODAVANJE);
            tipNamestajaProzor.ShowDialog();

            
        }

        private void IzmeniTipNamestaja(object sender, RoutedEventArgs e)
        {
            TipNamestaja kopija = (TipNamestaja)IzabraniTipNamestaja.Clone();
            var tipNamestajaProzor = new TipNamestajaWindow(kopija, TipNamestajaWindow.Operacija.IZMENA);

            tipNamestajaProzor.Show();
        }

        private void ZatvoriTipProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ObrisiTipProzora_Click(object sender, RoutedEventArgs e)
        {
            
            var listaTipaNamestaja = Projekat.Instance.TipNamestaja;

            if (MessageBox.Show($"Da li zelite da obrisete {IzabraniTipNamestaja.Naziv} ?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var tip in listaTipaNamestaja)
                {
                    if (tip.Id == IzabraniTipNamestaja.Id)
                    {
                        tip.Obrisan = true;
                        break;
                    }
                }

                GenericSerializer.Serialize("tipNamestaja.xml", listaTipaNamestaja);
               
            }
        }
    }
}
