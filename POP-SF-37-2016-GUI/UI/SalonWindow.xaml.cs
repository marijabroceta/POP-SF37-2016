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

                    salon.Id = listaSalona.Count + 1;
                    listaSalona.Add(salon);
                    break;
                case Operacija.IZMENA:

                    foreach (var s in listaSalona)
                    {
                        if (s.Id == salon.Id)
                        {
                            s.Naziv = salon.Naziv;
                            s.Adresa = salon.Adresa;
                            s.Email = salon.Email;
                            s.Telefon = salon.Email;
                            s.JMBG = salon.JMBG;
                            s.PIB = salon.PIB;
                            s.AdresaInternetSajta = salon.AdresaInternetSajta;
                            s.BrojZiroRacuna = salon.BrojZiroRacuna;
                            break;
                        }
                    }
                    break;
                
            }

            GenericSerializer.Serialize("salon.xml", listaSalona);
            Close();
        }
    }
}
