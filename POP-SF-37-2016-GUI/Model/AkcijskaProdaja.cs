using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POP_37_2016.Model
{
    public class AkcijskaProdaja : INotifyPropertyChanged
    {
        public int Id { get; set; }

        
        public decimal Popust { get; set; }

        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public List<int> NamestajNaAkcijiId { get; set; }

        
        public bool Obrisan { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {

            return $"{DatumPocetka.ToShortDateString()} - {DatumZavrsetka.ToShortDateString()}";
            
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    
}