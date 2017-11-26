using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POP_37_2016.Model
{
    public class AkcijskaProdaja : INotifyPropertyChanged
    {
        private int id;
        private decimal popust;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private List<int> namestajNaAkcijiId;
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

        

        public decimal Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }
/*
        private DateTime starttime
        {
            get
            {
                return DateTime.Parse(StartTimeText.Text);
            }
            set
            {
                StartTimeText.Text = value.ToString();
                OnPropertyChanged("starttime");
            }
        }*/

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

        

        public List<int> NamestajNaAkcijiId
        {
            get { return namestajNaAkcijiId; }
            set
            {
                namestajNaAkcijiId = value;
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
                DatumZavrsetka = DatumZavrsetka,
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