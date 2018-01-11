using POP_37_2016.Model;
using POP_SF_37_2016_GUI.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF_37_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {
        ICollectionView view;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private AkcijskaProdaja akcija;

        public ObservableCollection<NaAkciji> listaObrisanih { get; set; } = new ObservableCollection<NaAkciji>();
        public ObservableCollection<NaAkciji> listaDodatih = new ObservableCollection<NaAkciji>();

        public AkcijaWindow(AkcijskaProdaja akcija, Operacija operacija)
        {
            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;

            

            akcija.NamestajAkcija = NaAkciji.GetAllId(akcija.Id);

            view = CollectionViewSource.GetDefaultView(akcija.NamestajAkcija);
            view.Filter = PrikazFilter;
            dgNamestajAkcija.ItemsSource = view;

            tbNaziv.DataContext = akcija;
            tbPopust.DataContext = akcija;
            dpPocetakAkcije.DataContext = akcija;
            dpZavrsetakAkcije.DataContext = akcija;
            dgNamestajAkcija.DataContext = akcija;
        }

        private bool PrikazFilter(object obj)
        {
            return !((NaAkciji)obj).Obrisan;
        }

        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            if (ForceValidation() == true)
            {
                return;
            }

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    AkcijskaProdaja.Create(akcija);

                    break;

                case Operacija.IZMENA:
                   

                    foreach (var dodaj in listaDodatih)
                    {
                        dodaj.AkcijskaProdajaId = akcija.Id;
                        NaAkciji.Create(dodaj);
                        
                    }
                    foreach (var item in listaObrisanih)
                    {
                        NaAkciji.Delete(item);
                    }
                    AkcijskaProdaja.Update(akcija);

                    break;
            }

            Close();
        }

        private void DodajNamestajAkcija_Click(object sender, RoutedEventArgs e)
        {
            NaAkciji naAkciji = new NaAkciji();
            AkcijaDodajNamestaj dodajWindow = new AkcijaDodajNamestaj(naAkciji, AkcijaDodajNamestaj.Operacija.DODAVANJE);
            dodajWindow.Show();

            dodajWindow.Closed += DodajWindow_Closed;
        }

        private void DodajWindow_Closed(object sender, EventArgs e)
        {
            var dodaj = sender as AkcijaDodajNamestaj;
            akcija.NamestajAkcija.Add((dodaj).NamestajAkcija);
            listaDodatih.Add((dodaj).NamestajAkcija);
        }

        private void ProveriDatum_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            if (akcija.DatumPocetka > akcija.DatumZavrsetka)
            {
                MessageBox.Show("Krajnji datum ne moze biti veci od pocetnog. ", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                akcija.DatumZavrsetka = akcija.DatumPocetka;
                return;
            }
        }

        private void ObrisiSaAkcije_Click(object sender, RoutedEventArgs e)
        {
            NaAkciji izabranaAkcija = dgNamestajAkcija.SelectedItem as NaAkciji;
            akcija.NamestajAkcija.Remove(izabranaAkcija);
            listaObrisanih.Add(izabranaAkcija);
        }

        private bool ForceValidation()
        {
            BindingExpression bindingExpression = tbNaziv.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();
            BindingExpression bindingExpression1 = tbPopust.GetBindingExpression(TextBox.TextProperty);
            bindingExpression1.UpdateSource();
            if (Validation.GetHasError(tbNaziv) == true || Validation.GetHasError(tbPopust))
            {
                return true;
            }
            return false;
        }
    }
}