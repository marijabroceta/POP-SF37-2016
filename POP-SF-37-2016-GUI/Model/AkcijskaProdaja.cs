using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Xml.Serialization;

namespace POP_37_2016.Model
{
    public class AkcijskaProdaja : INotifyPropertyChanged
    {
        private int id;
        private string naziv;
        private double popust;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private ObservableCollection<Namestaj> namestajNaAkciji;
       
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


        public double Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }


        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }

       

        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }
        }

        

        public ObservableCollection<Namestaj> NamestajNaAkciji
        {
            get { return namestajNaAkciji; }
            set
            {
                namestajNaAkciji = value;
                OnPropertyChanged("NamestajNaAkcijiId");
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


        
        public override string ToString()
        {

            return $"{DatumPocetka.ToShortDateString()} - {DatumZavrsetka.ToShortDateString()}";
            
        }

        public static AkcijskaProdaja GetById(int Id)
        {
            foreach (var akcija in Projekat.Instance.AkcijskaProdaja)
            {
                if (akcija.Id == Id)
                {
                    return akcija;
                }
            }
            return null;
        }

        

        public object Clone()
        {
            return new AkcijskaProdaja()
            {
                Popust = popust,
                DatumPocetka = datumPocetka,
                DatumZavrsetka = datumZavrsetka,
                NamestajNaAkciji = new ObservableCollection<Namestaj>(NamestajNaAkciji),
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