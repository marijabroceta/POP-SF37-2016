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
        private ObservableCollection<DodatnaUsluga> izabranaUsluga;
        private ObservableCollection<StavkaProdaje> izabranaStavka;

        public PrikazProdatog(ObservableCollection<StavkaProdaje> izabranaStavka,ObservableCollection<DodatnaUsluga> izabranaUsluga, ProdajaNamestaja prodajaNamestaja)
        {
            InitializeComponent();



            this.prodajaNamestaja = prodajaNamestaja;
            this.izabranaUsluga = izabranaUsluga;
            this.izabranaStavka = izabranaStavka;

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgUsluga.IsSynchronizedWithCurrentItem = true;

            dgNamestaj.DataContext = this;
            dgUsluga.DataContext = this;

            dgNamestaj.ItemsSource = izabranaStavka;
            dgUsluga.ItemsSource = izabranaUsluga;

            dpDatumProdaje.DataContext = prodajaNamestaja;
            tbBrojRacuna.DataContext = prodajaNamestaja;
            tbKupac.DataContext = prodajaNamestaja;
            
           


        }

       
    }
}
