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
    /// Interaction logic for NamestajProzor.xaml
    /// </summary>
    public partial class NamestajProzor : Window
    {


        public Namestaj IzabraniNamestaj { get; set; }

        public NamestajProzor()
        {
            InitializeComponent();




            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = Projekat.Instance.Namestaj;
        }



        private void DodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();

        }

        private void IzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaj kopija = (Namestaj)IzabraniNamestaj.Clone();
            var namestajProzor = new NamestajWindow(kopija, NamestajWindow.Operacija.IZMENA);

            namestajProzor.Show();


        }

        private void ZatvoriProzor_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void ObrisiNamstaj_Click(object sender, RoutedEventArgs e)
        {

            var listaNamestaja = Projekat.Instance.Namestaj;

            if (MessageBox.Show($"Da li zelite da obrisete {IzabraniNamestaj.Naziv} ?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaNamestaja)
                {
                    if (n.Id == IzabraniNamestaj.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }
                }

                GenericSerializer.Serialize("namestaj.xml", listaNamestaja);

            }
        }

        private void NamestajProzor_OnLoaded(object sender, RoutedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgNamestaj.ItemsSource).Filter = NamestajFilter;
        }

        private bool NamestajFilter(object item)
        {
            if (String.IsNullOrEmpty(tbPretraga.Text))
                return true;

            var namestaj = (Namestaj)item;

            return (namestaj.Naziv.StartsWith(tbPretraga.Text, StringComparison.OrdinalIgnoreCase) || namestaj.Sifra.StartsWith(tbPretraga.Text, StringComparison.OrdinalIgnoreCase));
        }

        private void Pretraga_Changed(object sender, TextChangedEventArgs e)
        {
            CollectionViewSource.GetDefaultView(dgNamestaj.ItemsSource).Refresh();
        }

        private void Sortiraj_Click(object sender, RoutedEventArgs e)
        {
            ICollectionView view = CollectionViewSource.GetDefaultView(dgNamestaj.ItemsSource);
            if (cbSortiranje.SelectedIndex == 0)
            {
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Naziv", ListSortDirection.Ascending));
            }
            else if(cbSortiranje.SelectedIndex == 1)
            {
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("Sifra", ListSortDirection.Ascending));
            }
            else if(cbSortiranje.SelectedIndex == 2)
            {
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("TipNamestaja", ListSortDirection.Ascending));
            }
            else if(cbSortiranje.SelectedIndex == 3)
            {
                dgNamestaj.Items.SortDescriptions.Add(new SortDescription("JedinicnaCena", ListSortDirection.Ascending));
            }
        }
    }
}
