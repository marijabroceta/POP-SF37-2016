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
    /// Interaction logic for AkcijaProzor.xaml
    /// </summary>
    public partial class AkcijaProzor : Window
    {
        public AkcijaProzor()
        {
            InitializeComponent();

            OsveziPrikaz();
        }

        public void OsveziPrikaz()
        {
            lbAkcija.Items.Clear();

            foreach (var akcija in Projekat.Instance.AkcijskaProdaja)
            {
                lbAkcija.Items.Add(akcija);

            }
            lbAkcija.SelectedIndex = 0;

        }

        private void DodajAkciju(object sender, RoutedEventArgs e)
        {
            var novaAkcija = new AkcijskaProdaja()
            {
                Popust = 0,
                DatumPocetka = DateTime.Today,
                DatumZavrsetka = DateTime.Today,
                
            };
            var akcijaProzor = new AkcijaWindow(novaAkcija, AkcijaWindow.Operacija.DODAVANJE);
            akcijaProzor.ShowDialog();

            OsveziPrikaz();
        }

        private void IzmeniAkciju(object sender, RoutedEventArgs e)
        {
            var izabranaAkcija = (AkcijskaProdaja)lbAkcija.SelectedItem;
            var akcijaProzor = new AkcijaWindow(izabranaAkcija, AkcijaWindow.Operacija.IZMENA);

            akcijaProzor.Show();


        }

        private void ZatvoriProzor(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        
    }
}
