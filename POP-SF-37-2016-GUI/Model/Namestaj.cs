
using POP_SF_37_2016_GUI.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Xml.Serialization;

namespace POP_37_2016.Model
{
    public class Namestaj :  INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string sifra;
        private int akcijaId;
        private double jedinicnaCena;
        private int kolicinaUMagacinu;
        private int tipNamestajaId;
        private bool obrisan;

        private TipNamestaja tipNamestaja;
        private AkcijskaProdaja akcijskaProdaja;

        [XmlIgnore]
        public AkcijskaProdaja AkcijskaProdaja
        {
            get
            {
                if(akcijskaProdaja == null)
                {
                    akcijskaProdaja = AkcijskaProdaja.GetById(AkcijaId);
                }
                return akcijskaProdaja;
            }
            set
            {
                akcijskaProdaja = value;
                AkcijaId = akcijskaProdaja.Id;
                OnPropertyChanged("AkcijskaProdaja");
            }
        }

        public int AkcijaId
        {
            get { return akcijaId; }
            set
            {
                akcijaId = value;
                OnPropertyChanged("Akcija");
            }
        }




        [XmlIgnore]
        public TipNamestaja TipNamestaja
        {
            get
            {
                if(tipNamestaja == null)
                {
                    tipNamestaja = TipNamestaja.GetById(TipNamestajaId);
                }
                return tipNamestaja;
            }
            set
            {
                tipNamestaja = value;
                TipNamestajaId = tipNamestaja.Id;
                OnPropertyChanged("TipNamestaja");

            }
        }

        public int TipNamestajaId
        {
            get { return tipNamestajaId; }
            set
            {
                tipNamestajaId = value;
                OnPropertyChanged("Tip namestaja");
            }
        }

       
        
        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

       

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }






        public int KolicinaUMagacinu
        {
            get { return kolicinaUMagacinu; }
            set
            {
                kolicinaUMagacinu = value;
                OnPropertyChanged("Kolicina");
            }
        }


        public double JedinicnaCena
        {
            get { return jedinicnaCena; }
            set
            {
                jedinicnaCena = value;
                OnPropertyChanged("Cena");
            }
        }


        


        public string Sifra
        {
            get { return sifra; }
            set
            {
                sifra = value;
                OnPropertyChanged("Sifra");
            }
        }
        
       

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


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

        
        



        public  object Clone()
        {
            return new Namestaj()
            {
                
                Sifra = sifra,
                Naziv = naziv,
                JedinicnaCena = jedinicnaCena,
                KolicinaUMagacinu = kolicinaUMagacinu,
                TipNamestaja = tipNamestaja,
                TipNamestajaId = tipNamestajaId,
                AkcijaId = akcijaId,
                
               


            };
        }

        public Namestaj() { }

        public Namestaj(int id)
        {
            Id = id;
        }
        public  event PropertyChangedEventHandler PropertyChanged;
        protected  void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region CRUD
        public  static ObservableCollection<Namestaj> GetAll()
        {
            var namestaj = new ObservableCollection<Namestaj>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Namestaj"); // izvrsavanje upita

                foreach (DataRow row in ds.Tables["Namestaj"].Rows)
                {
                    var n = new Namestaj();
                    n.Id = int.Parse(row["Id"].ToString());
                    n.TipNamestajaId = int.Parse(row["TipNamestajaId"].ToString());
                    n.AkcijaId = int.Parse(row["AkcijskaProdajaId"].ToString());
                    n.Naziv = row["Naziv"].ToString();
                    n.Sifra = row["Sifra"].ToString();
                    n.JedinicnaCena = double.Parse(row["Cena"].ToString());
                    n.KolicinaUMagacinu = int.Parse(row["Kolicina"].ToString());
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namestaj.Add(n);
                }

            }
            return namestaj;
        }

        public static Namestaj Create(Namestaj n)
        {

            Random random = new Random();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO Namestaj (TipNamestajaId,AkcijskaProdajaId,Naziv,Sifra,Cena,Kolicina,Obrisan) VALUES (@TipNamestajaId,@AkcijskaProdajaId,@Naziv,@Sifra,@Cena,@Kolicina,@Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("AkcijskaProdajaId", n.AkcijaId);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                n.Sifra = n.Naziv.Substring(0, 2).ToUpper() + random.Next(1,99) + n.TipNamestaja.Naziv.Substring(0, 2).ToUpper();
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("Cena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                n.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

            }

            Projekat.Instance.Namestaj.Add(n);
            return n;
        }
        //azuriranje baze
        public static void Update(Namestaj n)
        {
            

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Namestaj SET TipNamestajaId = @TipNamestajaId,AkcijskaProdajaId = @AkcijskaProdajaId, Naziv = @Naziv,Sifra = @Sifra,Cena = @Cena,Kolicina = @Kolicina, Obrisan= @Obrisan WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", n.Id);
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("AkcijskaProdajaId", n.AkcijaId);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("Cena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                cmd.ExecuteNonQuery();

            }
            //azuriranje modela
            foreach (var namestaj in Projekat.Instance.Namestaj)
            {
                if (n.Id == namestaj.Id)
                {
                    namestaj.Naziv = n.Naziv;
                    namestaj.TipNamestajaId = n.TipNamestajaId;
                    namestaj.AkcijaId = n.AkcijaId;
                    namestaj.Sifra = n.Sifra;
                    namestaj.JedinicnaCena = n.JedinicnaCena;
                    namestaj.KolicinaUMagacinu = n.KolicinaUMagacinu;
                    namestaj.Obrisan = n.Obrisan;
                }
            }

        }

        public  static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }
        #endregion

        
    }
}