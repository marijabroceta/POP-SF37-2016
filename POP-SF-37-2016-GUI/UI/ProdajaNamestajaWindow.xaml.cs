using POP_37_2016.Model;
using POP_37_2016.Util;
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
    /// Interaction logic for ProdajaNamestajaWindow.xaml
    /// </summary>
    public partial class ProdajaNamestajaWindow : Window
    {
        ICollectionView viewStavka;
        ICollectionView viewUsluga;


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
            if((dodaj).StavkaProdaje.Kolicina > (dodaj).StavkaProdaje.Namestaj.KolicinaUMagacinu)
            {
                MessageBox.Show("Kolicina u magacinu je manja od unete!", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if((dodaj).StavkaProdaje.Kolicina <= 0)
            {
                MessageBox.Show("Uneta kolicina mora biti veca od 0", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
            else if((dodaj).StavkaProdaje.Kolicina <= (dodaj).StavkaProdaje.Namestaj.KolicinaUMagacinu)
            {
                prodajaNamestaja.StavkeProdaje.Add((dodaj).StavkaProdaje);

                prodajaNamestaja.UkupnaCenaBezPDV += dodaj.StavkaProdaje.Cena;
                //prodajaNamestaja.UkupnaCenaSaPDV = dodaj.StavkaProdaje.Cena + (dodaj.StavkaProdaje.Cena * ProdajaNamestaja.PDV);
                prodajaNamestaja.UkupnaCenaSaPDV = prodajaNamestaja.UkupnaCenaBezPDV * 1.2;
            }
            




            

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
            prodajaNamestaja.UkupnaCenaBezPDV += dodaj.ProdataU.DodatnaUsluga.Cena;
            // prodajaNamestaja.UkupnaCenaSaPDV = dodaj.Usluga.Cena + (dodaj.Usluga.Cena * ProdajaNamestaja.PDV) ;
            prodajaNamestaja.UkupnaCenaSaPDV = prodajaNamestaja.UkupnaCenaBezPDV * 1.2;




        }

        private void ObrisiStavku_Click(object sender, RoutedEventArgs e)
        {
            StavkaProdaje izabranaStavka = dgIdNamestaja.SelectedItem as StavkaProdaje;
            StavkaProdaje.Delete(izabranaStavka);
            prodajaNamestaja.UkupnaCenaBezPDV -= izabranaStavka.Cena;
            prodajaNamestaja.UkupnaCenaSaPDV = prodajaNamestaja.UkupnaCenaBezPDV * 1.2;

            for (int i = 0; i < prodajaNamestaja.StavkeProdaje.Count; i++)
            {
                if(izabranaStavka.NamestajId == prodajaNamestaja.StavkeProdaje[i].NamestajId)
                {
                    prodajaNamestaja.StavkeProdaje[i].Namestaj.KolicinaUMagacinu = prodajaNamestaja.StavkeProdaje[i].Namestaj.KolicinaUMagacinu + prodajaNamestaja.StavkeProdaje[i].Kolicina;
                    Namestaj.Update(prodajaNamestaja.StavkeProdaje[i].Namestaj);
                }
                

            }

            viewStavka.Refresh();
            
        }

        private void ObrisiUslugu_Click(object sender, RoutedEventArgs e)
        {
            ProdataUsluga izabranaUsluga = dgDodatnaUsluga.SelectedItem as ProdataUsluga;
            ProdataUsluga.Delete(izabranaUsluga);
            prodajaNamestaja.UkupnaCenaBezPDV -= izabranaUsluga.DodatnaUsluga.Cena;
            prodajaNamestaja.UkupnaCenaSaPDV = prodajaNamestaja.UkupnaCenaBezPDV * 1.2;
        }
    }


}
