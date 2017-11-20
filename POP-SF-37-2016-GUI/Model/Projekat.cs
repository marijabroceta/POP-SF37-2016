using POP_37_2016.Util;
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
        public ObservableCollection<TipNamestaja> TipNamestaja { get; set; }
        public ObservableCollection<Korisnik> Korisnik { get; set; }
        public ObservableCollection<AkcijskaProdaja> AkcijskaProdaja { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatnaUsluga { get; set; }
        public ObservableCollection<ProdajaNamestaja> ProdajaNamestaja{ get; set; }

        private Projekat()
        {
            TipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipNamestaja.xml");
            Namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
            Korisnik = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
            AkcijskaProdaja = GenericSerializer.Deserialize<AkcijskaProdaja>("akcijskaProdaja.xml");
            DodatnaUsluga = GenericSerializer.Deserialize<DodatnaUsluga>("dodatnaUsluga.xml");
            ProdajaNamestaja = GenericSerializer.Deserialize<ProdajaNamestaja>("prodajaNamestaja.xml");
        }

    }
}
