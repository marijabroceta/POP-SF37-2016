using POP_37_2016.Model;
using POP_SF_37_2016_GUI.Model;
using POP_SF_37_2016_GUI.UI.Validacija;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace POP_SF_37_2016_GUI.UI
{
    /// <summary>
    /// Interaction logic for DodajStavkuWindow.xaml
    /// </summary>
    public partial class DodajStavkuWindow : Window
    {
        ICollectionView viewNamestaj;
        ICollectionView viewPretraga;

        public enum Operacija
        {
            DODAVANJE,
            IZMENA
        };

        private Operacija operacija;

        public StavkaProdaje StavkaProdaje { get; set; }

        public DodajStavkuWindow(StavkaProdaje stavkaProdaje, Operacija operacija)
        {
            InitializeComponent();

            this.operacija = operacija;
            StavkaProdaje = stavkaProdaje;
            viewNamestaj = CollectionViewSource.GetDefaultView(Projekat.Instance.Namestaj);
            viewNamestaj.Filter = PrikazFilter;

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.ItemsSource = viewNamestaj;

            tbKolicina.DataContext = stavkaProdaje;
        }

        private bool PrikazFilter(object obj)
        {
            return !((Namestaj)obj).Obrisan;
        }

        private void Dodaj_Click(object sender, RoutedEventArgs e)
        {
            switch (operacija)
            {
                case Operacija.DODAVANJE:
                    if (ForceValidation() == true)
                    {
                        return;
                    }
                    try
                    {
                        if ((dgNamestaj.SelectedItem != null) && (dgNamestaj.SelectedItem is Namestaj))
                        {
                            StavkaProdaje.Namestaj = dgNamestaj.SelectedItem as Namestaj;
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Morate obeleziti red", "Upozorenje", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                    

                    break;

                case Operacija.IZMENA:

                    break;
            }

            Close();
        }

        private void dgNamestaj_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            StavkaProdaje.Namestaj = dgNamestaj.SelectedItem as Namestaj;
            ValidacijaKolicina.Namestaj = StavkaProdaje.Namestaj;
        }

        private bool ForceValidation()
        {
            BindingExpression bindingExpression = tbKolicina.GetBindingExpression(TextBox.TextProperty);
            bindingExpression.UpdateSource();
            if (Validation.GetHasError(tbKolicina) == true)
            {
                return true;
            }
            return false;
        }

        private void PretraziStavku_Click(object sender, RoutedEventArgs e)
        {
            string naziv = tbPretraga.Text;
            viewPretraga = CollectionViewSource.GetDefaultView(Namestaj.PretragaNamestaja(naziv,Namestaj.TipPretrage.NAZIV));
            dgNamestaj.ItemsSource = viewPretraga;
        }
    }
}