using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace POP_37_2016.Model
{
    public class TipNamestaja: INotifyPropertyChanged, ICloneable
    {

        private int id;
        private string naziv;
        private bool obrisan;

        public bool Obrisan
        {
            get { return obrisan; }
            set
            { obrisan = value;
                OnPropertyChanged("Obrisan");
            }
        }


        public string Naziv
        {
            get { return naziv; }
            set
            { naziv = value;
                OnPropertyChanged("Naziv");
            }
        }


        public int Id
        {
            get { return id; }
            set
            { id = value;
                OnPropertyChanged("Id");
            }
        }

       

       
        
        public override string ToString()
        {
            return $"{Naziv}";
        }

        public static TipNamestaja GetById(int? Id)
        {
            foreach(var tip in Projekat.Instance.TipoviNamestaja)
            {
                if(tip.Id == Id)
                {
                    return tip;
                }
            }
            return null;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public object Clone()
        {
            return new TipNamestaja
            {
                Id = id,
                Naziv = naziv,
                Obrisan = obrisan
            };
        }

        #region CRUD
        public static ObservableCollection<TipNamestaja> GetAll()
        {
            var tipoviNamestaja = new ObservableCollection<TipNamestaja>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds,"TipNamestaja"); // izvrsavanje upita

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    var tn = new TipNamestaja();
                    tn.Id = int.Parse(row["Id"].ToString());
                    tn.Naziv = row["Naziv"].ToString();
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    tipoviNamestaja.Add(tn);
                }
                
            }
            return tipoviNamestaja;
        }

        public static TipNamestaja Create(TipNamestaja tn)
        {
            
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                
                cmd.CommandText = "INSERT INTO TipNamestaja (Naziv,Obrisan) VALUES (@Naziv,@Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY()";

                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                tn.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

            }

            Projekat.Instance.TipoviNamestaja.Add(tn);
            return tn;
        }
        //azuriranje baze
        public static void Update(TipNamestaja tn)
        {

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE TipNamestaja SET Naziv = @Naziv, Obrisan= @Obrisan WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", tn.Id);
                cmd.Parameters.AddWithValue("Naziv", tn.Naziv);
                cmd.Parameters.AddWithValue("Obrisan", tn.Obrisan);

                cmd.ExecuteNonQuery();

            }
            //azuriranje modela
            foreach (var tip in Projekat.Instance.TipoviNamestaja)
            {
                if(tn.Id == tip.Id )
                {
                    tip.Naziv = tn.Naziv;
                    tip.Obrisan = tn.Obrisan;
                }
            }
           
        }

        public static void Delete(TipNamestaja tn)
        {
            tn.Obrisan = true;
            Update(tn);
        }
        #endregion

        #region Search
        public static ObservableCollection<TipNamestaja> PretragaTipNamestaja(string unos)
        {
            var tipNamestaja = new ObservableCollection<TipNamestaja>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM TipNamestaja WHERE Obrisan = 0 AND Naziv LIKE @unos";
                
                cmd.Parameters.AddWithValue("unos", "%" + unos.Trim() + "%");
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "TipNamestaja");

                foreach (DataRow row in ds.Tables["TipNamestaja"].Rows)
                {
                    var tn = new TipNamestaja();
                    tn.Id = int.Parse(row["Id"].ToString());                   
                    tn.Naziv = row["Naziv"].ToString();                  
                    tn.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    tipNamestaja.Add(tn);
                }

            }
            return tipNamestaja;
        }
        #endregion

    }

    
}