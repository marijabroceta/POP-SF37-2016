using System;

namespace POP_37_2016.Model
{
    public class AkcijskaProdaja
    {
        public int Id { get; set; }

        //public List<Namestaj> NamestajNaPopustu { get; set; }
        public decimal Popust { get; set; }

        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public bool Obrisan { get; set; }
    }
}