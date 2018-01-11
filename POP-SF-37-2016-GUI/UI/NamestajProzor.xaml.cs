using POP_37_2016.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Media;

namespace POP_SF_37_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for NamestajProzor.xaml
    /// </summary>
    public partial class NamestajProzor : Window
    {
        private ICollectionView view;
        private ICollectionView viewPretraga;

        public Namestaj IzabraniNamestaj { get; set; }

        public NamestajProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);

            view.Filter = PrikazFilter;

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = view;

            
        }

        private bool PrikazFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;
        }

        private void DodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                TipNamestajaId = 0,
                AkcijaId = 1,
                Naziv = "",
                KolicinaUMagacinu = 1,
                JedinicnaCena = 0,
                CenaNaAkciji = 0
            };
            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();
        }

        private void IzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                Namestaj kopija = (Namestaj)IzabraniNamestaj.Clone();
                var namestajProzor = new NamestajWindow(kopija, NamestajWindow.Operacija.IZMENA);

                namestajProzor.Show();
            }
            catch
            {
                MessageBox.Show("Morate obeleziti red koji zelite da menjate", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
           
        }

        private void ZatvoriProzor_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ObrisiNamstaj_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show($"Da li zelite da obrisete {IzabraniNamestaj.Naziv} ?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in Projekat.Instance.Namestaj)
                {
                    if (n.Id == IzabraniNamestaj.Id)
                    {
                        Namestaj.Delete(n);

                        view.Refresh();
                        break;
                    }
                }
            }
        }

        

        private void PretragaNamestaja_Click(object sender, RoutedEventArgs e)
        {
            if (cbPretraga.SelectedIndex == 0)
            {
                string naziv = tbPretraga.Text;
                viewPretraga = CollectionViewSource.GetDefaultView(Namestaj.PretragaNamestaja(naziv, Namestaj.TipPretrage.NAZIV));
                dgNamestaj.ItemsSource = viewPretraga;
            }
            else if (cbPretraga.SelectedIndex == 1)
            {
                string sifra = tbPretraga.Text;
                viewPretraga = CollectionViewSource.GetDefaultView(Namestaj.PretragaNamestaja(sifra, Namestaj.TipPretrage.SIFRA));
                dgNamestaj.ItemsSource = viewPretraga;
            }
            else if (cbPretraga.SelectedIndex == 2)
            {
                string tipNamestaja = tbPretraga.Text;
                viewPretraga = CollectionViewSource.GetDefaultView(Namestaj.PretragaNamestaja(tipNamestaja, Namestaj.TipPretrage.TIPNAMESTAJA));
                dgNamestaj.ItemsSource = viewPretraga;
            }
        }

        private void SortirajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            if (cbSortiranje.SelectedIndex == 0)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgNamestaj.Items.SortDescriptions.Clear();
                    //viewSort = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
                    dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Descending));
                    dgNamestaj.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgNamestaj.Items.SortDescriptions.Clear();
                    //viewSort = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
                    dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Ascending));
                    dgNamestaj.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 1)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgNamestaj.Items.SortDescriptions.Clear();
                    //viewSort = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
                    dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Sifra", ListSortDirection.Descending));
                    dgNamestaj.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgNamestaj.Items.SortDescriptions.Clear();
                    //viewSort = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
                    dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Sifra", ListSortDirection.Ascending));
                    dgNamestaj.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 2)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgNamestaj.Items.SortDescriptions.Clear();
                    //viewSort = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
                    dgNamestaj.Items.SortDescriptions.Add(new SortDescription("TipNamestaja", ListSortDirection.Descending));
                    dgNamestaj.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgNamestaj.Items.SortDescriptions.Clear();
                    //viewSort = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
                    dgNamestaj.Items.SortDescriptions.Add(new SortDescription("TipNamestaja", ListSortDirection.Ascending));
                    dgNamestaj.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 3)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgNamestaj.Items.SortDescriptions.Clear();
                    // viewSort = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
                    dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Cena", ListSortDirection.Descending));
                    dgNamestaj.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgNamestaj.Items.SortDescriptions.Clear();
                    //viewSort = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
                    dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Cena", ListSortDirection.Ascending));
                    dgNamestaj.ItemsSource = view;
                }
            }
        }

        private void dgNamestaj_LoadingRow(object sender, DataGridRowEventArgs e)
        {
            Namestaj n = e.Row.DataContext as Namestaj;

            if (n.AkcijaId > 1)
            {
                SolidColorBrush colorBrush = new SolidColorBrush(Color.FromRgb(103, 255, 0));
                e.Row.Background = colorBrush;
            }
            if (n.KolicinaUMagacinu == 0)
            {
                SolidColorBrush colorBrush = new SolidColorBrush(Color.FromRgb(255, 2, 1));
                e.Row.Background = colorBrush;
            }
        }

        private void Osvezi_Click(object sender, RoutedEventArgs e)
        {
            view.Refresh();
        }
    }
}