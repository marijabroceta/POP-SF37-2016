
using POP_SF_37_2016_GUI.Model;
using System;
using System.ComponentModel;

namespace POP_37_2016.Model
{
    public class DodatnaUsluga :StavkaProdaje, INotifyPropertyChanged, ICloneable
    {

       //private int id;
        private double cena;
        private bool obrisan;
        private string naziv;
        /*
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }*/

        

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





        public new  object Clone()
        {
            return new DodatnaUsluga()
            {
                Id = Id,
                Naziv = Naziv,
                Cena = Cena,
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

        public new event PropertyChangedEventHandler PropertyChanged;
        protected new void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    


}