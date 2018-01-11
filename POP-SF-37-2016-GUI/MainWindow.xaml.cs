using POP_37_2016.Model;
using POP_SF_37_2016_GUI.UI;
using System.Windows;

namespace POP_SF_37_2016_GUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public static string TrenutnoLogovan { get; set; }

        public MainWindow()
        {
            InitializeComponent();
        }

        private void LogIn(object sender, RoutedEventArgs e)
        {
            var korisnickoIme = this.tbKorisnickoIme.Text;
            var lozinka = this.tbLozinka.Password;
            TipKorisnika tipKorisnika;
            bool pronasao = false;
            foreach (var korisnik in Projekat.Instance.Korisnici)
            {
                if (!korisnik.Obrisan && korisnik.KorisnickoIme == korisnickoIme && korisnik.Lozinka == lozinka)
                {
                    tipKorisnika = korisnik.TipKorisnika;
                    switch (tipKorisnika)
                    {
                        case TipKorisnika.Administrator:

                            this.Hide();
                            TrenutnoLogovan = korisnickoIme;
                            MenuWindow mW = new MenuWindow();
                            mW.Show();
                            pronasao = true;
                            break;

                        case TipKorisnika.Prodavac:

                            this.Hide();
                            TrenutnoLogovan = korisnickoIme;
                            ProdajaNamestajaProzor pn = new ProdajaNamestajaProzor();
                            pn.Show();
                            pronasao = true; ;
                            break;
                    }

                    break;
                }
                else if (korisnik.KorisnickoIme == "" || korisnik.Lozinka == "")
                {
                    MessageBox.Show("Morate uneti korisnicko ime i lozinku");
                }
            }
            if (!pronasao)
            {
                MessageBox.Show("Neuspesno ste se ulogovali!");
            }
        }

        private void Odustani_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}