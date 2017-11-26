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

            DataGridTextColumn column1 = new DataGridTextColumn();
            column1.Header = "Sifra";
            column1.Width = 60;
            column1.Binding = new Binding("Sifra");
            dgNamestaj.Columns.Add(column1);

            DataGridTextColumn column2 = new DataGridTextColumn();
            column2.Header = "Naziv";
            column2.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column2.Binding = new Binding("Naziv");
            dgNamestaj.Columns.Add(column2);

            DataGridTextColumn column3 = new DataGridTextColumn();
            column3.Header = "TipNamestaja";
            column3.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column3.Binding = new Binding("TipNamestaja");
            dgNamestaj.Columns.Add(column3);

            DataGridTextColumn column4 = new DataGridTextColumn();
            column4.Header = "Cena";
            column4.Width = 100;
            column4.Binding = new Binding("JedinicnaCena");
            dgNamestaj.Columns.Add(column4);

            DataGridTextColumn column5 = new DataGridTextColumn();
            column5.Header = "Kolicina";
            column5.Width = 50;
            column5.Binding = new Binding("KolicinaUMagacinu");
            dgNamestaj.Columns.Add(column5);

            DataGridTextColumn column6 = new DataGridTextColumn();
            column6.Header = "Akcija";
            column6.Width = new DataGridLength(1, DataGridLengthUnitType.Star);
            column6.Binding = new Binding("AkcijskaProdaja");
            dgNamestaj.Columns.Add(column6);
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
