using POP_37_2016.Model;
using POP_SF_37_2016_GUI.UI;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace POP_SF_37_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            
        }



        private void LogIn(object sender, RoutedEventArgs e)
        {
            //var korisnik = Projekat.Instance.Korisnik;
            var korisnickoIme = this.tbKorisnickoIme.Text;
            var lozinka = this.tbLozinka.Password;
            //TipKorisnika tipKorisnika;
            bool pronasao = false;
            foreach (var korisnik in Projekat.Instance.Korisnik)
            {
                if (!korisnik.Obrisan && korisnik.KorisnickoIme == korisnickoIme && korisnik.Lozinka == lozinka)
                {
                    MessageBox.Show("Uspesno ste se ulogovali!");
                    this.Hide();
                    MenuWindow mW = new MenuWindow();
                    mW.Show();
                    pronasao = true;
                    break;
                }
                
            }

            if (!pronasao)
            {
                MessageBox.Show("Neuspesno ste se ulogovali!");
            }
        }
    }
}
