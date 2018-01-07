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

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        //public DodatnaUsluga Usluga { get; set; }
        public ProdataUsluga ProdataU { get; set; }

        public DodajUsluguProdajaWindow(ProdataUsluga prodataU,Operacija operacija)
        {
            InitializeComponent();

            this.operacija = operacija;
            //Usluga = usluga;
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

                    if ((dgUsluga.SelectedItem != null) && (dgUsluga.SelectedItem is DodatnaUsluga))
                    {
                        //Usluga = dgUsluga.SelectedItem as DodatnaUsluga;
                        ProdataU.DodatnaUsluga = dgUsluga.SelectedItem as DodatnaUsluga;
                    }
                    break;
            }
            
            this.Close();
        }
    }
}
