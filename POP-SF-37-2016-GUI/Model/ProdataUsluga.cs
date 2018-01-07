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
    public class ProdataUsluga
    {
        public int Id { get; set; }
        public int ProdajaNamestajaId { get; set; }
        public int DodatnaUslugaId { get; set; }
        public DodatnaUsluga dodatnaUsluga;
        public bool Obrisan { get; set; }

        public DodatnaUsluga DodatnaUsluga
        {
            get
            {
                if (dodatnaUsluga == null)
                {
                    dodatnaUsluga = DodatnaUsluga.GetById(DodatnaUslugaId);
                }
                return dodatnaUsluga;
            }
            set
            {
                dodatnaUsluga = value;
                DodatnaUslugaId = dodatnaUsluga.Id;
            }
        }

        public static ObservableCollection<ProdataUsluga> GetUslugaById(ObservableCollection<int> listIntUsluga)
        {
            var listaPu = new ObservableCollection<ProdataUsluga>();
            foreach (var u in Projekat.Instance.ProdateUsluge)
            {
                if (listIntUsluga != null)
                {
                    foreach (var pu in listIntUsluga)
                    {
                        if (u.DodatnaUslugaId == pu)
                        {
                            listaPu.Add(u);

                        }
                    }
                }
            }
            return listaPu;
        }

        #region CRUD

        public static ObservableCollection<ProdataUsluga> GetAll()
        {
            var pUsluga = new ObservableCollection<ProdataUsluga>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM ProdataUsluga WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "ProdataUsluga"); // izvrsavanje upita

                foreach (DataRow row in ds.Tables["ProdataUsluga"].Rows)
                {
                    var pu = new ProdataUsluga();
                    pu.Id = int.Parse(row["Id"].ToString());
                    pu.ProdajaNamestajaId = int.Parse(row["ProdajaNamestajaId"].ToString());
                    pu.DodatnaUslugaId = int.Parse(row["DodatnaUslugaId"].ToString());

                    pu.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    pUsluga.Add(pu);
                }

            }
            return pUsluga;

        }
        
        public static ObservableCollection<ProdataUsluga> GetAllId(int Id)
        {
            var pUsluga = new ObservableCollection<ProdataUsluga>();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = con.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                DataSet ds = new DataSet();

                cmd.CommandText = "SELECT * FROM ProdataUsluga WHERE Obrisan=0 and ProdajaNamestajaId=@ProdajaNamestajaId";
                cmd.CommandText += " Select SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("ProdajaNamestajaId", Id);
                da.SelectCommand = cmd;
                da.Fill(ds, "ProdataUsluga"); //izvrsavanje upita

                foreach (DataRow row in ds.Tables["ProdataUsluga"].Rows)
                {
                    var pu = new ProdataUsluga();
                    pu.Id = int.Parse(row["Id"].ToString());
                    pu.ProdajaNamestajaId = int.Parse(row["ProdajaNamestajaId"].ToString());
                    pu.DodatnaUslugaId = int.Parse(row["DodatnaUslugaId"].ToString());

                    pu.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    pUsluga.Add(pu);
                }
            }
            return pUsluga;
        }

        public static void Update(ProdataUsluga pu)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE ProdataUsluga SET ProdajaNamestajaId=@ProdajaNamestajaId,DodatnaUslugaId = @DodatnaUslugaId,Obrisan=@Obrisan WHERE Id = @Id";
                cmd.CommandText += " SELECT SCOPE_IDENTITY();";

                cmd.Parameters.AddWithValue("Id", pu.Id);
               
                cmd.Parameters.AddWithValue("ProdajaNamestajaId", pu.ProdajaNamestajaId);
                
                cmd.Parameters.AddWithValue("DodatnaUslugaId", pu.DodatnaUslugaId);
                cmd.Parameters.AddWithValue("Obrisan", pu.Obrisan);

                cmd.ExecuteNonQuery();
            }
            foreach (var prodataU in Projekat.Instance.ProdateUsluge)
            {
                if (prodataU.Id == pu.Id)
                {
                    
                    pu.ProdajaNamestajaId = prodataU.ProdajaNamestajaId;
                    pu.DodatnaUslugaId = prodataU.DodatnaUslugaId;
                    pu.Obrisan = prodataU.Obrisan;
                }
            }




        }

        public static void Delete(ProdataUsluga pu)
        {
            pu.Obrisan = true;
            ProdataUsluga.Update(pu);
        }

        #endregion
    }
}
