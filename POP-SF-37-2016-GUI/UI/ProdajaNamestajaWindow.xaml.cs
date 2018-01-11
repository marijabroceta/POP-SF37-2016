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
    /// Interaction logic for ProdajaNamestajaWindow.xaml
    /// </summary>
    public partial class ProdajaNamestajaWindow : Window
    {
        private ICollectionView viewStavka;
        private ICollectionView viewUsluga;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private ProdajaNamestaja prodajaNamestaja;
        private ObservableCollection<StavkaProdaje> ListaDodatihStavki { get; set; } = new ObservableCollection<StavkaProdaje>();
        private ObservableCollection<ProdataUsluga> ListaDodatihUsluga { get; set; } = new ObservableCollection<ProdataUsluga>();
        private ObservableCollection<StavkaProdaje> ListaObrisanihStavki { get; set; } = new ObservableCollection<StavkaProdaje>();
        private ObservableCollection<ProdataUsluga> ListaObrisanihUsluga { get; set; } = new ObservableCollection<ProdataUsluga>();

        public ProdajaNamestajaWindow(ProdajaNamestaja prodajaNamestaja, Operacija operacija)
        {
            InitializeComponent();

            prodajaNamestaja.StavkeProdaje = StavkaProdaje.GetAllId(prodajaNamestaja.Id);
            prodajaNamestaja.ProdateUsluge = ProdataUsluga.GetAllId(prodajaNamestaja.Id);

            viewStavka = CollectionViewSource.GetDefaultView(prodajaNamestaja.StavkeProdaje);
            viewUsluga = CollectionViewSource.GetDefaultView(prodajaNamestaja.ProdateUsluge);
            viewStavka.Filter = PrikazFilterStavka;
            viewUsluga.Filter = PrikazFilterUsluga;

            this.prodajaNamestaja = prodajaNamestaja;
            this.operacija = operacija;

            dgDodatnaUsluga.ItemsSource = viewUsluga;
            dgIdNamestaja.ItemsSource = viewStavka;

            dpDatumProdaje.DataContext = prodajaNamestaja;
            tbKupac.DataContext = prodajaNamestaja;
            dgIdNamestaja.DataContext = prodajaNamestaja;
            dgDodatnaUsluga.DataContext = prodajaNamestaja;
            lblUkupnaCenaSaPDV.DataContext = prodajaNamestaja;
            lblUkupnaCenaBezPDV.DataContext = prodajaNamestaja;
        }

        private bool PrikazFilterStavka(object obj)
        {
            return !((StavkaProdaje)obj).Obrisan;
        }

        private bool PrikazFilterUsluga(object obj)
        {
            return !((ProdataUsluga)obj).Obrisan;
        }

        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            if(ForceValidation() == true)
            {
                return;
            }

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    Random random = new Random();
                    prodajaNamestaja.BrojRacuna = "FTN" + random.Next(10, 99999) + DateTime.Today.ToString("ddMMyyyy");
                    ProdajaNamestaja.Create(prodajaNamestaja);

                    break;

                case Operacija.IZMENA:
                    foreach (var stavkaD in ListaDodatihStavki)
                    {
                        stavkaD.ProdajaNamestajaId = prodajaNamestaja.Id;
                        StavkaProdaje.Create(stavkaD);
                    }

                    foreach (var uslugaD in ListaDodatihUsluga)
                    {
                        uslugaD.ProdajaNamestajaId = prodajaNamestaja.Id;
                        ProdataUsluga.Create(uslugaD);
                    }

                    foreach (var stavkaO in ListaObrisanihStavki)
                    {
                        StavkaProdaje.Delete(stavkaO);
                    }
                    foreach (var uslugaO in ListaObrisanihUsluga)
                    {
                        ProdataUsluga.Delete(uslugaO);
                    }
                    ProdajaNamestaja.Update(prodajaNamestaja);

                    break;
            }

            Close();
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            StavkaProdaje stavka = new StavkaProdaje();

            DodajStavkuWindow dodajWindow = new DodajStavkuWindow(stavka, DodajStavkuWindow.Operacija.DODAVANJE);
            dodajWindow.Show();
            dodajWindow.Closed += DodajWindow_Closed;
        }

        private void DodajWindow_Closed(object sender, EventArgs e)
        {
            var dodaj = sender as DodajStavkuWindow;
            prodajaNamestaja.StavkeProdaje.Add((dodaj).StavkaProdaje);
            ListaDodatihStavki.Add((dodaj).StavkaProdaje);
            prodajaNamestaja.UkupnaCenaBezPDV += dodaj.StavkaProdaje.Cena;
            prodajaNamestaja.UkupnaCenaSaPDV = prodajaNamestaja.UkupnaCenaBezPDV + prodajaNamestaja.UkupnaCenaBezPDV * ProdajaNamestaja.PDV;
        }

        private void DodajUslugu(object sender, RoutedEventArgs e)
        {
            ProdataUsluga prodataU = new ProdataUsluga();
            DodajUsluguProdajaWindow dodajUslugaWindow = new DodajUsluguProdajaWindow(prodataU, DodajUsluguProdajaWindow.Operacija.DODAVANJE);
            dodajUslugaWindow.Show();

            dodajUslugaWindow.Closed += DodajUslugaWindow_Closed;
        }

        private void DodajUslugaWindow_Closed(object sender, EventArgs e)
        {
            var dodaj = sender as DodajUsluguProdajaWindow;
            prodajaNamestaja.ProdateUsluge.Add((dodaj).ProdataU);
            ListaDodatihUsluga.Add((dodaj).ProdataU);
            prodajaNamestaja.UkupnaCenaBezPDV += dodaj.ProdataU.DodatnaUsluga.Cena;
            prodajaNamestaja.UkupnaCenaSaPDV = prodajaNamestaja.UkupnaCenaBezPDV + prodajaNamestaja.UkupnaCenaBezPDV * ProdajaNamestaja.PDV;
        }

        private void ObrisiStavku_Click(object sender, RoutedEventArgs e)
        {
            StavkaProdaje izabranaStavka = dgIdNamestaja.SelectedItem as StavkaProdaje;
            prodajaNamestaja.StavkeProdaje.Remove(izabranaStavka);
            ListaObrisanihStavki.Add(izabranaStavka);
            prodajaNamestaja.UkupnaCenaBezPDV -= izabranaStavka.Cena;
            prodajaNamestaja.UkupnaCenaSaPDV = prodajaNamestaja.UkupnaCenaBezPDV - prodajaNamestaja.UkupnaCenaBezPDV * ProdajaNamestaja.PDV;

            for (int i = 0; i < prodajaNamestaja.StavkeProdaje.Count; i++)
            {
                if (izabranaStavka.NamestajId == prodajaNamestaja.StavkeProdaje[i].NamestajId)
                {
                    prodajaNamestaja.StavkeProdaje[i].Namestaj.KolicinaUMagacinu = prodajaNamestaja.StavkeProdaje[i].Namestaj.KolicinaUMagacinu + prodajaNamestaja.StavkeProdaje[i].Kolicina;
                    Namestaj.Update(prodajaNamestaja.StavkeProdaje[i].Namestaj);
                }
            }

            
        }

        private void ObrisiUslugu_Click(object sender, RoutedEventArgs e)
        {
            ProdataUsluga izabranaUsluga = dgDodatnaUsluga.SelectedItem as ProdataUsluga;
            prodajaNamestaja.ProdateUsluge.Remove(izabranaUsluga);
            ListaObrisanihUsluga.Add(izabranaUsluga);
            prodajaNamestaja.UkupnaCenaBezPDV -= izabranaUsluga.DodatnaUsluga.Cena;
            prodajaNamestaja.UkupnaCenaSaPDV = prodajaNamestaja.UkupnaCenaBezPDV - prodajaNamestaja.UkupnaCenaBezPDV * ProdajaNamestaja.PDV;

           
        }

        private bool ForceValidation()
        {
            BindingExpression bindingExpression = tbKupac.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();
            

            if (Validation.GetHasError(tbKupac) == true)
            {
                return true;
            }
            return false;
        }
    }
}