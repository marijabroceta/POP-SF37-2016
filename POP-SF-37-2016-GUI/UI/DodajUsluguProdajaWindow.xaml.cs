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

namespace POP_SF_37_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for DodajUsluguProdajaWindow.xaml
    /// </summary>
    public partial class DodajUsluguProdajaWindow : Window
    {
        ICollectionView view;
        ICollectionView viewPretraga;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
       
        public ProdataUsluga ProdataU { get; set; }

        public DodajUsluguProdajaWindow(ProdataUsluga prodataU,Operacija operacija)
        {
            InitializeComponent();

            this.operacija = operacija;
            
            ProdataU = prodataU;
            
            view = CollectionViewSource.GetDefaultView(Projekat.Instance.DodatnaUsluga);
            view.Filter = PrikazFilter;

            
            dgUsluga.IsSynchronizedWithCurrentItem = true;
            dgUsluga.DataContext = this;
            dgUsluga.ItemsSource = view;
            
            
        }

        private bool PrikazFilter(object obj)
        {
            return !((DodatnaUsluga)obj).Obrisan;
        }

        private void DodajUslugu_Click(object sender, RoutedEventArgs e)
        {

            switch(operacija)
            {
                case Operacija.DODAVANJE:
                    try
                    {
                        if ((dgUsluga.SelectedItem != null) && (dgUsluga.SelectedItem is DodatnaUsluga))
                        {
                            ProdataU.DodatnaUsluga = dgUsluga.SelectedItem as DodatnaUsluga;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Morate obeleziti red", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    
                    break;
               

            }
            
            this.Close();
        }

        private void PretraziUsluge_Click(object sender, RoutedEventArgs e)
        {
            string naziv = tbPretraga.Text;
            viewPretraga = CollectionViewSource.GetDefaultView(DodatnaUsluga.PretragaDodatnaUsluga(naziv));
            dgUsluga.ItemsSource = viewPretraga;
        }
    }
}
