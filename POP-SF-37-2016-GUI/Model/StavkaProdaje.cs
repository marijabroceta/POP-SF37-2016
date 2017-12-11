using POP_37_2016.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_37_2016_GUI.Model
{
    public class StavkaProdaje: INotifyPropertyChanged
    {
        private int id;      
        private int kolicina;
        private Namestaj namestaj;
        private DodatnaUsluga dodatnaUsluga;
       


        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        

        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("Kolicina");
            }

        }


       
        public Namestaj Namestaj
        {
            get { return namestaj; }
            set
            {
                namestaj = value;
                OnPropertyChanged("Namestaj");
            }
        }

        

        public DodatnaUsluga DodatnaUsluga
        {
            get { return dodatnaUsluga; }
            set
            {
                dodatnaUsluga = value;
                OnPropertyChanged("DodatnaUsluga");
            }
        }





        



        public object Clone()
        {
            return new StavkaProdaje()
            {
                Id = id,                
                Kolicina = kolicina,
                Namestaj = namestaj,
                DodatnaUsluga = dodatnaUsluga,
               
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
