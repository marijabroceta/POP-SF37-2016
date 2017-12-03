using POP_37_2016.Model;
using POP_37_2016.Util;
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
    /// Interaction logic for AkcijaProzor.xaml
    /// </summary>
    public partial class AkcijaProzor : Window
    {
        ICollectionView view;

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
                NamestajNaAkcijiId = new ObservableCollection<int>()

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

            var listaAkcija = Projekat.Instance.AkcijskaProdaja;

            if (MessageBox.Show($"Da li zelite da obrisete {IzabranaAkcija.DatumPocetka} ?", "Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var akcija in listaAkcija)
                {
                    if (akcija.Id == IzabranaAkcija.Id)
                    {
                        akcija.Obrisan = true;
                        view.Refresh();
                        break;
                    }
                }

                GenericSerializer.Serialize("akcijskaProdaja.xml", listaAkcija);

            }
        }

        /*
        private void AutomatskoBrisanje()
        {
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;

            AkcijskaProdaja trazenaAkcija = null;
            foreach (var akcija in listaAkcija)
            {
                if (DateTime.Today > akcija.DatumZavrsetka)
                {
                    trazenaAkcija = akcija;
                    akcija.Obrisan = true;

                }
            }
            GenericSerializer.Serialize("akcijskaProdaja.xml", listaAkcija);
            
        } */



    }
}
