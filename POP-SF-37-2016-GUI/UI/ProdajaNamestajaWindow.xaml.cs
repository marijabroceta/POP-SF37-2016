using POP_37_2016.Model;
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

            InicijalizujVrednosti(prodajaNamestaja, operacija);
        }

        private void InicijalizujVrednosti(ProdajaNamestaja prodajaNamestaja, Operacija operacija)
        {
            this.prodajaNamestaja = prodajaNamestaja;
            this.operacija = operacija;

            prodajaNamestaja.NamestajZaProdajuId = new List<int>();
            prodajaNamestaja.DodatnaUslugaId = new List<int>();
            foreach (var namestajZaProdaju in Projekat.Instance.Namestaj)
            {
                cbIdNamestaja.Items.Add(namestajZaProdaju);
            }

            this.dpDatumProdaje.Text = prodajaNamestaja.DatumProdaje.ToString();
            this.tbBrojRacuna.Text = prodajaNamestaja.BrojRacuna;
            this.tbKupac.Text = prodajaNamestaja.Kupac;
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                cbDodatnaUsluga.Items.Add(usluga);
            }
        
            
            this.lblUkupnaCena.Content = prodajaNamestaja.UkupnaCena;
            

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
                    prodajaNamestaja.DatumProdaje = this.dpDatumProdaje.SelectedDate.Value;
                    prodajaNamestaja.BrojRacuna = this.tbBrojRacuna.Text;
                    prodajaNamestaja.Kupac = this.tbKupac.Text;

                    prodajaNamestaja.UkupnaCena += prodajaNamestaja.UkupnaCena * ProdajaNamestaja.PDV ;
                    
                       
                    
                  
                    listaProdaje.Add(prodajaNamestaja);
                    break;
                case Operacija.IZMENA:

                    foreach (var pn in listaProdaje)
                    {
                        if (pn.Id == prodajaNamestaja.Id)
                        {
                            
                            pn.DatumProdaje = this.dpDatumProdaje.SelectedDate.Value;
                            pn.BrojRacuna = this.tbBrojRacuna.Text;
                            pn.Kupac = this.tbKupac.Text;
                            

                            break;
                        }
                    }
                    break;
            }

            Projekat.Instance.ProdajaNamestaja = listaProdaje;
            Close();
        }

        
        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            if (cbIdNamestaja.SelectedItem is Namestaj)
            {
                Namestaj n = (Namestaj)cbIdNamestaja.SelectedItem;
                prodajaNamestaja.NamestajZaProdajuId.Add(n.Id);
                prodajaNamestaja.UkupnaCena += n.JedinicnaCena;              
                lblUkupnaCena.Content = prodajaNamestaja.UkupnaCena + prodajaNamestaja.UkupnaCena* ProdajaNamestaja.PDV;
                //MessageBox.Show($"Dodati namestaj je: {n.Naziv}, {TipNamestaja.GetById(n.TipNamestajaId).Naziv}");
            }

            
            


        }
        private void DodajUslugu(object sender, RoutedEventArgs e)
        {
            if (cbDodatnaUsluga.SelectedItem is DodatnaUsluga)
            {
                DodatnaUsluga du = (DodatnaUsluga)cbDodatnaUsluga.SelectedItem;
                prodajaNamestaja.DodatnaUslugaId.Add(du.Id);              
                prodajaNamestaja.UkupnaCena += du.Cena;
                lblUkupnaCena.Content = prodajaNamestaja.UkupnaCena + prodajaNamestaja.UkupnaCena * ProdajaNamestaja.PDV;
                MessageBox.Show($"Dodata usluga je: {du.NazivUsluge}");
            }
        }


        /*
        private void DodajNamestaj(object sender, RoutedEventArgs e)
        {
            if (lbIdNamestaja.SelectedItem is Namestaj)
            {
                Namestaj n = (Namestaj)lbIdNamestaja.SelectedItem;
                prodajaNamestaja.NamestajZaProdajuId.Add(n.Id);
                prodajaNamestaja.UkupnaCena += n.JedinicnaCena;
               
                lblUkupnaCena.Content = prodajaNamestaja.UkupnaCena + prodajaNamestaja.UkupnaCena* ProdajaNamestaja.PDV;
            }


        }

        private void DodajUslugu(object sender, RoutedEventArgs e)
        {
            if(lbDodatnaUsluga.SelectedItem is DodatnaUsluga)
            {
                DodatnaUsluga du = (DodatnaUsluga)lbDodatnaUsluga.SelectedItem;
                prodajaNamestaja.DodatnaUslugaId.Add(du.Id);
                prodajaNamestaja.UkupnaCena += du.Cena;
                lblUkupnaCena.Content = prodajaNamestaja.UkupnaCena + prodajaNamestaja.UkupnaCena* ProdajaNamestaja.PDV;
            }
        }*/
    }
}
