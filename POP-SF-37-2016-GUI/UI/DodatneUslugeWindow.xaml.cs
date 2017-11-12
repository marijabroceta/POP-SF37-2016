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
    /// Interaction logic for DodatneUslugeWindow.xaml
    /// </summary>
    public partial class DodatneUslugeWindow : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private DodatnaUsluga usluga;

        public DodatneUslugeWindow(DodatnaUsluga usluga, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(usluga,operacija);
        }

        private void InicijalizujVrednosti(DodatnaUsluga usluga, Operacija operacija)
        {
            this.usluga = usluga;
            this.operacija = operacija;

            this.tbNazivUsluge.Text = usluga.NazivUsluge;
            this.tbCenaUsluge.Text = usluga.Cena.ToString();
        }

        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaUsluga = Projekat.Instance.DodatnaUsluga;


            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var novaUsluga = new DodatnaUsluga()
                    {
                        Id = listaUsluga.Count + 1,
                        NazivUsluge = this.tbNazivUsluge.Text,
                        Cena = double.Parse(this.tbCenaUsluge.Text)

                    };


                    listaUsluga.Add(novaUsluga);



                    break;
                case Operacija.IZMENA:

                    foreach (var u in listaUsluga)
                    {
                        if (u.Id == usluga.Id)
                        {
                            u.NazivUsluge = this.tbNazivUsluge.Text;
                            u.Cena = double.Parse(this.tbCenaUsluge.Text);
                            break;
                        }
                    }
                    break;
            }

            Projekat.Instance.DodatnaUsluga = listaUsluga;
            Close();
        }
    }
}
