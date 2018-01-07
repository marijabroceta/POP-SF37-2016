using POP_37_2016.Model;
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
    /// Interaction logic for PrikazNamestajaNaAkciji.xaml
    /// </summary>
    public partial class PrikazNamestajaNaAkciji : Window
    {

        private AkcijskaProdaja akcijskaProdaja;
        private ObservableCollection<NaAkciji> izabranaAkcija;

        public PrikazNamestajaNaAkciji(ObservableCollection<NaAkciji> izabranaAkcija,AkcijskaProdaja akcijskaProdaja)
        {
            InitializeComponent();

            this.akcijskaProdaja = akcijskaProdaja;
            this.izabranaAkcija = izabranaAkcija;

            izabranaAkcija = NaAkciji.GetAllId(akcijskaProdaja.Id);

            dgNamestajAkcija.ItemsSource = izabranaAkcija;
        }
    }
}
