using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Xml.Serialization;

namespace POP_37_2016.Model
{
    public class Namestaj : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private string naziv;
        private string sifra;
        private int akcijaId;
        private double jedinicnaCena;
        private double cenaNaAkciji;
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
                if (akcijskaProdaja == null)
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
                if (tipNamestaja == null)
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

        

        public double CenaNaAkciji
        {
            get
            { return cenaNaAkciji; }
            set
            {
                cenaNaAkciji = value;
                OnPropertyChanged("CenaNaAkciji");
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

        public object Clone()
        {
            return new Namestaj()
            {
                Id = id,
                Sifra = sifra,
                Naziv = naziv,
                JedinicnaCena = jedinicnaCena,
                KolicinaUMagacinu = kolicinaUMagacinu,
                TipNamestaja = tipNamestaja,
                TipNamestajaId = tipNamestajaId,
                AkcijaId = akcijaId,
                //AkcijskaProdaja = akcijskaProdaja,
                CenaNaAkciji = cenaNaAkciji
            };
        }

        public Namestaj()
        {
        }

        public Namestaj(int id)
        {
            Id = id;
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

        public static ObservableCollection<Namestaj> GetAll()
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
                    n.CenaNaAkciji = double.Parse(row["CenaNaAkciji"].ToString());
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

                cmd.CommandText = "INSERT INTO Namestaj (TipNamestajaId,AkcijskaProdajaId,Naziv,Sifra,Cena,CenaNaAkciji,Kolicina,Obrisan) VALUES (@TipNamestajaId,@AkcijskaProdajaId,@Naziv,@Sifra,@Cena,@CenaNaAkciji,@Kolicina,@Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                cmd.Parameters.AddWithValue("AkcijskaProdajaId", n.AkcijaId);
                cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                n.Sifra = n.Naziv.Substring(0, 2).ToUpper() + random.Next(1, 99) + n.TipNamestaja.Naziv.Substring(0, 2).ToUpper();
                cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                cmd.Parameters.AddWithValue("Cena", n.JedinicnaCena);
                cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu);
                cmd.Parameters.AddWithValue("CenaNaAkciji", n.CenaNaAkciji);
                cmd.Parameters.AddWithValue("Obrisan", n.Obrisan);

                n.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit
            }

            Projekat.Instance.Namestaj.Add(n);
            return n;
        }

        //azuriranje baze
        public static void Update(Namestaj n)
        {
            try
            {
                using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
                {
                    conn.Open();

                    SqlCommand cmd = conn.CreateCommand();

                    cmd.CommandText = "UPDATE Namestaj SET TipNamestajaId = @TipNamestajaId,AkcijskaProdajaId = @AkcijskaProdajaId, CenaNaAkciji = @CenaNaAkciji,Naziv = @Naziv,Sifra = @Sifra,Cena = @Cena,Kolicina = @Kolicina, Obrisan= @Obrisan WHERE Id = @Id";
                    //cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                    cmd.Parameters.AddWithValue("Id", n.Id);
                    cmd.Parameters.AddWithValue("TipNamestajaId", n.TipNamestajaId);
                    cmd.Parameters.AddWithValue("AkcijskaProdajaId", n.AkcijaId);
                    cmd.Parameters.AddWithValue("Naziv", n.Naziv);
                    cmd.Parameters.AddWithValue("Sifra", n.Sifra);
                    cmd.Parameters.AddWithValue("Cena", n.JedinicnaCena);
                    cmd.Parameters.AddWithValue("Kolicina", n.KolicinaUMagacinu);
                    cmd.Parameters.AddWithValue("CenaNaAkciji", n.CenaNaAkciji);
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
                        namestaj.TipNamestaja = n.TipNamestaja;
                        namestaj.AkcijaId = n.AkcijaId;
                        namestaj.Sifra = n.Sifra;
                        namestaj.JedinicnaCena = n.JedinicnaCena;
                        namestaj.KolicinaUMagacinu = n.KolicinaUMagacinu;
                        namestaj.CenaNaAkciji = n.CenaNaAkciji;
                        namestaj.Obrisan = n.Obrisan;
                    }
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Upis u bazu nije uspeo.\n Molim da pokusate ponovo!", "Greska", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public static void Delete(Namestaj n)
        {
            n.Obrisan = true;
            Update(n);
        }

        public static ObservableCollection<Namestaj> NamestajNijeNaAkciji()
        {
            var namestaj = new ObservableCollection<Namestaj>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM Namestaj WHERE Obrisan = 0 AND Id NOT IN (SELECT NamestajId FROM NaAkciji WHERE Obrisan = 0)";
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
                    n.CenaNaAkciji = double.Parse(row["CenaNaAkciji"].ToString());
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namestaj.Add(n);
                }
            }
            return namestaj;
        }

        #endregion CRUD

        #region Search

        public enum TipPretrage
        {
            NAZIV,
            SIFRA,
            TIPNAMESTAJA
        }

        public static ObservableCollection<Namestaj> PretragaNamestaja(string unos, TipPretrage tipPretrage)
        {
            var namestaj = new ObservableCollection<Namestaj>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();

                switch (tipPretrage)
                {
                    case TipPretrage.NAZIV:
                        cmd.CommandText = "SELECT * FROM Namestaj n INNER JOIN TipNamestaja tn ON n.TipNamestajaId = tn.Id WHERE n.Naziv LIKE @unos AND n.Obrisan = 0;";
                        break;

                    case TipPretrage.SIFRA:
                        cmd.CommandText = "SELECT * FROM Namestaj n INNER JOIN TipNamestaja tn ON n.TipNamestajaId = tn.Id WHERE n.Sifra LIKE @unos AND n.Obrisan = 0;";
                        break;

                    case TipPretrage.TIPNAMESTAJA:
                        cmd.CommandText = "SELECT * FROM Namestaj n INNER JOIN TipNamestaja tn ON n.TipNamestajaId = tn.Id WHERE tn.Naziv LIKE @unos AND n.Obrisan = 0;";
                        break;
                }
                cmd.Parameters.AddWithValue("unos", "%" + unos.Trim() + "%");
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "Namestaj");

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
                    n.CenaNaAkciji = double.Parse(row["CenaNaAkciji"].ToString());
                    n.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    namestaj.Add(n);
                }
            }
            return namestaj;
        }

        #endregion Search
    }
}