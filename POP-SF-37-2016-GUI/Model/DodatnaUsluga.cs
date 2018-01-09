
using POP_SF_37_2016_GUI.Model;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;

namespace POP_37_2016.Model
{
    public class DodatnaUsluga : INotifyPropertyChanged, ICloneable
    {

       private int id;
        private double cena;
        private bool obrisan;
        private string naziv;
        
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


        public double Cena
        {
            get { return cena; }
            set
            {
                cena = value;
                OnPropertyChanged("Cena");
            }
        }

        

        public bool Obrisan
        {
            get { return obrisan; }
            set
            {
                obrisan = value;
            }
        }





        public object Clone()
        {
            return new DodatnaUsluga()
            {
                Id = Id,
                Naziv = Naziv,
                Cena = Cena,
                Obrisan = Obrisan
            };
        }

        public static DodatnaUsluga GetById(int Id)
        {
            foreach (var usluga in Projekat.Instance.DodatnaUsluga)
            {
                if (usluga.Id == Id)
                {
                    return usluga;
                }
            }
            return null;
        }
        public override string ToString()
        {
            return $"{Naziv},{Cena}";
        }

        public  event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        #region CRUD
        public static ObservableCollection<DodatnaUsluga> GetAll()
        {
            var dodatneUsluge = new ObservableCollection<DodatnaUsluga>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "DodatnaUsluga"); // izvrsavanje upita

                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    var du = new DodatnaUsluga();
                    du.Id = int.Parse(row["Id"].ToString());
                    du.Naziv = row["Naziv"].ToString();
                    du.Cena = double.Parse(row["Cena"].ToString());
                    du.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    dodatneUsluge.Add(du);
                }

            }
            return dodatneUsluge;
        }

        public static DodatnaUsluga Create(DodatnaUsluga du)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "INSERT INTO DodatnaUsluga (Naziv,Obrisan) VALUES (@Naziv,@Obrisan);";
                    cmd.CommandText += "SELECT SCOPE_IDENTITY()";

                    cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                    cmd.Parameters.AddWithValue("Cena", du.Cena);
                    cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                    du.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

                }

                Projekat.Instance.DodatnaUsluga.Add(du);
                return du;
            }
            catch(Exception)
            {
                MessageBox.Show("Upis u bazu nije uspeo.\n Molim da pokusate ponovo!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
                return null;
            }
            
        }
        //azuriranje baze
        public static void Update(DodatnaUsluga du)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "UPDATE DodatnaUsluga SET Naziv = @Naziv, Obrisan= @Obrisan WHERE Id = @Id";
                    cmd.Parameters.AddWithValue("Id", du.Id);
                    cmd.Parameters.AddWithValue("Naziv", du.Naziv);
                    cmd.Parameters.AddWithValue("Cena", du.Cena);
                    cmd.Parameters.AddWithValue("Obrisan", du.Obrisan);

                    cmd.ExecuteNonQuery();

                }
                //azuriranje modela
                foreach (var usluga in Projekat.Instance.DodatnaUsluga)
                {
                    if (du.Id == usluga.Id)
                    {
                        usluga.Naziv = du.Naziv;
                        usluga.Cena = du.Cena;
                        usluga.Obrisan = du.Obrisan;
                    }
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Upis u bazu nije uspeo.\n Molim da pokusate ponovo!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
            }

        }

        public static void Delete(DodatnaUsluga du)
        {
            du.Obrisan = true;
            Update(du);
        }

        public static ObservableCollection<DodatnaUsluga> UslugaNijeProdata(int Id)
        {
            var usluga = new ObservableCollection<DodatnaUsluga>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();               
                cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan=0 AND Id NOT IN (SELECT DodatnaUslugaId FROM ProdataUsluga WHERE Obrisan=0 AND ProdajaNamestajaId=@ProdajaNamestajaId)";
                cmd.Parameters.AddWithValue("ProdajaNamestajaId", Id);               
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "DodatnaUsluga"); //izvrsavanje upita

                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    var du = new DodatnaUsluga();
                    du.Id = (int)row["Id"];
                    du.Naziv = row["Naziv"].ToString();
                    du.Cena = double.Parse(row["Cena"].ToString());
                    du.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    usluga.Add(du);
                }

            }
            return usluga;
        }
        
        #endregion

        #region Search

        public static ObservableCollection<DodatnaUsluga> PretragaDodatnaUsluga(string unos)
        {
            var usluga = new ObservableCollection<DodatnaUsluga>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM DodatnaUsluga WHERE Obrisan = 0 AND Naziv LIKE @unos";

                cmd.Parameters.AddWithValue("unos", "%" + unos.Trim() + "%");
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "DodatnaUsluga");

                foreach (DataRow row in ds.Tables["DodatnaUsluga"].Rows)
                {
                    var du = new DodatnaUsluga();
                    du.Id = int.Parse(row["Id"].ToString());
                    du.Naziv = row["Naziv"].ToString();
                    du.Cena = double.Parse(row["Cena"].ToString());
                    du.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    usluga.Add(du);
                }

            }
            return usluga;
        }
        #endregion
    }




}