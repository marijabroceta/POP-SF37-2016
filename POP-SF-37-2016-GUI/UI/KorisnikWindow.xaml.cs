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

            this.korisnik = korisnik;
            this.operacija = operacija;

            cbTipKorisnika.ItemsSource = Enum.GetValues(typeof(TipKorisnika)).Cast<TipKorisnika>();

            tbIme.DataContext = korisnik;
            tbPrezime.DataContext = korisnik;
            tbKorisnickoIme.DataContext = korisnik;
            tbLozinka.DataContext = korisnik;
            cbTipKorisnika.DataContext = korisnik;
            
            
        }     

      
        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            if(ForceValidation() == true)
            {
                return;
            }
            
            
            switch (operacija)
            {
                case Operacija.DODAVANJE:

                    Korisnik.Create(korisnik);
                    break;

                case Operacija.IZMENA:

                    Korisnik.Update(korisnik);
                    break;
            }

           
            Close();
        }

        private bool ForceValidation()
        {
            BindingExpression bindingExpression = tbIme.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();
            BindingExpression bindingExpression1 = tbKorisnickoIme.GetBindingExpression(TextBox.TextProperty);
            bindingExpression1.UpdateSource();
            BindingExpression bindingExpression2 = tbLozinka.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();
            BindingExpression bindingExpression3 = tbPrezime.GetBindingExpression(TextBox.TextProperty);
            bindingExpression1.UpdateSource();
            if (Validation.GetHasError(tbIme) == true || Validation.GetHasError(tbKorisnickoIme) || Validation.GetHasError(tbLozinka) || Validation.GetHasError(tbPrezime))
            {
                return true;
            }
            return false;
        }
    }
}
