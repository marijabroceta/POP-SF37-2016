using POP_37_2016.Model;
using POP_37_2016.Util;
using POP_SF_37_2016_GUI.Model;
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

        public ProdajaNamestajaWindow(ProdajaNamestaja prodajaNamestaja, Operacija operacija)
        {
            InitializeComponent();




            this.prodajaNamestaja = prodajaNamestaja;
            this.operacija = operacija;

            //dgDodatnaUsluga.ItemsSource = prodajaNamestaja.DodatnaUslugaZaProdaju;
            //dgIdNamestaja.ItemsSource = prodajaNamestaja.NamestajZaProdaju;
            dgDodatnaUsluga.ItemsSource = prodajaNamestaja.Stavka;
            dgIdNamestaja.ItemsSource = prodajaNamestaja.Stavka;
            dpDatumProdaje.DataContext = prodajaNamestaja;

            tbKupac.DataContext = prodajaNamestaja;
            dgDodatnaUsluga.DataContext = prodajaNamestaja;
            lblUkupnaCenaSaPDV.DataContext = prodajaNamestaja;
            lblUkupnaCenaBezPDV.DataContext = prodajaNamestaja;


        }


        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaProdaje = Projekat.Instance.ProdajaNamestaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    prodajaNamestaja.Id = listaProdaje.Count + 1;
                    prodajaNamestaja.BrojRacuna = "FTN" + (listaProdaje.Count + 20);

                    listaProdaje.Add(prodajaNamestaja);


                    break;
                case Operacija.IZMENA:

                    foreach (var pn in listaProdaje)
                    {
                        if (pn.Id == prodajaNamestaja.Id)
                        {

                            pn.DatumProdaje = prodajaNamestaja.DatumProdaje;
                            pn.BrojRacuna = prodajaNamestaja.BrojRacuna;
                            pn.Kupac = prodajaNamestaja.Kupac;
                            //pn.NamestajZaProdaju = prodajaNamestaja.NamestajZaProdaju;
                            pn.UkupnaCenaSaPDV = prodajaNamestaja.UkupnaCenaSaPDV;
                            pn.UkupnaCenaBezPDV = prodajaNamestaja.UkupnaCenaBezPDV;
                            //pn.DodatnaUslugaZaProdaju = prodajaNamestaja.DodatnaUslugaZaProdaju;
                            pn.Stavka = prodajaNamestaja.Stavka;


                            break;
                        }
                    }
                    break;
            }

            GenericSerializer.Serialize("prodajaNamestaja.xml", listaProdaje);
            Close();
        }
        /*
        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {

            DodajNamestajProdajaWindow dodajWindow = new DodajNamestajProdajaWindow();
            dodajWindow.Show();

            dodajWindow.Closed += DodajWindow_Closed;



        }

        private void DodajWindow_Closed(object sender, EventArgs e)
        {

            var dodaj = sender as DodajNamestajProdajaWindow;
            prodajaNamestaja.NamestajZaProdaju.Add((dodaj).Namestaj);

            prodajaNamestaja.UkupnaCenaBezPDV += dodaj.Namestaj.JedinicnaCena;
            prodajaNamestaja.UkupnaCenaSaPDV = dodaj.Namestaj.JedinicnaCena + dodaj.Namestaj.JedinicnaCena * ProdajaNamestaja.PDV;






        }




        private void DodajUslugu(object sender, RoutedEventArgs e)
        {

            DodajUsluguProdajaWindow dodajUslugaWindow = new DodajUsluguProdajaWindow();
            dodajUslugaWindow.Show();

            dodajUslugaWindow.Closed += DodajUslugaWindow_Closed;
        }

        private void DodajUslugaWindow_Closed(object sender, EventArgs e)
        {

            var dodaj = sender as DodajUsluguProdajaWindow;
            prodajaNamestaja.DodatnaUslugaZaProdaju.Add((dodaj).Usluga);

            prodajaNamestaja.UkupnaCenaBezPDV += dodaj.Usluga.Cena;
            prodajaNamestaja.UkupnaCenaSaPDV = dodaj.Usluga.Cena + dodaj.Usluga.Cena * ProdajaNamestaja.PDV;



        }*/

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {

            DodajStavkuWindow dodajWindow = new DodajStavkuWindow();
            if(dodajWindow.ShowDialog() == true)
            {
                prodajaNamestaja.Stavka.Add(dodajWindow.Namestaj);
                prodajaNamestaja.UkupnaCenaBezPDV += dodajWindow.Namestaj.JedinicnaCena;
                prodajaNamestaja.UkupnaCenaSaPDV = dodajWindow.Namestaj.JedinicnaCena + dodajWindow.Namestaj.JedinicnaCena * ProdajaNamestaja.PDV;
            }
            

           // dodajWindow.Closed += DodajWindow_Closed;



        }
        /*
        private void DodajWindow_Closed(object sender, EventArgs e)
        {
            

            var dodaj = sender as DodajStavkuWindow;
            prodajaNamestaja.Stavka.Add((dodaj).Namestaj);

            prodajaNamestaja.UkupnaCenaBezPDV += dodaj.Namestaj.JedinicnaCena;
            prodajaNamestaja.UkupnaCenaSaPDV = dodaj.Namestaj.JedinicnaCena + dodaj.Namestaj.JedinicnaCena * ProdajaNamestaja.PDV;






        }*/

        private void DodajUslugu(object sender, RoutedEventArgs e)
        {

            DodajStavkuWindow dodajUslugaWindow = new DodajStavkuWindow();
            if (dodajUslugaWindow.ShowDialog() == true)
            {
                prodajaNamestaja.Stavka.Add(dodajUslugaWindow.Usluga);
                prodajaNamestaja.UkupnaCenaBezPDV += dodajUslugaWindow.Usluga.Cena;
                prodajaNamestaja.UkupnaCenaSaPDV = dodajUslugaWindow.Usluga.Cena + dodajUslugaWindow.Usluga.Cena * ProdajaNamestaja.PDV;
            }
            

            //dodajUslugaWindow.Closed += DodajUslugaWindow_Closed;
        }
/*
        private void DodajUslugaWindow_Closed(object sender, EventArgs e)
        {

            var dodaj = sender as DodajStavkuWindow;
            prodajaNamestaja.Stavka.Add((dodaj).Usluga);

            prodajaNamestaja.UkupnaCenaBezPDV += dodaj.Usluga.Cena;
            prodajaNamestaja.UkupnaCenaSaPDV = dodaj.Usluga.Cena + dodaj.Usluga.Cena * ProdajaNamestaja.PDV;



        }*/
    }   

        
}
