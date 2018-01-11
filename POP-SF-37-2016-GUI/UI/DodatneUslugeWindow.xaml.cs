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
    /// Interaction logic for DodatneUslugeWindow.xaml
    /// </summary>
    public partial class DodatneUslugeWindow : Window
    {

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;
        private DodatnaUsluga usluga;

        public DodatneUslugeWindow(DodatnaUsluga usluga, Operacija operacija)
        {
            InitializeComponent();

            this.usluga = usluga;
            this.operacija = operacija;

            tbNazivUsluge.DataContext = usluga;
            tbCenaUsluge.DataContext = usluga;
        }

       

        private void IzlazIzProzora(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void SacuvajIzmene(object sender, RoutedEventArgs e)
        {
            if (ForceValidation() == true)
            {
                return;
            }


            switch (operacija)
            {
                case Operacija.DODAVANJE:


                    DodatnaUsluga.Create(usluga);



                    break;
                case Operacija.IZMENA:


                    DodatnaUsluga.Update(usluga);
                    break;
            }

            
            Close();
        }

        private bool ForceValidation()
        {
            BindingExpression bindingExpression = tbNazivUsluge.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();
            BindingExpression bindingExpression1 = tbCenaUsluge.GetBindingExpression(TextBox.TextProperty);
            bindingExpression1.UpdateSource();
            if (Validation.GetHasError(tbNazivUsluge) == true || Validation.GetHasError(tbCenaUsluge))
            {
                return true;
            }
            return false;
        }
    }
}
