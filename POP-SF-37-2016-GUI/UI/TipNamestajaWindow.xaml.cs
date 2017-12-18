using POP_37_2016.Model;
using POP_37_2016.Util;
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

            this.tipNamestaja = tipNamestaja;
            this.operacija = operacija;

            tbTipNaziv.DataContext = tipNamestaja;

        }

        

        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaTipaNamestaja = Projekat.Instance.TipoviNamestaja;

            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    TipNamestaja.Create(tipNamestaja);
                    break;
                case Operacija.IZMENA:

                    TipNamestaja.Update(tipNamestaja);
                    break;
            }

            GenericSerializer.Serialize("tipNamestaja.xml", listaTipaNamestaja);
            Close();
        }
    }
}
