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
    public class ProdajaNamestaja : INotifyPropertyChanged, ICloneable
    {

        private int id;
        private DateTime datumProdaje;
        private string brojRacuna;
        private string kupac;
        private double ukupnaCenaSaPDV;
        private double ukupnaCenaBezPDV;
        public const double PDV = 0.02;
        public ObservableCollection<StavkaProdaje> StavkeProdaje { get; set; }
        public ObservableCollection<DodatnaUsluga> DodatneUsluge { get; set; }


        public ProdajaNamestaja()
        {
            StavkeProdaje = new ObservableCollection<StavkaProdaje>();
            DodatneUsluge = new ObservableCollection<DodatnaUsluga>();
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



        public DateTime DatumProdaje
        {
            get { return datumProdaje; }
            set
            {
                datumProdaje = value;
                OnPropertyChanged("DatumProdaje");
            }
        }


        public string BrojRacuna
        {
            get { return brojRacuna; }
            set
            {
                brojRacuna = value;
                OnPropertyChanged("BrojRacuna");
            }
        }



        public string Kupac
        {
            get { return kupac; }
            set
            {
                kupac = value;
                OnPropertyChanged("Kupac");
            }
        }



        public double UkupnaCenaSaPDV
        {
            get
            {
                return ukupnaCenaSaPDV;
            }
            set
            {
                ukupnaCenaSaPDV = value;
                OnPropertyChanged("UkupnaCenaSaPDV");
            }
        }


        

        public double UkupnaCenaBezPDV
        {
            get
            {
                return ukupnaCenaBezPDV ;
            }
            set
            {
                ukupnaCenaBezPDV = value; 
                OnPropertyChanged("UkupnaCenaBezPDV");
            }
        }

    
       



        public static ProdajaNamestaja GetById(int Id)
        {
            foreach (var prodaja in Projekat.Instance.Prodaja)
            {
                if (prodaja.Id == Id)
                {
                    return prodaja;
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
            return new ProdajaNamestaja()
            {
                Id = id,
                DatumProdaje = datumProdaje,
                BrojRacuna = brojRacuna,
                Kupac = kupac,
                UkupnaCenaSaPDV = ukupnaCenaSaPDV,
                UkupnaCenaBezPDV = ukupnaCenaBezPDV,
                StavkeProdaje = new ObservableCollection<StavkaProdaje>()

            };
        }

        #region CRUD
        public static ObservableCollection<ProdajaNamestaja> GetAll()
        {
            var prodaja = new ObservableCollection<ProdajaNamestaja>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM ProdajaNamestaja";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "ProdajaNamestaja"); // izvrsavanje upita

                foreach (DataRow row in ds.Tables["ProdajaNamestaja"].Rows)
                {
                    var pn = new ProdajaNamestaja();
                    pn.Id = int.Parse(row["Id"].ToString());
                    pn.DatumProdaje = DateTime.Parse(row["DatumProdaje"].ToString());
                    pn.BrojRacuna = row["BrojRacuna"].ToString();
                    pn.Kupac = row["Kupac"].ToString();
                    pn.UkupnaCenaBezPDV = double.Parse(row["UkupnaCenaBezPDV"].ToString());
                    pn.UkupnaCenaSaPDV = double.Parse(row["UkupnaCenaSaPDV"].ToString());
                    
                    
                    prodaja.Add(pn);
                }

            }
            return prodaja;
        }

        public static ProdajaNamestaja Create(ProdajaNamestaja pn)
        {

            Random random = new Random();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO ProdajaNamestaja (DatumProdaje,BrojRacuna,Kupac,UkupnaCenaBezPDV,UkupnaCenaSaPDV) VALUES (@DatumProdaje,@BrojRacuna,@Kupac,@UkupnaCenaBezPDV,@UkupnaCenaSaPDV);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("DatumProdaje", pn.DatumProdaje);
                //pn.BrojRacuna = "FTN" + random.Next(1, 9999);
                cmd.Parameters.AddWithValue("BrojRacuna", pn.BrojRacuna);
                cmd.Parameters.AddWithValue("Kupac", pn.Kupac);
                cmd.Parameters.AddWithValue("UkupnaCenaBezPDV", pn.UkupnaCenaBezPDV);
                cmd.Parameters.AddWithValue("UkupnaCenaSaPDV", pn.UkupnaCenaSaPDV);
                

                pn.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

            }

            Projekat.Instance.Prodaja.Add(pn);
            return pn;
        }
        //azuriranje baze
        public static void Update(ProdajaNamestaja pn)
        {


            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE ProdajaNamestaja SET DatumProdaje = @DatumProdaje,BrojRacuna = @BrojRacuna,Kupac = @Kupac, UkupnaCenaBezPDV = @UkupnaCenaBezPDV,UkupnaCenaSaPDV = @UkupnaCenaSaPDV WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", pn.Id);
                cmd.Parameters.AddWithValue("DatumProdaje", pn.DatumProdaje);
                cmd.Parameters.AddWithValue("BrojRacuna", pn.BrojRacuna);
                cmd.Parameters.AddWithValue("Kupac", pn.Kupac);
                cmd.Parameters.AddWithValue("UkupnaCenaBezPDV", pn.UkupnaCenaBezPDV);
                cmd.Parameters.AddWithValue("UkupnaCenaSaPDV", pn.UkupnaCenaBezPDV);


                cmd.ExecuteNonQuery();

            }
            //azuriranje modela
            foreach (var prodaja in Projekat.Instance.Prodaja)
            {
                if (pn.Id == prodaja.Id)
                {
                    prodaja.DatumProdaje = pn.DatumProdaje;
                    prodaja.BrojRacuna = pn.BrojRacuna;
                    prodaja.Kupac = pn.Kupac;
                    prodaja.UkupnaCenaBezPDV = pn.UkupnaCenaBezPDV;
                    prodaja.UkupnaCenaSaPDV = pn.UkupnaCenaSaPDV;
                }
            }

        }

       
        #endregion
    }

}
