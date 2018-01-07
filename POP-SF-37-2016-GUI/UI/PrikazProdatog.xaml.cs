using POP_37_2016.Model;
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
using System.Collections.ObjectModel;

namespace POP_SF_37_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for PrikazProdatog.xaml
    /// </summary>
    public partial class PrikazProdatog : Window
    {
        

        private ProdajaNamestaja prodajaNamestaja;
        private ObservableCollection<ProdataUsluga> izabranaUsluga;
        private ObservableCollection<StavkaProdaje> izabranaStavka;

        public PrikazProdatog(ObservableCollection<StavkaProdaje> izabranaStavka,ObservableCollection<ProdataUsluga> izabranaUsluga, ProdajaNamestaja prodajaNamestaja)
        {
            InitializeComponent();



            this.prodajaNamestaja = prodajaNamestaja;
            this.izabranaUsluga = izabranaUsluga;
            this.izabranaStavka = izabranaStavka;

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgUsluga.IsSynchronizedWithCurrentItem = true;

            dgNamestaj.DataContext = this;
            dgUsluga.DataContext = this;

            izabranaStavka = StavkaProdaje.GetAllId(prodajaNamestaja.Id);
            izabranaUsluga = ProdataUsluga.GetAllId(prodajaNamestaja.Id);

            dgNamestaj.ItemsSource = izabranaStavka;
            dgUsluga.ItemsSource = izabranaUsluga;
            lblProdavac.DataContext = Korisnik.GetKorisnik(MainWindow.TrenutnoLogovan);
            lblDatumProdaje.DataContext = prodajaNamestaja;
            lblBrojRacuna.DataContext = prodajaNamestaja;
            lblKupac.DataContext = prodajaNamestaja;
            lblUkupnaCenaBezPDV.DataContext = prodajaNamestaja;
            lblUkupnaCenaSaPDV.DataContext = prodajaNamestaja;
           


        }


       

    }
}
