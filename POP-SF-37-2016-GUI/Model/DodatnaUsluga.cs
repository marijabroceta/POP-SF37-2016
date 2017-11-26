
using System;
using System.ComponentModel;

namespace POP_37_2016.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {

        private int id;
        private double cena;
        private bool obrisan;
        private string naziv;

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


        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
            }
        }





        public object Clone()
        {
            return new DodatnaUsluga()
            {
                Id = id,
                Naziv = Naziv,
                Cena = cena,
                Obrisan = Obrisan
            };
        }

        public static DodatnaUsluga GetById(int Id)
        {
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (usluga.Id == Id)
                {
                    return usluga;
                }
            }
            return null;
        }
        public override string ToString()
        {
            return $"{Naziv},{Cena}";
        }

        public  event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    


}