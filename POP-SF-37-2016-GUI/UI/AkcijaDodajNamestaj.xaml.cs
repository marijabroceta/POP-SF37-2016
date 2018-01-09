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
    /// Interaction logic for AkcijaDodajNamestaj.xaml
    /// </summary>
    public partial class AkcijaDodajNamestaj : Window
    {

        ICollectionView viewNamestaj;
        ICollectionView viewPretraga;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        //public Namestaj Namestaj { get; set; }
        public NaAkciji NamestajAkcija { get; set; }

        public AkcijaDodajNamestaj(NaAkciji naAkciji,Operacija operacija)
        {
            InitializeComponent();

            this.operacija = operacija;
            NamestajAkcija = naAkciji;
            viewNamestaj = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            viewNamestaj.Filter = PrikazFilter;


            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            if(operacija == Operacija.DODAVANJE)
            {
                dgNamestaj.ItemsSource = Namestaj.NamestajNijeNaAkciji();
            }
            //dgNamestaj.ItemsSource = viewNamestaj;


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
                        
                        NamestajAkcija.Namestaj = dgNamestaj.SelectedItem as Namestaj;
                    }

                   

                    break;
                case Operacija.IZMENA:

                   
                    break;
            }



            Close();
        }

        private void PretragaNamestajaNaAkciji_Click(object sender, RoutedEventArgs e)
        {
            string naziv = tbPretraga.Text;
            viewPretraga = CollectionViewSource.GetDefaultView(Namestaj.PretragaNamestaja(naziv, Namestaj.TipPretrage.NAZIV));
            dgNamestaj.ItemsSource = viewPretraga;
        }
    }
}
