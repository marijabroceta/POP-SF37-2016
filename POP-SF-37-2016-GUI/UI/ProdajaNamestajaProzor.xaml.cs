using POP_37_2016.Model;
using POP_SF_37_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for ProdajaNamestajaProzor.xaml
    /// </summary>
    public partial class ProdajaNamestajaProzor : Window
    {
        ICollectionView viewPretraga;
        ICollectionView view;
        public ProdajaNamestaja IzabranaProdaja { get; set; }
        
        public ProdajaNamestajaProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Prodaja);

            dgProdajaNamestaja.IsSynchronizedWithCurrentItem = true;
            dgProdajaNamestaja.DataContext = this;
            dgProdajaNamestaja.ItemsSource = view;
            
        }
        

        private void DodajProdaju(object sender, RoutedEventArgs e)
        {
            var novaProdaja = new ProdajaNamestaja()
            {

                DatumProdaje = DateTime.Today,
                Kupac = "",
                StavkeProdaje = new ObservableCollection<StavkaProdaje>(),
                ProdateUsluge = new ObservableCollection<ProdataUsluga>(),
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
        

        private void OtvoriRacun_Click(object sender, RoutedEventArgs e)
        {
            var prodajaN = IzabranaProdaja;
            var prikazWindow = new PrikazRacuna(IzabranaProdaja);

            prikazWindow.Show();
        }

        private void PretraziProdaju_Click(object sender, RoutedEventArgs e)
        {
            if(cbPretraga.SelectedIndex == 0)
            {
                string brojRacuna = tbPretraga.Text;
                viewPretraga = CollectionViewSource.GetDefaultView(ProdajaNamestaja.PretragaProdaje(brojRacuna, ProdajaNamestaja.TipPretrage.BROJRACUNA, null));
                dgProdajaNamestaja.ItemsSource = viewPretraga;
            }
            else if(cbPretraga.SelectedIndex == 1)
            {
                string kupac = tbPretraga.Text;
                viewPretraga = CollectionViewSource.GetDefaultView(ProdajaNamestaja.PretragaProdaje(kupac, ProdajaNamestaja.TipPretrage.KUPAC, null));
                dgProdajaNamestaja.ItemsSource = viewPretraga;
            }
            else if(cbPretraga.SelectedIndex == 2)
            {
                DateTime datumProdaje = (DateTime)dpPretraga.SelectedDate;
                viewPretraga = CollectionViewSource.GetDefaultView(ProdajaNamestaja.PretragaProdaje("", ProdajaNamestaja.TipPretrage.DATUM, datumProdaje));
                dgProdajaNamestaja.ItemsSource = viewPretraga;
            }
        }

        private void SortirajProdaju_Click(object sender, RoutedEventArgs e)
        {
            if (cbSortiranje.SelectedIndex == 0)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgProdajaNamestaja.Items.SortDescriptions.Clear();
                    dgProdajaNamestaja.Items.SortDescriptions.Add(new SortDescription("BrojRacuna", ListSortDirection.Descending));
                    dgProdajaNamestaja.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgProdajaNamestaja.Items.SortDescriptions.Clear();
                    dgProdajaNamestaja.Items.SortDescriptions.Add(new SortDescription("BrojRacuna", ListSortDirection.Ascending));
                    dgProdajaNamestaja.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 1)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgProdajaNamestaja.Items.SortDescriptions.Clear();
                    dgProdajaNamestaja.Items.SortDescriptions.Add(new SortDescription("Kupac", ListSortDirection.Descending));
                    dgProdajaNamestaja.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgProdajaNamestaja.Items.SortDescriptions.Clear();
                    dgProdajaNamestaja.Items.SortDescriptions.Add(new SortDescription("Kupac", ListSortDirection.Ascending));
                    dgProdajaNamestaja.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 2)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgProdajaNamestaja.Items.SortDescriptions.Clear();
                    dgProdajaNamestaja.Items.SortDescriptions.Add(new SortDescription("DatumProdaje", ListSortDirection.Descending));
                    dgProdajaNamestaja.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgProdajaNamestaja.Items.SortDescriptions.Clear();
                    dgProdajaNamestaja.Items.SortDescriptions.Add(new SortDescription("DatumProdaje", ListSortDirection.Ascending));
                    dgProdajaNamestaja.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 3)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgProdajaNamestaja.Items.SortDescriptions.Clear();
                    dgProdajaNamestaja.Items.SortDescriptions.Add(new SortDescription("UkupanIznosSaPDV", ListSortDirection.Descending));
                    dgProdajaNamestaja.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgProdajaNamestaja.Items.SortDescriptions.Clear();
                    dgProdajaNamestaja.Items.SortDescriptions.Add(new SortDescription("UkupanIznosSaPDV", ListSortDirection.Ascending));
                    dgProdajaNamestaja.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 4)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgProdajaNamestaja.Items.SortDescriptions.Clear();
                    dgProdajaNamestaja.Items.SortDescriptions.Add(new SortDescription("UkupanIznosBezPDV", ListSortDirection.Descending));
                    dgProdajaNamestaja.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgProdajaNamestaja.Items.SortDescriptions.Clear();
                    dgProdajaNamestaja.Items.SortDescriptions.Add(new SortDescription("UkupanIznosBezPDV", ListSortDirection.Ascending));
                    dgProdajaNamestaja.ItemsSource = view;
                }
            }
        }
    }
}
