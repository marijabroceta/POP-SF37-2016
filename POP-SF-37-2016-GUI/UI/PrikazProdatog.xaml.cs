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

        private ObservableCollection<int> izabranaUsluga;
        private ObservableCollection<Namestaj> izabraniNamestaj;

        public PrikazProdatog(ObservableCollection<Namestaj> izabraniNamestaj,ObservableCollection<int> izabranaUsluga)
        {
            InitializeComponent();

            this.izabranaUsluga = izabranaUsluga;
            this.izabraniNamestaj = izabraniNamestaj; 

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgUsluga.DataContext = this;

            dgNamestaj.ItemsSource = izabraniNamestaj;
            dgUsluga.ItemsSource = izabranaUsluga;

           

           
        }

       
    }
}
