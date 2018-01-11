using POP_37_2016.Model;
using POP_SF_37_2016_GUI.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Data;

namespace POP_SF_37_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for AkcijaProzor.xaml
    /// </summary>
    public partial class AkcijaProzor : Window
    {
        private ICollectionView view;
        private ICollectionView viewPretraga;

        public AkcijskaProdaja IzabranaAkcija { get; set; }

        public AkcijaProzor()
        {
            InitializeComponent();

            view = CollectionViewSource.GetDefaultView(Projekat.Instance.AkcijskaProdaja);
            view.Filter = PrikazFilter;

            dgAkcija.IsSynchronizedWithCurrentItem = true;

            dgAkcija.DataContext = this;
            dgAkcija.ItemsSource = view;
        }

        private bool PrikazFilter(object obj)
        {
            return ((AkcijskaProdaja)obj).Obrisan == false;
        }

        private void DodajAkciju(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new AkcijskaProdaja()
            {
                Popust = 0,
                DatumPocetka = DateTime.Today,
                DatumZavrsetka = DateTime.Today,
                NamestajNaAkciji = new ObservableCollection<Namestaj>()
            };
            var akcijaProzor = new AkcijaWindow(novaAkcija, AkcijaWindow.Operacija.DODAVANJE);
            akcijaProzor.ShowDialog();
        }

        private void IzmeniAkciju(object sender, RoutedEventArgs e)
        {
            var kopija = (AkcijskaProdaja)IzabranaAkcija.Clone();
            var akcijaProzor = new AkcijaWindow(kopija, AkcijaWindow.Operacija.IZMENA);

            akcijaProzor.Show();
        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void ObrisiAkciju_Click(object sender, RoutedEventArgs e)
        {
            var listaNaAkciji = NaAkciji.GetAllId(IzabranaAkcija.Id);

            if (MessageBox.Show($"Da li zelite da obrisete {IzabranaAkcija.Naziv} ?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var akcija in listaNaAkciji)
                {
                    NaAkciji.Delete(akcija);
                }
                foreach (var akcija in Projekat.Instance.AkcijskaProdaja)
                {
                    if (akcija.Id == IzabranaAkcija.Id)
                    {
                        foreach (var n in Projekat.Instance.Namestaj)
                        {
                            if (akcija.Id == n.AkcijaId)
                            {
                                n.CenaNaAkciji = 0;
                                n.AkcijaId = 1;
                                Namestaj.Update(n);
                            }
                        }
                        AkcijskaProdaja.Delete(IzabranaAkcija);
                        view.Refresh();
                    }
                }
            }
        }

        private void PrikazNamestaja_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                var akcija = IzabranaAkcija;
                var prikazWindow = new PrikazNamestajaNaAkciji(IzabranaAkcija);

                prikazWindow.Show();
            }
            catch
            {
                MessageBox.Show("Morate obeleziti red koji zelite da menjate", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void PretraziAkciju_Click(object sender, RoutedEventArgs e)
        {
            if (cbPretraga.SelectedIndex == 0)
            {
                string naziv = tbPretraga.Text;
                viewPretraga = CollectionViewSource.GetDefaultView(AkcijskaProdaja.PretragaAkcije(naziv, AkcijskaProdaja.TipPretrage.NAZIV, null));
                dgAkcija.ItemsSource = viewPretraga;
            }
            else if (cbPretraga.SelectedIndex == 1)
            {
                tbPretraga.IsReadOnly = true;
                DateTime datumP = (DateTime)dpPretraga.SelectedDate;
                viewPretraga = CollectionViewSource.GetDefaultView(AkcijskaProdaja.PretragaAkcije("", AkcijskaProdaja.TipPretrage.DATUMP, datumP));
                dgAkcija.ItemsSource = viewPretraga;
            }
            else if (cbPretraga.SelectedIndex == 2)
            {
                tbPretraga.IsReadOnly = true;
                DateTime datumZ = (DateTime)dpPretraga.SelectedDate;
                viewPretraga = CollectionViewSource.GetDefaultView(AkcijskaProdaja.PretragaAkcije("", AkcijskaProdaja.TipPretrage.DATUMP, datumZ));
                dgAkcija.ItemsSource = viewPretraga;
            }
        }

        private void SortirajAkcije_Click(object sender, RoutedEventArgs e)
        {
            if (cbSortiranje.SelectedIndex == 0)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgAkcija.Items.SortDescriptions.Clear();
                    dgAkcija.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Descending));
                    dgAkcija.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgAkcija.Items.SortDescriptions.Clear();
                    dgAkcija.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Ascending));
                    dgAkcija.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 1)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgAkcija.Items.SortDescriptions.Clear();
                    dgAkcija.Items.SortDescriptions.Add(new SortDescription("DatumPocetka", ListSortDirection.Descending));
                    dgAkcija.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgAkcija.Items.SortDescriptions.Clear();
                    dgAkcija.Items.SortDescriptions.Add(new SortDescription("DatumPocetka", ListSortDirection.Ascending));
                    dgAkcija.ItemsSource = view;
                }
            }
            else if (cbSortiranje.SelectedIndex == 2)
            {
                if (cbSortiraj.SelectedIndex == 0)
                {
                    dgAkcija.Items.SortDescriptions.Clear();
                    dgAkcija.Items.SortDescriptions.Add(new SortDescription("DatumZavrsetka", ListSortDirection.Descending));
                    dgAkcija.ItemsSource = view;
                }
                else if (cbSortiraj.SelectedIndex == 1)
                {
                    dgAkcija.Items.SortDescriptions.Clear();
                    dgAkcija.Items.SortDescriptions.Add(new SortDescription("DatumZavrsetka", ListSortDirection.Ascending));
                    dgAkcija.ItemsSource = view;
                }
            }
        }
    }
}