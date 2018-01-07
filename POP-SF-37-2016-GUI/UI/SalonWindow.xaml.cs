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
    /// Interaction logic for SalonWindow.xaml
    /// </summary>
    public partial class SalonWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private Salon salon;

        public SalonWindow(Salon salon,Operacija operacija)
        {
            InitializeComponent();

            this.operacija = operacija;
            this.salon = salon;

            tbNaziv.DataContext = salon;
            tbAdresa.DataContext = salon;
            tbEmail.DataContext = salon;
            tbJMBG.DataContext = salon;
            tbTelefon.DataContext = salon;
            tbPIB.DataContext = salon;
            tbAdresaInternetSajta.DataContext = salon;
            tbBrojZiroRacuna.DataContext = salon;
        }

        private void SacuvajIzmene_Click(object sender, RoutedEventArgs e)
        {
            var listaSalona = Projekat.Instance.Salon;

            switch(operacija)
            {
                case Operacija.DODAVANJE:

                    Salon.Create(salon);
                    break;
                case Operacija.IZMENA:

                    Salon.Update(salon);
                    break;
                
            }

            
            Close();
        }
    }
}
