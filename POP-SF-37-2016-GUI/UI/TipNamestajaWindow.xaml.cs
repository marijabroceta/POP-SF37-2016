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
    /// Interaction logic for TipNamestajaWindow.xaml
    /// </summary>
    public partial class TipNamestajaWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private TipNamestaja tipNamestaja;

        public TipNamestajaWindow(TipNamestaja tipNamestaja, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(tipNamestaja, operacija);
        }

        private void InicijalizujVrednosti(TipNamestaja tipNamestaja, Operacija operacija)
        {
            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;

            this.tbTipNaziv.Text = tipNamestaja.Naziv;
        }

        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaTipaNamestaja = Projekat.Instance.TipNamestaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviTipNamestaja = new TipNamestaja()
                    {
                        Id = listaTipaNamestaja.Count + 1,
                        Naziv = this.tbTipNaziv.Text,

                    };
                    listaTipaNamestaja.Add(noviTipNamestaja);
                    


                    break;
                case Operacija.IZMENA:

                    foreach (var tn in listaTipaNamestaja)
                    {
                        if (tn.Id == tipNamestaja.Id)
                        {
                            tn.Naziv = this.tbTipNaziv.Text;
                            break;
                        }
                    }
                    break;
            }

            Projekat.Instance.TipNamestaja = listaTipaNamestaja;
            Close();
        }
    }
}
