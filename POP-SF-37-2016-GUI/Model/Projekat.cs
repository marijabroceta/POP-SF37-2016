using POP_37_2016.Util;
using POP_SF_37_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_37_2016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; private set; } = new Projekat();

        public ObservableCollection<Namestaj> Namestaj { get; set; }
        public ObservableCollection<TipNamestaja> TipoviNamestaja { get; set; }
        public ObservableCollection<Korisnik> Korisnici { get; set; }
        public ObservableCollection<AkcijskaProdaja> AkcijskaProdaja { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection <ProdajaNamestaja> Prodaja { get; set; }
        public ObservableCollection<StavkaProdaje> StavkeProdaje { get; set; }
        public ObservableCollection<NaAkciji> NamestajNaAkciji { get; set; }
        public ObservableCollection<ProdataUsluga> ProdateUsluge { get; set; }
        public ObservableCollection<Salon> Salon { get; set; }

        private Projekat()
        {
            
            TipoviNamestaja = TipNamestaja.GetAll();
            Namestaj = Model.Namestaj.GetAll();
            Korisnici = Korisnik.GetAll();
            AkcijskaProdaja = Model.AkcijskaProdaja.GetAll();
            DodatnaUsluga = Model.DodatnaUsluga.GetAll();
            Prodaja = ProdajaNamestaja.GetAll();
            StavkeProdaje = StavkaProdaje.GetAll();
            NamestajNaAkciji = NaAkciji.GetAll();
            ProdateUsluge = ProdataUsluga.GetAll();
            Salon = Model.Salon.GetAll();

        }

    }
}
