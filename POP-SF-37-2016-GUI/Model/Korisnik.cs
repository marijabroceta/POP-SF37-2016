using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP_37_2016.Model
{
    
    public enum TipKorisnika
    {
        Administrator ,
        Prodavac 
    }

    

    public class Korisnik : INotifyPropertyChanged
    {
        private int id;
        private string ime;
        private string prezime;
        private string korisnickoIme;
        private string lozinka;
        private TipKorisnika tipKorisnika;
        private bool obrisan;



        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        

        public string Ime
        {
            get { return ime; }
            set
            {
                ime = value;
                OnPropertyChanged("Ime");
            }
        }

       

        public string Prezime
        {
            get { return prezime; }
            set
            {
                prezime = value;
                OnPropertyChanged("Prezime");

            }
        }

       

        public string KorisnickoIme
        {
            get { return korisnickoIme; }
            set
            {
                korisnickoIme = value;
                OnPropertyChanged("KorisnickoIme");
            }
        }

       

        public string Lozinka
        {
            get { return lozinka; }
            set
            {
                lozinka = value;
                OnPropertyChanged("Lozinka");
            }
        }

        

        public TipKorisnika TipKorisnika
        {
            get { return tipKorisnika; }
            set
            {
                tipKorisnika = value;
                OnPropertyChanged("TipKorisnika");
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
        



        public override string ToString()
        {
            return $"{Ime},{Prezime},{KorisnickoIme}"; 
        }

        public object Clone()
        {
            return new Korisnik()
            {
                Id = id,
                Ime = ime,
                Prezime = prezime,
                KorisnickoIme = korisnickoIme,
                Lozinka = lozinka,
                TipKorisnika = tipKorisnika,
                Obrisan = obrisan

            };
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        #region CRUD
        public static ObservableCollection<Korisnik> GetAll()
        {
            var korisnici = new ObservableCollection<Korisnik>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM Korisnik WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Korisnik"); // izvrsavanje upita

                foreach (DataRow row in ds.Tables["Korisnik"].Rows)
                {
                    var k = new Korisnik();
                    k.Id = int.Parse(row["Id"].ToString());
                    k.Ime = row["Ime"].ToString();
                    k.Prezime = row["Prezime"].ToString();
                    k.KorisnickoIme = row["KorisnickoIme"].ToString();
                    k.Lozinka = row["Lozinka"].ToString();
                    k.TipKorisnika =(TipKorisnika) Enum.Parse(typeof(TipKorisnika),(row["TipKorisnika"].ToString()));

                    k.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    korisnici.Add(k);
                }

            }
            return korisnici;
        }

        public static Korisnik Create(Korisnik k)
        {

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO Korisnik (Ime,Prezime,KorisnickoIme,Lozinka,Obrisan) VALUES (@Ime,@Prezime,@KorisnickoIme,@Lozinka,@Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY()";

                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);
                cmd.Parameters.AddWithValue("TipKorisnika", k.TipKorisnika);

                k.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

            }

            Projekat.Instance.Korisnici.Add(k);
            return k;
        }
        //azuriranje baze
        public static void Update(Korisnik k)
        {

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE Korisnik SET Ime = @Ime,Prezime = @Prezime, KorisnickoIme = @KorisnickoIme, Lozinka = @Lozinka, Obrisan= @Obrisan WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", k.Id);
                cmd.Parameters.AddWithValue("Ime", k.Ime);
                cmd.Parameters.AddWithValue("Prezime", k.Prezime);
                cmd.Parameters.AddWithValue("KorisnickoIme", k.KorisnickoIme);
                cmd.Parameters.AddWithValue("Lozinka", k.Lozinka);
                cmd.Parameters.AddWithValue("Obrisan", k.Obrisan);
                cmd.Parameters.AddWithValue("TipKorisnika", k.TipKorisnika);
                cmd.ExecuteNonQuery();

            }
            //azuriranje modela
            foreach (var korisnik in Projekat.Instance.Korisnici)
            {
                if (k.Id == korisnik.Id)
                {
                    korisnik.Ime = k.Ime;
                    korisnik.Prezime = k.Prezime;
                    korisnik.KorisnickoIme = k.KorisnickoIme;
                    korisnik.Lozinka = k.Lozinka;
                    korisnik.TipKorisnika = k.TipKorisnika;
                    korisnik.Obrisan = k.Obrisan;
                    
                }
            }

        }

        public static void Delete(Korisnik k)
        {
            k.Obrisan = true;
            Update(k);
        }
        #endregion
    }




}