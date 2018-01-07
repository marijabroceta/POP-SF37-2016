using POP_37_2016.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace POP_SF_37_2016_GUI.Model
{
    public class StavkaProdaje : INotifyPropertyChanged, ICloneable
    {
        private int id;
        private int kolicina;
        private double cena;
        public int ProdajaNamestajaId { get; set; }
        private Namestaj namestaj;
        private int namestajId;




        public int Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }



        public int Kolicina
        {
            get { return kolicina; }
            set
            {
                kolicina = value;
                OnPropertyChanged("Kolicina");
            }

        }




        public double Cena
        {
            get
            {
                if (Namestaj != null)
                {
                    if(Namestaj.CenaNaAkciji != 0)
                    {
                        return cena = Namestaj.CenaNaAkciji * Kolicina;
                    }
                    else
                    {
                        return cena = Namestaj.JedinicnaCena * Kolicina;
                    }
                    
                }
                else
                {
                    return 0;
                }
            }
            set
            {
                if (Namestaj != null)
                {
                    cena = Namestaj.JedinicnaCena * Kolicina;
                }

                OnPropertyChanged("Cena");
            }
        }




        public Namestaj Namestaj
        {
            get
            {
                if (namestaj == null)
                {
                    namestaj = Namestaj.GetById(NamestajId);
                }
                return namestaj;
            }
            set
            {
                namestaj = value;
                NamestajId = namestaj.Id;
                OnPropertyChanged("Namestaj");

            }
        }

        public int NamestajId
        {
            get { return namestajId; }
            set
            {
                namestajId = value;
                OnPropertyChanged("NamestajId");
            }
        }


        private bool obrisan;

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
            return new StavkaProdaje()
            {
                Id = id,
                Kolicina = kolicina,
                NamestajId = namestajId,
                Namestaj = namestaj,
                ProdajaNamestajaId = ProdajaNamestajaId


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
        public static ObservableCollection<StavkaProdaje> GetAll()
        {
            var stavka = new ObservableCollection<StavkaProdaje>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM StavkaProdaje;";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "StavkaProdaje"); // izvrsavanje upita

                foreach (DataRow row in ds.Tables["StavkaProdaje"].Rows)
                {
                    var sp = new StavkaProdaje();
                    sp.Id = int.Parse(row["Id"].ToString());
                    sp.ProdajaNamestajaId = int.Parse(row["ProdajaNamestajaId"].ToString());
                    sp.NamestajId = int.Parse(row["NamestajId"].ToString());
                    sp.Kolicina = int.Parse(row["Kolicina"].ToString());


                    stavka.Add(sp);
                }

            }
            return stavka;
        }

        public static ObservableCollection<StavkaProdaje> GetAllId(int Id)
        {
            var stavkeProdaje = new ObservableCollection<StavkaProdaje>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM StavkaProdaje WHERE Obrisan=0 and ProdajaNamestajaId=@ProdajaNamestajaId";
                cmd.CommandText += " Select SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("ProdajaNamestajaId", Id);
                da.SelectCommand = cmd;
                da.Fill(ds, "StavkaProdaje"); //izvrsavanje upita

                foreach (DataRow row in ds.Tables["StavkaProdaje"].Rows)
                {
                    var sp = new StavkaProdaje();
                    sp.Id = int.Parse(row["Id"].ToString());
                    sp.ProdajaNamestajaId = int.Parse(row["ProdajaNamestajaId"].ToString());
                    sp.NamestajId = int.Parse(row["NamestajId"].ToString());
                    sp.Kolicina = int.Parse(row["Kolicina"].ToString());
                    sp.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    stavkeProdaje.Add(sp);
                }
            }
            return stavkeProdaje;
        }

        public static StavkaProdaje Create(StavkaProdaje sp)
        {



            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO StavkaProdaje (ProdajaNamestajaId,NamestajId,Cena,Kolicina,Obrisan) VALUES (@ProdajaNamestajaId,@NamestajId,@Cena,@Kolicina,@Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("ProdajaNamestajaId", sp.ProdajaNamestajaId);
                cmd.Parameters.AddWithValue("NamestajId", sp.NamestajId);

                cmd.Parameters.AddWithValue("Cena", sp.Cena);
                cmd.Parameters.AddWithValue("Kolicina", sp.Kolicina);

                cmd.Parameters.AddWithValue("Obrisan", sp.Obrisan);

                sp.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

            }

            Projekat.Instance.StavkeProdaje.Add(sp);
            return sp;
        }

        public static void Update(StavkaProdaje sp)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE StavkaProdaje SET NamestajId=@NamestajId,ProdajaNamestajaId=@ProdajaNamestajaId,Kolicina=@Kolicina,Cena=@Cena,Obrisan=@Obrisan WHERE Id = @Id";
                cmd.CommandText += " SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", sp.Id);
                cmd.Parameters.AddWithValue("NamestajId", sp.NamestajId);
                cmd.Parameters.AddWithValue("ProdajaNamestajaId", sp.ProdajaNamestajaId);
                cmd.Parameters.AddWithValue("Kolicina", sp.Kolicina);
                cmd.Parameters.AddWithValue("Cena", sp.Cena);
                cmd.Parameters.AddWithValue("Obrisan", sp.Obrisan);

                cmd.ExecuteNonQuery();
            }
            foreach (var stavka in Projekat.Instance.StavkeProdaje)
            {
                if (stavka.Id == sp.Id)
                {
                    sp.NamestajId = stavka.NamestajId;
                    sp.ProdajaNamestajaId = stavka.ProdajaNamestajaId;
                    sp.Kolicina = stavka.Kolicina;
                    sp.Cena = stavka.Cena;
                    sp.Obrisan = stavka.Obrisan;
                }
            }
        



        }

        public static void Delete(StavkaProdaje sp)
        {
            sp.Obrisan = true;
            StavkaProdaje.Update(sp);
        }
        #endregion
    }
}
