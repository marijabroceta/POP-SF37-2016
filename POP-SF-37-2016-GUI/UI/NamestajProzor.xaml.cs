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
    /// Interaction logic for NamestajProzor.xaml
    /// </summary>
    public partial class NamestajProzor : Window
    {


        public Namestaj IzabraniNamestaj { get; set; }

        public NamestajProzor()
        {
            InitializeComponent();

            dgNamestaj.IsSynchronizedWithCurrentItem = true;
            dgNamestaj.DataContext = this;
            dgNamestaj.ItemsSource = Projekat.Instance.Namestaj;


        }

        

        private void DodajNamestaj_Click(object sender, RoutedEventArgs e)
        {
            var noviNamestaj = new Namestaj()
            {
                Naziv = ""
            };
            var namestajProzor = new NamestajWindow(noviNamestaj, NamestajWindow.Operacija.DODAVANJE);
            namestajProzor.ShowDialog();

        }
        
        private void IzmeniNamestaj_Click(object sender, RoutedEventArgs e)
        {
            Namestaj kopija =(Namestaj)IzabraniNamestaj.Clone();
            var namestajProzor = new NamestajWindow(kopija, NamestajWindow.Operacija.IZMENA);
            
            namestajProzor.Show();

            
        }
        
        private void ZatvoriProzor_Click(object sender, RoutedEventArgs e)
        {

            this.Close();
        }

        private void ObrisiNamstaj_Click(object sender, RoutedEventArgs e)
        {
            
            var listaNamestaja = Projekat.Instance.Namestaj;

            if(MessageBox.Show($"Da li zelite da obrisete {IzabraniNamestaj.Naziv} ?","Brisanje", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                foreach (var n in listaNamestaja)
                {
                    if(n.Id == IzabraniNamestaj.Id)
                    {
                        n.Obrisan = true;
                        break;
                    }
                }

                GenericSerializer.Serialize("namestaj.xml", listaNamestaja);
              
            }
        }

       
        /*
        private void Pretraga_Click(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaj;
            if (cbPretraga.SelectedIndex == 0)
            {
                lbNamestaj.Items.Clear();

                foreach (var namestaj in listaNamestaja)
                {
                    var izabraniNamestaj = tbPretraga.Text;
                    if (izabraniNamestaj.ToUpper() == namestaj.Naziv.ToUpper())
                    {
                        for (int i = 0; i < listaNamestaja.Count; i++)
                        {
                            if (!listaNamestaja[i].Obrisan)
                            {
                                lbNamestaj.Items.Add(namestaj);
                                break;
                            }
                        }
                    }

                }
            }
            else if(cbPretraga.SelectedIndex == 1)
            {
                lbNamestaj.Items.Clear();

                foreach (var namestaj in listaNamestaja)
                {
                    var izabraniNamestaj = tbPretraga.Text;
                    if (izabraniNamestaj.ToUpper() == namestaj.Sifra.ToUpper())
                    {
                        for (int i = 0; i < listaNamestaja.Count; i++)
                        {
                            if (!listaNamestaja[i].Obrisan)
                            {
                                lbNamestaj.Items.Add(namestaj);
                                break;
                            }
                        }
                    }

                }
            }

            else if(cbPretraga.SelectedIndex == 2)
            {

                lbNamestaj.Items.Clear();
                foreach (var namestaj in listaNamestaja)
                {
                    var izabraniNamestaj = tbPretraga.Text;
                    if (izabraniNamestaj.ToUpper() == namestaj.Sifra.ToUpper())
                    {
                        for (int i = 0; i < listaNamestaja.Count; i++)
                        {
                            if (!listaNamestaja[i].Obrisan)
                            {
                                lbNamestaj.Items.Add(namestaj);
                                break;
                            }
                        }
                    }

                }
            }

            

        }

        private void Sortiraj_Click(object sender, RoutedEventArgs e)
        {
            var listaNamestaja = Projekat.Instance.Namestaj;
            lbNamestaj.Items.Clear();
            if ((string)cbSortiranje.SelectionBoxItem == "po nazivu")
            {

                listaNamestaja.Sort((x, y) => string.Compare(x.Naziv, y.Naziv));
                foreach (Namestaj namestaj in listaNamestaja)
                {
                    if (namestaj.Obrisan == false)
                    {
                        lbNamestaj.Items.Add(namestaj);
                        
                    }

                }

            }
            else if((string)cbSortiranje.SelectionBoxItem == "po sifri")
            {
                listaNamestaja.Sort((x, y) => string.Compare(x.Sifra, y.Sifra));
                foreach (Namestaj namestaj in listaNamestaja)
                {
                    if (namestaj.Obrisan == false)
                    {
                        lbNamestaj.Items.Add(namestaj);

                    }

                }
            }
            else if((string)cbSortiranje.SelectionBoxItem == "po ceni")
            {
                listaNamestaja.Sort((x, y) => string.Compare(x.JedinicnaCena.ToString(), y.JedinicnaCena.ToString()));
                foreach (Namestaj namestaj in listaNamestaja)
                {
                    if (namestaj.Obrisan == false)
                    {
                        lbNamestaj.Items.Add(namestaj);

                    }

                }
            }
            else if((string)cbSortiranje.SelectionBoxItem == "po tipu namestaja")
            {
                listaNamestaja.Sort((x, y) => string.Compare(x.TipNamestajaId.ToString(), y.TipNamestajaId.ToString()));
                foreach (Namestaj namestaj in listaNamestaja)
                {
                    if (namestaj.Obrisan == false)
                    {
                        lbNamestaj.Items.Add(namestaj);

                    }

                }
            }


        }*/
       
    }
}
