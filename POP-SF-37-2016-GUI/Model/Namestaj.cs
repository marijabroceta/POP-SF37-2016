
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Xml.Serialization;

namespace POP_37_2016.Model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string sifra;
        private int akcijaId;
        private double jedinicnaCena;
        private int kolicinaUMagacinu;
        private int tipNamestajaId;
       
        private TipNamestaja tipNamestaja;
        private AkcijskaProdaja akcijskaProdaja;

        [XmlIgnore]
        public AkcijskaProdaja AkcijskaProdaja
        {
            get
            {
                if(akcijskaProdaja == null)
                {
                    akcijskaProdaja = AkcijskaProdaja.GetById(AkcijaId);
                }
                return akcijskaProdaja;
            }
            set
            {
                akcijskaProdaja = value;
                AkcijaId = akcijskaProdaja.Id;
                OnPropertyChanged("AkcijskaProdaja");
            }
        }

        public int AkcijaId
        {
            get { return akcijaId; }
            set
            {
                akcijaId = value;
                OnPropertyChanged("Akcija");
            }
        }




        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if(tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(TipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");

            }
        }

        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("Tip namestaja");
            }
        }

       

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






        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("Kolicina");
            }
        }


        public double JedinicnaCena
        {
            get { return jedinicnaCena; }
            set
            {
                jedinicnaCena = value;
                OnPropertyChanged("Cena");
            }
        }


        


        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }

        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        public static Namestaj GetById(int Id)
        {
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Id == Id)
                {
                    return namestaj;
                }
            }
            return null;
        }

        public static ObservableCollection<Namestaj> GetNamestaj(ObservableCollection<int> id)
        {
            ObservableCollection<Namestaj> namestaj = new ObservableCollection<Namestaj>();
            if(id != null)
            {
                for (int i = 0; i < id.Count; i++)
                {
                    namestaj.Add(GetById(id[i]));
                }
                return namestaj;
            }
            return null;
        }
        public static ObservableCollection<int> GetByListId(ObservableCollection<Namestaj> namestaj)
        {
            var listaId = new ObservableCollection<int>();
            if(namestaj != null)
            {
                for (int i = 0; i < namestaj.Count; i++)
                {
                    listaId.Add(namestaj[i].Id);
                }
                return listaId;
            }
            return null;
        }



        public object Clone()
        {
            return new Namestaj()
            {
                Id = id,
                Naziv = naziv,
                Sifra = sifra,
                JedinicnaCena = jedinicnaCena,
                TipNamestaja = tipNamestaja,
                TipNamestajaId = tipNamestajaId,
                AkcijaId = akcijaId,
                KolicinaUMagacinu = kolicinaUMagacinu,
                Obrisan = obrisan
               


            };
        }

        public Namestaj() { }

        public Namestaj(int id)
        {
            Id = id;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}