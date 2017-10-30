using POP_37_2016.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_37_2016.Model
{
    public class Projekat
    {
        public static Projekat Instance { get; } = new Projekat();

        private List<Namestaj> namestaj;

        public List<Namestaj> Namestaj
        {
            get
            {
                this.namestaj = GenericSerializer.Deserialize<Namestaj>("namestaj.xml");
                return this.namestaj;
            }
            set
            {
                namestaj = value;
                GenericSerializer.Serialize<Namestaj>("namestaj.xml", namestaj);
                
            }
        }

        private List<TipNamestaja> tipNamestaja;

        public List<TipNamestaja> TipNamestaja
        {
            get
            {
                this.tipNamestaja = GenericSerializer.Deserialize<TipNamestaja>("tipNamestaja.xml");
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                GenericSerializer.Serialize<TipNamestaja>("tipNamestaja.xml", tipNamestaja);
            }
        }
        private List<Korisnik> korisnik;

        public List<Korisnik> Korisnik
        {
            get
            {
                this.korisnik = GenericSerializer.Deserialize<Korisnik>("korisnici.xml");
                return korisnik;
            }
            set
            {
                korisnik = value;
                GenericSerializer.Serialize<Korisnik>("korisnici.xml", korisnik);
            }
        }

        private List<AkcijskaProdaja> akcija;

        public List<AkcijskaProdaja> Akcija
        {
            get
            {
                this.akcija = GenericSerializer.Deserialize<AkcijskaProdaja>("akcijskaProdaja.xml");
                return akcija;
            }
            set
            {
                akcija = value;
                GenericSerializer.Serialize<AkcijskaProdaja>("akcijskaProdaja.xml", akcija);
            }
        }

        private List<DodatnaUsluga> dodatnaUsluga;

        public List<DodatnaUsluga> DodatnaUsluga
        {
            get
            {
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
            }
        }





    }
}
