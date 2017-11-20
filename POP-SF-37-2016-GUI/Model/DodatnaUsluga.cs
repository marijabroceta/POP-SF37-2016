using System.ComponentModel;

namespace POP_37_2016.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged
    {
        public int Id { get; set; }
        public string NazivUsluge { get; set; }
        public double Cena { get; set; }
        public bool Obrisan { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public override string ToString()
        {
            return $"{NazivUsluge},{Cena}";
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