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

        public AkcijaWindow(AkcijskaProdaja akcija, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(akcija, operacija);
        }

        private void InicijalizujVrednosti(AkcijskaProdaja akcija, Operacija operacija)
        {
            this.akcija = akcija;
            this.operacija = operacija;

            this.tbPopust.Text = akcija.Popust.ToString();
            this.dpPocetakAkcije.Text = akcija.DatumPocetka.ToString();
            this.dpZavrsetakAkcije.Text = akcija.DatumZavrsetka.ToString();
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

                    var novaAkcija = new AkcijskaProdaja()
                    {
                        Id = listaAkcija.Count + 1,
                        Popust = decimal.Parse(this.tbPopust.Text),

                        DatumPocetka = dpPocetakAkcije.SelectedDate.Value,
                        DatumZavrsetka = this.dpZavrsetakAkcije.SelectedDate.Value,

                    };


                    listaAkcija.Add(novaAkcija);



                    break;
                case Operacija.IZMENA:

                    foreach (var a in listaAkcija)
                    {
                        if (a.Id == akcija.Id)
                        {
                            a.Popust = decimal.Parse(this.tbPopust.Text);
                            a.DatumPocetka = DateTime.Parse(this.dpPocetakAkcije.Text);
                            a.DatumZavrsetka = DateTime.Parse(this.dpZavrsetakAkcije.Text);
                            break;
                        }
                    }
                    break;
            }

            Projekat.Instance.AkcijskaProdaja = listaAkcija;
            Close();
        }
    }
}
