using System.ComponentModel;

namespace POP_37_2016.Model
{
    
    public enum TipKorisnika
    {
        Administrator ,
        Prodavac 
    }

    

    public class Korisnik : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public bool Obrisan { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string KorisnickoIme { get; set; }
        public TipKorisnika TipKorisnika { get; set; }
        public string Lozinka { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{Ime},{Prezime},{KorisnickoIme}"; 
        }

        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }

    


}