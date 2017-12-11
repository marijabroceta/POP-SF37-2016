using POP_37_2016.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF_37_2016_GUI.Model
{
    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {

        private int id;
        private DateTime datumProdaje;
        private string brojRacuna;
        private string kupac;
        private double ukupnaCenaSaPDV;
        private double ukupnaCenaBezPDV;
        public const double PDV = 0.02;

        //public ObservableCollection<int> namestajZaProdajuId;
        //public ObservableCollection<int> DodatnaUslugaId { get; set; }
        public ObservableCollection<StavkaProdaje> Stavka { get; set; }
        //public ObservableCollection<DodatnaUsluga> DodatnaUslugaZaProdaju{ get; set; }
        //public ObservableCollection<Namestaj> NamestajZaProdaju { get; set; }
    /*
    [XmlIgnore]
    public ObservableCollection<Namestaj> NamestajZaProdaju
    {
        get
        {
            if (namestajZaProdaju == null)
            {
                namestajZaProdaju = Namestaj.GetNamestaj(NamestajZaProdajuId);
            }
            return namestajZaProdaju;
        }
        set
        {
            namestajZaProdaju = value;
            NamestajZaProdajuId = Namestaj.GetByListId(namestajZaProdaju);
            OnPropertyChanged("NamestajZaProdaju");
        }
    }




    public ObservableCollection<int> NamestajZaProdajuId
    {
        get { return namestajZaProdajuId; }
        set
        {
            namestajZaProdajuId = value;
            OnPropertyChanged("NamestajZaProdajuId");
        }
    }*/

    public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }



        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }


        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }



        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }



        public double UkupnaCenaSaPDV
        {
            get { return ukupnaCenaSaPDV; }
            set
            {
                ukupnaCenaSaPDV = value;
                OnPropertyChanged("UkupnaCenaSaPDV");
            }
        }


        

        public double UkupnaCenaBezPDV
        {
            get { return ukupnaCenaBezPDV; }
            set
            {
                ukupnaCenaBezPDV = value;
                OnPropertyChanged("UkupnaCenaBezPDV");
            }
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
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new ProdajaNamestaja()
            {
                Id = id,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                UkupnaCenaSaPDV = ukupnaCenaSaPDV,
                UkupnaCenaBezPDV = ukupnaCenaBezPDV,
                Stavka = new ObservableCollection<StavkaProdaje>(Stavka)
                //NamestajZaProdaju = new ObservableCollection<Namestaj>(NamestajZaProdaju),
                //DodatnaUslugaZaProdaju = new ObservableCollection<DodatnaUsluga>(DodatnaUslugaZaProdaju)
            };
        }
    }

}
