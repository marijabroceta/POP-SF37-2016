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
    /// Interaction logic for KorisnikWindow.xaml
    /// </summary>
    public partial class KorisnikWindow : Window
    {
        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private Korisnik korisnik;

        public KorisnikWindow(Korisnik korisnik, Operacija operacija)
        {
            InitializeComponent();
            InicijalizujVrednosti(korisnik,operacija);
        }

       

        private void InicijalizujVrednosti(Korisnik korisnik, Operacija operacija)
        {
            this.korisnik = korisnik;
            this.operacija = operacija;

            this.tbIme.Text = korisnik.Ime;
            this.tbPrezime.Text = korisnik.Prezime;
            this.tbKorisnickoIme.Text = korisnik.KorisnickoIme;
            this.pbLozinka.Password = korisnik.Lozinka;
            cbTipKorisnika.Items.Add(TipKorisnika.Administrator);
            cbTipKorisnika.Items.Add(TipKorisnika.Prodavac);
            foreach (TipKorisnika tipKorisnika in cbTipKorisnika.Items)
            {
                if (tipKorisnika == korisnik.TipKorisnika)
                {
                    cbTipKorisnika.SelectedItem = tipKorisnika;
                    break;
                }
            }


        }
        
        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaKorisnika = Projekat.Instance.Korisnik;
            
            
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviKorisnik = new Korisnik()
                    {
                        Id = listaKorisnika.Count + 1,
                        Ime = this.tbIme.Text,
                        Prezime = this.tbPrezime.Text,
                        KorisnickoIme = this.tbKorisnickoIme.Text,
                        Lozinka = this.pbLozinka.Password.ToString(),
                       
                                               
                    };

                    if(this.cbTipKorisnika.SelectedIndex == 0)
                    {
                        noviKorisnik.TipKorisnika = TipKorisnika.Administrator;

                    }
                    else
                    {
                        noviKorisnik.TipKorisnika = TipKorisnika.Prodavac; 
                    }

                    
                    listaKorisnika.Add(noviKorisnik);



                    break;
                case Operacija.IZMENA:

                    foreach (var k in listaKorisnika)
                    {
                        if (k.Id == korisnik.Id)
                        {
                            k.Ime = this.tbIme.Text;
                            k.Prezime = this.tbPrezime.Text;
                            k.KorisnickoIme = this.tbKorisnickoIme.Text;
                            k.Lozinka = this.pbLozinka.Password;
                            if (this.cbTipKorisnika.SelectedIndex == 0)
                            {
                                k.TipKorisnika = TipKorisnika.Administrator;

                            }
                            else
                            {
                                k.TipKorisnika = TipKorisnika.Prodavac;
                            }
                            break;
                        }
                    }
                    break;
            }

            Projekat.Instance.Korisnik = listaKorisnika;
            Close();
        }

        
    }
}
