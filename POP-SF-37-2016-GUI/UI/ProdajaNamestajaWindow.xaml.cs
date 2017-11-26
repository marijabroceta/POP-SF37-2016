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

            cbDodatnaUsluga.ItemsSource = Projekat.Instance.DodatnaUsluga;
            dgIdNamestaja.ItemsSource = prodajaNamestaja.NamestajZaProdaju;

            dpDatumProdaje.DataContext = prodajaNamestaja;
            tbBrojRacuna.DataContext = prodajaNamestaja;
            tbKupac.DataContext = prodajaNamestaja;
            cbDodatnaUsluga.DataContext = prodajaNamestaja;
            lblUkupnaCena.DataContext = prodajaNamestaja;                                   
                     
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
                            pn.NamestajZaProdaju = prodajaNamestaja.NamestajZaProdaju;
                            pn.UkupnaCena = prodajaNamestaja.UkupnaCena;
                            pn.DodatnaUslugaId = prodajaNamestaja.DodatnaUslugaId;
                            

                            break;
                        }
                    }
                    break;
            }

            GenericSerializer.Serialize("prodajaNamestaja.xml", listaProdaje);
            Close();
        }

        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
           
            DodajNamestajProdajaWindow dodajWindow = new DodajNamestajProdajaWindow();
            dodajWindow.Show();
            
            dodajWindow.Closed += DodajWindow_Closed;
            


        }

        private void DodajWindow_Closed(object sender, EventArgs e)
        {
            prodajaNamestaja.NamestajZaProdaju.Add((sender as DodajNamestajProdajaWindow).Namestaj);
            
        }

    
        private void DodajUslugu(object sender, RoutedEventArgs e)
        {
            /*
            if (cbDodatnaUsluga.SelectedItem is DodatnaUsluga)
            {
                DodatnaUsluga du = (DodatnaUsluga)cbDodatnaUsluga.SelectedItem;
                prodajaNamestaja.DodatnaUslugaId.Add(du.Id);              
                prodajaNamestaja.UkupnaCena += du.Cena;
                lblUkupnaCena.Content = prodajaNamestaja.UkupnaCena + prodajaNamestaja.UkupnaCena * ProdajaNamestaja.PDV;
                MessageBox.Show($"Dodata usluga je: {du.Naziv}");
            }*/
        }


        
    }
}
