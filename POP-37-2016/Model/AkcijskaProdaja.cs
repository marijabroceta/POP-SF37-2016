using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_37_2016.Model
{
    public class AkcijskaProdaja
    {
        public int Id { get; set; }
        public string NamestajNaPopustu { get; set; }
        public double Popust { get; set; }
        public DateTime DatumPocetka { get; set; }
        public DateTime DatumZavrsetka { get; set; }
        public double CenaSaPopustom { get; set; }
        public bool Obrisan { get; set; }
    }
}
