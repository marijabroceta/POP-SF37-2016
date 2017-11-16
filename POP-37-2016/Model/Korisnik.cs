namespace POP_37_2016.Model
{
    public enum TipKorisnika
    {
        Administrator ,
        Prodavac 
    }

    public class Korisnik
    {
        public int Id { get; set; }
        public bool Obrisan { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public string Lozinka { get; set; }
    }
}