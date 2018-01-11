using POP_37_2016.Model;
using POP_SF_37_2016_GUI.Model;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF_37_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for NamestajWindow.xaml
    /// </summary>
    public partial class NamestajWindow : Window
    {
        private ICollectionView viewAkcija;
        private ICollectionView viewTipNamestaja;

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

            viewAkcija = CollectionViewSource.GetDefaultView(Projekat.Instance.AkcijskaProdaja);
            viewTipNamestaja = CollectionViewSource.GetDefaultView(Projekat.Instance.TipoviNamestaja);

            this.namestaj = namestaj;
            this.operacija = operacija;

            cbAkcijaId.ItemsSource = viewAkcija;
            cbTipNamestajaId.ItemsSource = viewTipNamestaja;

            viewAkcija.Filter = PrikazFilterAkcija;
            viewTipNamestaja.Filter = PrikazFilterTipNamestaja;

            tbNaziv.DataContext = namestaj;
            tbCena.DataContext = namestaj;
            tbKolicina.DataContext = namestaj;
            cbTipNamestajaId.DataContext = namestaj;
            cbAkcijaId.DataContext = namestaj;
        }

        private bool PrikazFilterAkcija(object obj)
        {
            return !((AkcijskaProdaja)obj).Obrisan;
        }

        private bool PrikazFilterTipNamestaja(object obj)
        {
            return !((TipNamestaja)obj).Obrisan;
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

                    Namestaj.Create(namestaj);

                    if (cbAkcijaId.SelectedItem != null)
                    {
                        var naAkciji = new NaAkciji();
                        naAkciji.AkcijskaProdajaId = namestaj.AkcijaId;
                        naAkciji.NamestajId = this.namestaj.Id;

                        NaAkciji.Create(naAkciji);

                        namestaj.CenaNaAkciji = namestaj.JedinicnaCena - namestaj.JedinicnaCena * (namestaj.AkcijskaProdaja.Popust / 100);
                        Namestaj.Update(namestaj);
                    }

                    break;

                case Operacija.IZMENA:

                    Namestaj.Update(namestaj);

                    break;
            }

            Close();
        }

        private bool ForceValidation()
        {
            BindingExpression bindingExpression = tbNaziv.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();
            BindingExpression bindingExpression1 = tbCena.GetBindingExpression(TextBox.TextProperty);
            bindingExpression1.UpdateSource();
            BindingExpression bindingExpression2 = tbKolicina.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();

            if (Validation.GetHasError(tbNaziv) == true || Validation.GetHasError(tbCena) || Validation.GetHasError(tbKolicina))
            {
                return true;
            }
            return false;
        }
    }
}