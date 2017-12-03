using System.ComponentModel;

namespace POP_37_2016.Model
{
    public class Salon : INotifyPropertyChanged
    {
        private int id;
        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string adresaInternetSajta;
        private int pib;
        private string jmbg;
        private string brojZiroRacuna;
        private bool obrisan;


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        

        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        

        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }

        

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }

        }

        

        public string AdresaInternetSajta
        {
            get { return adresaInternetSajta; }
            set
            {
                adresaInternetSajta = value;
                OnPropertyChanged("AdresaInternetSajta");
            }
        }

        

        public int PIB
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }

       

        public string JMBG
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged("JMBG");
            }
        }

       

        public string BrojZiroRacuna
        {
            get { return brojZiroRacuna; }
            set
            {
                brojZiroRacuna = value;
                OnPropertyChanged("BrojZiroRacuna");
            }
        }

       

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        public object Clone()
        {
            return new Salon()
            {
                Id = id,
                Naziv = naziv,
                Adresa = adresa,
                Telefon = telefon,
                Email = email,
                AdresaInternetSajta = adresaInternetSajta,
                PIB = pib,
                JMBG = jmbg,
                BrojZiroRacuna = brojZiroRacuna,
                Obrisan = obrisan
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}