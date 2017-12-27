using POP_37_2016.Model;
using POP_37_2016.Util;
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
    /// Interaction logic for ProdajaNamestajaWindow.xaml
    /// </summary>
    public partial class ProdajaNamestajaWindow : Window
    {



        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private ProdajaNamestaja prodajaNamestaja;
        /*
        private ObservableCollection<StavkaProdaje> dodateStavke = new ObservableCollection<StavkaProdaje>();
        private ObservableCollection<DodatnaUsluga> dodateUsluge = new ObservableCollection<DodatnaUsluga>();
        private ObservableCollection<StavkaProdaje> obrisaneStavke = new ObservableCollection<StavkaProdaje>();
        private ObservableCollection<DodatnaUsluga> obrisaneUsluge = new ObservableCollection<DodatnaUsluga>();
        */
        public ProdajaNamestajaWindow(ProdajaNamestaja prodajaNamestaja, Operacija operacija)
        {
            InitializeComponent();




            this.prodajaNamestaja = prodajaNamestaja;
            this.operacija = operacija;

            dgDodatnaUsluga.ItemsSource = prodajaNamestaja.DodatneUsluge;
            dgIdNamestaja.ItemsSource = prodajaNamestaja.StavkeProdaje;

            
            
            dpDatumProdaje.DataContext = prodajaNamestaja;
            tbKupac.DataContext = prodajaNamestaja;
            dgIdNamestaja.DataContext = prodajaNamestaja;
            lblUkupnaCenaSaPDV.DataContext = prodajaNamestaja;
            lblUkupnaCenaBezPDV.DataContext = prodajaNamestaja;


        }


        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaje = Projekat.Instance.Prodaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:



                    Random random = new Random();
                    prodajaNamestaja.BrojRacuna = "FTN" + random.Next(10, 99999) + DateTime.Today.ToString("ddMMyyyy");
                    ProdajaNamestaja.Create(prodajaNamestaja);


                    break;
                case Operacija.IZMENA:

                    ProdajaNamestaja.Update(prodajaNamestaja);
                    break;
            }

            

            Close();
        }
       

        private void DodajUslugu(object sender, RoutedEventArgs e)
        {
            DodatnaUsluga usluga = new DodatnaUsluga();
            DodajUsluguProdajaWindow dodajUslugaWindow = new DodajUsluguProdajaWindow(usluga,DodajUsluguProdajaWindow.Operacija.DODAVANJE);
            dodajUslugaWindow.Show();

            dodajUslugaWindow.Closed += DodajUslugaWindow_Closed;
        }

        
        private void DodajUslugaWindow_Closed(object sender, EventArgs e)
        {

            var dodaj = sender as DodajUsluguProdajaWindow;
            prodajaNamestaja.DodatneUsluge.Add((dodaj).Usluga);


            prodajaNamestaja.UkupnaCenaBezPDV += dodaj.Usluga.Cena;
            prodajaNamestaja.UkupnaCenaSaPDV = dodaj.Usluga.Cena + (dodaj.Usluga.Cena * ProdajaNamestaja.PDV);


        }
     
        

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {

            StavkaProdaje stavka = new StavkaProdaje();
            DodajStavkuWindow dodajWindow = new DodajStavkuWindow(stavka,DodajStavkuWindow.Operacija.DODAVANJE);
            dodajWindow.Show();          
            dodajWindow.Closed += DodajWindow_Closed;


        }
        
        private void DodajWindow_Closed(object sender, EventArgs e)
        {           
            var dodaj = sender as DodajStavkuWindow;
            prodajaNamestaja.StavkeProdaje.Add((dodaj).StavkaProdaje);


            prodajaNamestaja.UkupnaCenaBezPDV += dodaj.StavkaProdaje.Cena;
            prodajaNamestaja.UkupnaCenaSaPDV = dodaj.StavkaProdaje.Cena + (dodaj.StavkaProdaje.Cena * ProdajaNamestaja.PDV);



        }
        

    }


}
