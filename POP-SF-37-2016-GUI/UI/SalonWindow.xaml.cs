using POP_37_2016.Model;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

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

        public SalonWindow(Salon salon, Operacija operacija)
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
            if(ForceValidation() == true)
            {
                return;
            }

            switch (operacija)
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

        private void Izadji_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private bool ForceValidation()
        {
            BindingExpression bindingExpression = tbNaziv.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();
            BindingExpression bindingExpression1 = tbTelefon.GetBindingExpression(TextBox.TextProperty);
            bindingExpression1.UpdateSource();
            BindingExpression bindingExpression2 = tbEmail.GetBindingExpression(TextBox.TextProperty);
            bindingExpression2.UpdateSource();
            BindingExpression bindingExpression3 = tbAdresa.GetBindingExpression(TextBox.TextProperty);
            bindingExpression3.UpdateSource();
            BindingExpression bindingExpression4 = tbAdresaInternetSajta.GetBindingExpression(TextBox.TextProperty);
            bindingExpression4.UpdateSource();
            BindingExpression bindingExpression5 = tbJMBG.GetBindingExpression(TextBox.TextProperty);
            bindingExpression5.UpdateSource();
            BindingExpression bindingExpression6 = tbPIB.GetBindingExpression(TextBox.TextProperty);
            bindingExpression6.UpdateSource();
            BindingExpression bindingExpression7 = tbBrojZiroRacuna.GetBindingExpression(TextBox.TextProperty);
            bindingExpression7.UpdateSource();


            if (Validation.GetHasError(tbNaziv) == true || Validation.GetHasError(tbTelefon) == true || 
                Validation.GetHasError(tbEmail) == true || Validation.GetHasError(tbAdresa) == true || 
                Validation.GetHasError(tbAdresaInternetSajta) == true || Validation.GetHasError(tbJMBG) == true || 
                Validation.GetHasError(tbPIB) == true || Validation.GetHasError(tbBrojZiroRacuna) == true)
            {
                return true;
            }
            return false;
        }
    }
}