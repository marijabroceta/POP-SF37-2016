using System;
using System.Collections.Generic;

namespace POP_37_2016.Model
{
    public class ProdajaNamestaja
    {
        public int Id { get; set; }
        public List<int> NamestajZaProdajuId { get; set; }
        public DateTime DatumProdaje { get; set; }
        public string BrojRacuna { get; set; }
        public string Kupac { get; set; }
        public const double PDV = 0.02;
        public List<int> DodatnaUslugaId { get; set; }
        public double UkupnaCena { get; set; }
    }
}