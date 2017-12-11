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
        public ObservableCollection<Korisnik> Korisnik { get; set; }
        public ObservableCollection<AkcijskaProdaja> AkcijskaProdaja { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection <ProdajaNamestaja> ProdajaNamestaja { get; set; }
        public ObservableCollection<Salon> Salon { get; set; }

        private Projekat()
        {
            TipoviNamestaja = TipNamestaja.GetAll();
            Namestaj = Model.Namestaj.GetAll();
            Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
            AkcijskaProdaja = GenericSerializer.Deserialize<AkcijskaProdaja>("akcijskaProdaja.xml");
            DodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
            ProdajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
            Salon = GenericSerializer.Deserialize<Salon>("salon.xml");

        }

    }
}
