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
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {


        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private Namestaj namestaj;

        public NamestajWindow(Namestaj namestaj, Operacija operacija)
        {
            InitializeComponent();

            InicijalizujVrednosti(namestaj, operacija);
        }

        private void InicijalizujVrednosti(Namestaj namestaj, Operacija operacija)
        {
            this.namestaj = namestaj;
            this.operacija = operacija;

            this.tbNaziv.Text = namestaj.Naziv;
            this.tbSifra.Text = namestaj.Sifra;
            //CbAkcijaId();
            this.tbAkcijaId.Text = namestaj.AkcijaId.ToString();
            this.tbCena.Text = namestaj.JedinicnaCena.ToString();
            this.tbKolicina.Text = namestaj.KolicinaUMagacinu.ToString();
            this.tbTipNamestajaId.Text = namestaj.TipNamestajaId.ToString();
            //CbTipNamestajaId();

        }
        /*
        private void CbAkcijaId()
        {



            foreach (var akcija in Projekat.Instance.AkcijskaProdaja)
            {
                cbAkcijaId.Items.Add(akcija);

            }
            cbAkcijaId.SelectedIndex = 0;
        }

        private void CbTipNamestajaId()
        {



            foreach (var tip in Projekat.Instance.TipNamestaja)
            {
                cbTipNamestajaId.Items.Add(tip);

            }
            cbTipNamestajaId.SelectedIndex = 0;
        }*/

        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaj;
            

            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    var noviNamestaj = new Namestaj()
                    {
                        Id = listaNamestaja.Count + 1,
                        Naziv = this.tbNaziv.Text,
                        Sifra = this.tbSifra.Text,
                        AkcijaId = int.Parse(this.tbAkcijaId.Text),
                        JedinicnaCena = int.Parse(this.tbCena.Text),
                        KolicinaUMagacinu = int.Parse(this.tbKolicina.Text),
                        TipNamestajaId = int.Parse(this.tbTipNamestajaId.Text)


                    };
                    
                   
                    
                    listaNamestaja.Add(noviNamestaj);



                    break;
                case Operacija.IZMENA:

                    foreach (var n in listaNamestaja)
                    {
                        if (n.Id == namestaj.Id)
                        {
                            n.Naziv = this.tbNaziv.Text;
                            n.Sifra = this.tbSifra.Text;
                            n.AkcijaId = int.Parse(this.tbAkcijaId.Text);
                            n.JedinicnaCena = int.Parse(this.tbCena.Text);
                            n.KolicinaUMagacinu = int.Parse(this.tbKolicina.Text);
                            n.TipNamestajaId = int.Parse(this.tbTipNamestajaId.Text);
                            break;
                        }
                    }
                    break;
            }

            Projekat.Instance.Namestaj = listaNamestaja;
            Close();
        }
    }
}
