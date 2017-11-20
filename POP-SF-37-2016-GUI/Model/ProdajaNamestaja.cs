using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace POP_37_2016.Model
{
    public class ProdajaNamestaja : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public List<int> NamestajZaProdajuId { get; set; }
        public DateTime DatumProdaje { get; set; }
        public string BrojRacuna { get; set; }
        public string Kupac { get; set; }
        public const double PDV = 0.02;

        public event PropertyChangedEventHandler PropertyChanged;

        public List<int> DodatnaUslugaId { get; set; }
        public double UkupnaCena { get; set; }
        /*
        public override string ToString()
        {
            
            return $"{Namestaj.GetById(NamestajZaProdajuId.Count)}{DatumProdaje.ToShortDateString()},{BrojRacuna},{Kupac},{UkupnaCena}";
        }

        public static ProdajaNamestaja GetById(int Id)
        {
            foreach (var prodaja in Projekat.Instance.ProdajaNamestaja)
            {
                if (prodaja.Id == Id)
                {
                    return prodaja;
                }
            }
            return null;
        }*/


        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

    }
}