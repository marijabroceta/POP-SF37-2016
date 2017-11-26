using System;
using System.ComponentModel;

namespace POP_37_2016.Model
{
    public class TipNamestaja: INotifyPropertyChanged, ICloneable
    {

        private int id;
        private string naziv;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set
            { obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        public string Naziv
        {
            get { return naziv; }
            set
            { naziv = value;
                OnPropertyChanged("Naziv");
            }
        }


        public int Id
        {
            get { return id; }
            set
            { id = value;
                OnPropertyChanged("Id");
            }
        }

       

       
        
        public override string ToString()
        {
            return $"{Naziv}";
        }

        public static TipNamestaja GetById(int? Id)
        {
            foreach(var tip in Projekat.Instance.TipNamestaja)
            {
                if(tip.Id == Id)
                {
                    return tip;
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new TipNamestaja
            {
                Id = id,
                Naziv = naziv,
                Obrisan = obrisan
            };
        }
    }

    
}