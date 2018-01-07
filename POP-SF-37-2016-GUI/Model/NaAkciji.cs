using POP_37_2016.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POP_SF_37_2016_GUI.Model
{
    public  class NaAkciji
    {
        public int Id { get; set; }
        public int AkcijskaProdajaId { get; set; }
        public int NamestajId { get; set; }
        private Namestaj namestaj;

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
                

            }
        }

        public bool Obrisan { get; set; }


        #region CRUD

        public static ObservableCollection<NaAkciji> GetAll()
        {
            var naAkciji = new ObservableCollection<NaAkciji>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM NaAkciji WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "NaAkciji"); // izvrsavanje upita

                foreach (DataRow row in ds.Tables["NaAkciji"].Rows)
                {
                    var na = new NaAkciji();
                    na.Id = int.Parse(row["Id"].ToString());
                    na.AkcijskaProdajaId = int.Parse(row["AkcijskaProdajaId"].ToString());
                    na.NamestajId = int.Parse(row["NamestajId"].ToString());

                    na.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    naAkciji.Add(na);
                }

            }
            return naAkciji;

        }

        public static ObservableCollection<NaAkciji> GetAllId(int Id)
        {
            var naAkciji = new ObservableCollection<NaAkciji>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM NaAkciji WHERE Obrisan=0 and AkcijskaProdajaId=@AkcijskaProdajaId";
                cmd.CommandText += " Select SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("AkcijskaProdajaId", Id);
                da.SelectCommand = cmd;
                da.Fill(ds, "NaAkciji"); //izvrsavanje upita

                foreach (DataRow row in ds.Tables["NaAkciji"].Rows)
                {
                    var na = new NaAkciji();
                    na.Id = int.Parse(row["Id"].ToString());
                    na.AkcijskaProdajaId = int.Parse(row["AkcijskaProdajaId"].ToString());
                    na.NamestajId = int.Parse(row["NamestajId"].ToString());
                    
                    na.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    naAkciji.Add(na);
                }
            }
            return naAkciji;
        }
        
        public static NaAkciji Create(NaAkciji na)
        {

            Random random = new Random();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO NaAkciji (AkcijskaProdajaId,NamestajId,Obrisan) VALUES (@AkcijskaProdajaId,@NamestajId,@Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
               
                cmd.Parameters.AddWithValue("AkcijskaProdajaId", na.AkcijskaProdajaId);
                cmd.Parameters.AddWithValue("NamestajId", na.NamestajId);
                cmd.Parameters.AddWithValue("Obrisan", na.Obrisan);

                na.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

            }

            Projekat.Instance.NamestajNaAkciji.Add(na);
            return na;
        }
        //azuriranje baze
        public static void Update(NaAkciji na)
        {


            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();


                cmd.CommandText = "UPDATE NaAkciji SET AkcijskaProdajaId = @AkcijskaProdajaId, NamestajId = @NamestajId, Obrisan= @Obrisan WHERE Id = @Id";
                
                cmd.Parameters.AddWithValue("Id", na.Id);
                
                cmd.Parameters.AddWithValue("AkcijskaProdajaId", na.AkcijskaProdajaId);
                cmd.Parameters.AddWithValue("NamestajId", na.NamestajId);
                cmd.Parameters.AddWithValue("Obrisan", na.Obrisan);

                cmd.ExecuteNonQuery();

            }
            //azuriranje modela
            foreach (var naAkciji in Projekat.Instance.NamestajNaAkciji)
            {
                if (na.Id == naAkciji.Id)
                {

                    
                    naAkciji.AkcijskaProdajaId = na.AkcijskaProdajaId;
                    naAkciji.NamestajId = na.NamestajId;
                    naAkciji.Obrisan = na.Obrisan;
                }
            }

        }

        public static void Delete(NaAkciji na)
        {
            
            na.Obrisan = true;
            Update(na);
        }
        #endregion
    }
    
}

    
