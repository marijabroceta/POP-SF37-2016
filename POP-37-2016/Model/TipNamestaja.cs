namespace POP_37_2016.Model
{
    public class TipNamestaja
    {
        public int Id { get; set; }
        public string Naziv { get; set; }
        public bool Obrisan { get; set; }

        public static TipNamestaja GetById(int Id)
        {
            foreach(var tip in Projekat.Instance.TipNamestaja)
            {
                if(tip.Id == Id)
                {
                    return tip;
                }
            }
        }
    }
}