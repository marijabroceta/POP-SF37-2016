using POP_37_2016.Model;
using POP_SF_37_2016_GUI.Model;
using POP_SF_37_2016_GUI.UI.Validacija;
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

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        
        public StavkaProdaje StavkaProdaje { get; set; }
        

        public DodajStavkuWindow(StavkaProdaje stavkaProdaje,Operacija operacija)
        {

            InitializeComponent();

            
            this.operacija = operacija;
            StavkaProdaje = stavkaProdaje;
            viewNamestaj = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            viewNamestaj.Filter = PrikazFilter;

           
            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ItemsSource = viewNamestaj;
            
            tbKolicina.DataContext = stavkaProdaje;

        }

        private bool PrikazFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;
        }



        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
           

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    if ((dgNamestaj.SelectedItem != null) && (dgNamestaj.SelectedItem is Namestaj))
                    {
                        StavkaProdaje.Namestaj = dgNamestaj.SelectedItem as Namestaj;
                        

                    }

                    
                    break;
                case Operacija.IZMENA:

                   
                    break;
            }


            
            Close();
        }

        private void dgNamestaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StavkaProdaje.Namestaj = dgNamestaj.SelectedItem as Namestaj;
            ValidacijaKolicina.Namestaj = StavkaProdaje.Namestaj;
        }

        
    }
}
