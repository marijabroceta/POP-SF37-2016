using POP_37_2016.Model;
using POP_37_2016.Util;
using POP_SF_37_2016_GUI.Model;
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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        ICollectionView viewAkcija;
        ICollectionView viewTipNamestaja;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private Namestaj namestaj;

        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            viewAkcija = CollectionViewSource.GetDefaultView(Projekat.Instance.AkcijskaProdaja);
            viewTipNamestaja = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamestaja);

            this.namestaj = namestaj;
            this.operacija = operacija;

            cbAkcijaId.ItemsSource = viewAkcija;
            cbTipNamestajaId.ItemsSource = viewTipNamestaja;

            viewAkcija.Filter = PrikazFilterAkcija;
            viewTipNamestaja.Filter = PrikazFilterTipNamestaja;

            

            tbNaziv.DataContext = namestaj;
            
            tbCena.DataContext = namestaj;
            tbKolicina.DataContext = namestaj;
            cbTipNamestajaId.DataContext = namestaj;
            cbAkcijaId.DataContext = namestaj;

            

            
        }

        private bool PrikazFilterAkcija(object obj)
        {
            return !((AkcijskaProdaja)obj).Obrisan;
        }

        private bool PrikazFilterTipNamestaja(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;
        }

        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            
           
            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    
                    Namestaj.Create(namestaj);
                    
                    

                    break;
                case Operacija.IZMENA:

                    Namestaj.Update(namestaj);
                    break;
            }

                
                Close();
        }


    }
}
