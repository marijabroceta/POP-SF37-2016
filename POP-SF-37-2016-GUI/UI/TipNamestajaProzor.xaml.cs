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
    /// Interaction logic for TipNamestajaProzor.xaml
    /// </summary>
    public partial class TipNamestajaProzor : Window
    {
        ICollectionView view;
        ICollectionView viewPretraga;

        public TipNamestaja IzabraniTipNamestaja { get; set; }

        public TipNamestajaProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamestaja);
            view.Filter = PrikazFilter;

            dgTipNamestaja.IsSynchronizedWithCurrentItem = true;
            dgTipNamestaja.DataContext = this;
            dgTipNamestaja.ItemsSource = view;

            


        }

        private bool PrikazFilter(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;
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
            try
            {
                TipNamestaja kopija = (TipNamestaja)IzabraniTipNamestaja.Clone();
                var tipNamestajaProzor = new TipNamestajaWindow(kopija, TipNamestajaWindow.Operacija.IZMENA);

                tipNamestajaProzor.Show();
            }
            catch
            {
                MessageBox.Show("Morate obeleziti red koji zelite da menjate", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            
        }

        private void ZatvoriTipProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ObrisiTipProzora_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Da li zelite da obrisete {IzabraniTipNamestaja.Naziv} ?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var tip in Projekat.Instance.TipoviNamestaja)
                {
                    if (tip.Id == IzabraniTipNamestaja.Id)
                    {
                        foreach (var n in Projekat.Instance.Namestaj)
                        {
                            if (tip.Id == n.TipNamestajaId)
                            {
                                TipNamestaja.Delete(IzabraniTipNamestaja);
                                Namestaj.Delete(n);
                                view.Refresh();
                            }

                        }
                        break;
                    }
                }                                                             
            }
        
        }

        private void PretragaTipNamestaja_Click(object sender, RoutedEventArgs e)
        {

            string naziv = tbPretraga.Text;
            viewPretraga = CollectionViewSource.GetDefaultView(TipNamestaja.PretragaTipNamestaja(naziv));
            dgTipNamestaja.ItemsSource = viewPretraga;
        }

        private void SortirajTip_Click(object sender, RoutedEventArgs e)
        {
            if(cbSortiraj.SelectedIndex == 0)
            {
                dgTipNamestaja.Items.SortDescriptions.Clear();
                
                dgTipNamestaja.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Descending));
                dgTipNamestaja.ItemsSource = view;
            }
            else if(cbSortiraj.SelectedIndex == 1)
            {
                dgTipNamestaja.Items.SortDescriptions.Clear();
                
                dgTipNamestaja.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Ascending));
                dgTipNamestaja.ItemsSource = view;
            }
        }
    }
}
