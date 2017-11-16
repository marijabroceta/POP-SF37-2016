namespace POP_37_2016.Model
{
    public class Namestaj
    {
        public int Id { get; set; }
        public bool Obrisan { get; set; }
        public string Naziv { get; set; }
        public string Sifra { get; set; }
        public int? AkcijaId { get; set; }
        public double JedinicnaCena { get; set; }
        public int KolicinaUMagacinu { get; set; }
        public int? TipNamestajaId { get; set; }

        public static Namestaj GetById(int Id)
        {
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (namestaj.Id == Id)
                {
                    return namestaj;
                }
            }
            return null;
        }
    }
}