using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Serialization;

namespace POP_37_2016.Model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string sifra;
        private int? akcijaId;
        private double jedinicnaCena;
        private int kolicinaUMagacinu;
        private int? tipNamestajaId;
        private bool obrisan;
        private TipNamestaja tipNamestaja;
        private AkcijskaProdaja akcijskaProdaja;

        public AkcijskaProdaja AkcijskaProdaja
        {
            get { return akcijskaProdaja; }
            set { akcijskaProdaja = value; }
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


        public bool Obrisan
        {
            get { return obrisan; }
            set { obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        public int? TipNamestajaId
        {
            get { return tipNamestajaId; }
            set { tipNamestajaId = value;
                OnPropertyChanged("Tip namestaja");
            }
        }


        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set { kolicinaUMagacinu = value;
                OnPropertyChanged("Kolicina");
            }
        }


        public double JedinicnaCena
        {
            get { return jedinicnaCena; }
            set { jedinicnaCena = value;
                OnPropertyChanged("Cena");
            }
        }


        public int? AkcijaId
        {
            get { return akcijaId; }
            set { akcijaId = value;
                OnPropertyChanged("Akcija");
            }
        }


        public string Sifra
        {
            get { return sifra; }
            set { sifra = value;
                OnPropertyChanged("Sifra");
            }
        }



        public string Naziv
        {
            get { return naziv; }
            set { naziv = value;
                OnPropertyChanged("Naziv");
            }
        }


        public int Id
        {
            get { return id; }
            set {
                    id = value;
                    OnPropertyChanged("Id");
                }

        }

       
        public event PropertyChangedEventHandler PropertyChanged;
        /*
        public override string ToString()
        {
            return $"Sifra:{Sifra}, Naziv: {Naziv}, Cena: {JedinicnaCena}, Tip namestaja: {TipNamestaja.GetById(TipNamestajaId).Naziv}";
        }*/

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

        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}