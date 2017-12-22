using POP_37_2016.Model;
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
    /// Interaction logic for DodajStavkuWindow.xaml
    /// </summary>
    public partial class DodajStavkuWindow : Window
    {
        ICollectionView viewNamestaj;
        
        public Namestaj Namestaj { get; set; }
        public DodatnaUsluga Usluga { get; set; }

        public DodajStavkuWindow()
        {
            InitializeComponent();

            viewNamestaj = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            viewNamestaj.Filter = PrikazFilterNamestaj;

            this.DataContext = Namestaj;
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = viewNamestaj;
            tbKolicina.DataContext = Namestaj;

            
            
            
        }

        private bool PrikazFilterNamestaj(object obj)
        {
            return !((Namestaj)obj).Obrisan;
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
