using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace POP_37_2016.Model
{
    public class Salon : INotifyPropertyChanged
    {
        private int id;
        private string naziv;
        private string adresa;
        private string telefon;
        private string email;
        private string adresaInternetSajta;
        private int pib;
        private string jmbg;
        private string brojZiroRacuna;
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

        public string Naziv
        {
            get { return naziv; }
            set
            {
                naziv = value;
                OnPropertyChanged("Naziv");
            }
        }

        public string Adresa
        {
            get { return adresa; }
            set
            {
                adresa = value;
                OnPropertyChanged("Adresa");
            }
        }

        public string Telefon
        {
            get { return telefon; }
            set
            {
                telefon = value;
                OnPropertyChanged("Telefon");
            }
        }

        public string Email
        {
            get { return email; }
            set
            {
                email = value;
                OnPropertyChanged("Email");
            }
        }

        public string AdresaInternetSajta
        {
            get { return adresaInternetSajta; }
            set
            {
                adresaInternetSajta = value;
                OnPropertyChanged("AdresaInternetSajta");
            }
        }

        public int PIB
        {
            get { return pib; }
            set
            {
                pib = value;
                OnPropertyChanged("PIB");
            }
        }

        public string JMBG
        {
            get { return jmbg; }
            set
            {
                jmbg = value;
                OnPropertyChanged("JMBG");
            }
        }

        public string BrojZiroRacuna
        {
            get { return brojZiroRacuna; }
            set
            {
                brojZiroRacuna = value;
                OnPropertyChanged("BrojZiroRacuna");
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

        public object Clone()
        {
            return new Salon()
            {
                Id = id,
                Naziv = naziv,
                Adresa = adresa,
                Telefon = telefon,
                Email = email,
                AdresaInternetSajta = adresaInternetSajta,
                PIB = pib,
                JMBG = jmbg,
                BrojZiroRacuna = brojZiroRacuna,
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

        public static ObservableCollection<Salon> GetAll()
        {
            var salon = new ObservableCollection<Salon>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM Salon WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Salon"); // izvrsavanje upita

                foreach (DataRow row in ds.Tables["Salon"].Rows)
                {
                    var s = new Salon();
                    s.Id = int.Parse(row["Id"].ToString());
                    s.Naziv = row["Naziv"].ToString();
                    s.Adresa = row["Adresa"].ToString();
                    s.Telefon = row["Telefon"].ToString();
                    s.Email = row["Email"].ToString();
                    s.AdresaInternetSajta = row["WebSajt"].ToString();
                    s.PIB = int.Parse(row["PIB"].ToString());
                    s.JMBG = row["JMBG"].ToString();
                    s.BrojZiroRacuna = row["BrojZiroRacuna"].ToString();
                    s.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    salon.Add(s);
                }
            }
            return salon;
        }

        public static Salon Create(Salon s)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "INSERT INTO Salon (Naziv,Adresa,Telefon,Email,WebSajt,PIB,JMBG,BrojZiroRacuna,Obrisan) VALUES (@Naziv,@Adresa,@Telefon,@Email,@WebSajt,@PIB,@JMBG,@BrojZiroRacuna,@Obrisan);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Naziv", s.Naziv);
                    cmd.Parameters.AddWithValue("Adresa", s.Adresa);
                    cmd.Parameters.AddWithValue("Telefon", s.Telefon);
                    cmd.Parameters.AddWithValue("Email", s.Email);
                    cmd.Parameters.AddWithValue("WebSajt", s.AdresaInternetSajta);
                    cmd.Parameters.AddWithValue("PIB", s.PIB);
                    cmd.Parameters.AddWithValue("JMBG", s.JMBG);
                    cmd.Parameters.AddWithValue("BrojZiroRacuna", s.BrojZiroRacuna);
                    cmd.Parameters.AddWithValue("Obrisan", s.Obrisan);

                    s.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit
                }

                Projekat.Instance.Salon.Add(s);
                return s;
            }
            catch (Exception)
            {
                MessageBox.Show("Upis u bazu nije uspeo.\n Molim da pokusate ponovo!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
        }

        //azuriranje baze
        public static void Update(Salon s)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "UPDATE Salon SET Naziv = @Naziv,Adresa = @Adresa, Telefon = @Telefon,Email = @Email,WebSajt = @WebSajt,PIB = @PIB,JMBG = @JMBG,BrojZiroRacuna = @BrojZiroRacuna, Obrisan= @Obrisan WHERE Id = @Id";
                    //cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Id", s.Id);
                    cmd.Parameters.AddWithValue("Naziv", s.Naziv);
                    cmd.Parameters.AddWithValue("Adresa", s.Adresa);
                    cmd.Parameters.AddWithValue("Telefon", s.Telefon);
                    cmd.Parameters.AddWithValue("Email", s.Email);
                    cmd.Parameters.AddWithValue("WebSajt", s.AdresaInternetSajta);
                    cmd.Parameters.AddWithValue("PIB", s.PIB);
                    cmd.Parameters.AddWithValue("JMBG", s.JMBG);
                    cmd.Parameters.AddWithValue("BrojZiroRacuna", s.BrojZiroRacuna);
                    cmd.Parameters.AddWithValue("Obrisan", s.Obrisan);

                    cmd.ExecuteNonQuery();
                }
                //azuriranje modela
                foreach (var salon in Projekat.Instance.Salon)
                {
                    if (s.Id == salon.Id)
                    {
                        salon.Naziv = s.Naziv;
                        salon.Adresa = s.Adresa;
                        salon.Telefon = s.Telefon;
                        salon.Email = s.Email;
                        salon.AdresaInternetSajta = s.AdresaInternetSajta;
                        salon.PIB = s.PIB;
                        salon.JMBG = s.JMBG;
                        salon.BrojZiroRacuna = s.BrojZiroRacuna;
                        salon.Obrisan = s.Obrisan;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Upis u bazu nije uspeo.\n Molim da pokusate ponovo!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public static void Delete(Salon s)
        {
            s.Obrisan = true;
            Update(s);
        }

        #endregion CRUD
    }
}