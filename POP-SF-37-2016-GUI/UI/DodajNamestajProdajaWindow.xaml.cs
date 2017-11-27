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
    /// Interaction logic for DodajNamestajProdajaWindow.xaml
    /// </summary>
    public partial class DodajNamestajProdajaWindow : Window
    {
        public Namestaj Namestaj { get; set; }



        public DodajNamestajProdajaWindow()
        {

            InitializeComponent();
            this.DataContext = Namestaj;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = Projekat.Instance.Namestaj;

        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {

            if ((dgNamestaj.SelectedItem != null) && (dgNamestaj.SelectedItem is Namestaj))
            {
                Namestaj = dgNamestaj.SelectedItem as Namestaj;

            }



            this.Close();
        }

    }    
}
