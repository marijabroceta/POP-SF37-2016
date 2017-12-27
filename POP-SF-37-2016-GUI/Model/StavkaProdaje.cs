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
    public class StavkaProdaje: INotifyPropertyChanged,ICloneable
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
                if(Namestaj != null)
                {
                    return cena = Namestaj.JedinicnaCena * Kolicina;
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
                //NamestajId = namestajId,

                
               
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

        public static StavkaProdaje Create(StavkaProdaje sp)
        {

            Random random = new Random();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO StavkaProdaje (ProdajaNamestajaId,NamestajId,Kolicina) VALUES (@ProdajaNamestajaId,@NamestajId,@Kolicina);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("ProdajaNamestajaId", sp.ProdajaNamestajaId);
                cmd.Parameters.AddWithValue("NamestajId", sp.NamestajId);
                cmd.Parameters.AddWithValue("Kolicina", sp.Kolicina);
                

                sp.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

            }

            Projekat.Instance.StavkeProdaje.Add(sp);
            return sp;
        }
        //azuriranje baze
        public static void Update(StavkaProdaje sp)
        {


            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE StavkaProdaje SET ProdajaNamestajaId = @ProdajaNamestajaId,NamestajId = @NamestajId, Kolicina = @Kolicina WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", sp.Id);
                cmd.Parameters.AddWithValue("ProdajaNamestajaId", sp.ProdajaNamestajaId);
                cmd.Parameters.AddWithValue("NamestajId", sp.NamestajId);
                cmd.Parameters.AddWithValue("Kolicina", sp.Kolicina);
             

                cmd.ExecuteNonQuery();

            }
            //azuriranje modela
            foreach (var stavka in Projekat.Instance.StavkeProdaje)
            {
                if (sp.Id == stavka.Id)
                {
                    stavka.ProdajaNamestajaId = sp.ProdajaNamestajaId;
                    stavka.NamestajId = sp.NamestajId;
                    stavka.Kolicina = sp.Kolicina;
                   
                }
            }

        }

        public static void Delete(StavkaProdaje sp)
        {
            sp.Obrisan = true;
            Update(sp);
        }
        #endregion



    }
}
