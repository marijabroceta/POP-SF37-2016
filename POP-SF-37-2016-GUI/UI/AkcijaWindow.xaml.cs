using POP_37_2016.Model;
using POP_37_2016.Util;
using POP_SF_37_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for AkcijaWindow.xaml
    /// </summary>
    public partial class AkcijaWindow : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private AkcijskaProdaja akcija;

        private ObservableCollection<Namestaj> dodatNaAkciju = new ObservableCollection<Namestaj>();

        public AkcijaWindow(AkcijskaProdaja akcija, Operacija operacija)
        {
            InitializeComponent();

            this.akcija = akcija;
            this.operacija = operacija;

            dgNamestajAkcija.ItemsSource = akcija.NamestajNaAkciji;

            tbNaziv.DataContext = akcija;
            tbPopust.DataContext = akcija;
            dpPocetakAkcije.DataContext = akcija;
            dpZavrsetakAkcije.DataContext = akcija;
            dgNamestajAkcija.DataContext = akcija;
            
        }

        

        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaAkcija = Projekat.Instance.AkcijskaProdaja;


            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    AkcijskaProdaja.Create(akcija);

                    AkcijskaProdaja.DodajNaAkciju(akcija, dodatNaAkciju);

                    break;
                case Operacija.IZMENA:

                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcija.Id)
                        {
                            a.Popust = akcija.Popust;
                            a.DatumPocetka = akcija.DatumPocetka;
                            a.DatumZavrsetka = akcija.DatumZavrsetka;
                            a.NamestajNaAkciji = akcija.NamestajNaAkciji;
                            break;
                        }
                    }
                    break;
            }

            GenericSerializer.Serialize("akcijskaProdaja.xml", listaAkcija);
            Close();
        }

        private void DodajNamestajAkcija_Click(object sender, RoutedEventArgs e)
        {
            Namestaj namestaj = new Namestaj();
            AkcijaDodajNamestaj dodajWindow = new AkcijaDodajNamestaj(namestaj,AkcijaDodajNamestaj.Operacija.DODAVANJE);
            dodajWindow.Show();

            dodajWindow.Closed += DodajWindow_Closed;
        }
        
        private void DodajWindow_Closed(object sender, EventArgs e)
        {

            var dodaj = sender as AkcijaDodajNamestaj;
            akcija.NamestajNaAkciji.Add((dodaj).Namestaj);

            

        }
    }
}
