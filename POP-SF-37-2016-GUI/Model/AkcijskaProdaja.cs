using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Xml.Serialization;

namespace POP_37_2016.Model
{
    public class AkcijskaProdaja : INotifyPropertyChanged
    {
        private int id;
        private string naziv;
        private double popust;
        private DateTime datumPocetka;
        private DateTime datumZavrsetka;
        private ObservableCollection<Namestaj> namestajNaAkciji;
       
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


        public double Popust
        {
            get { return popust; }
            set
            {
                popust = value;
                OnPropertyChanged("Popust");
            }
        }


        public DateTime DatumPocetka
        {
            get { return datumPocetka; }
            set
            {
                datumPocetka = value;
                OnPropertyChanged("DatumPocetka");
            }
        }

       

        public DateTime DatumZavrsetka
        {
            get { return datumZavrsetka; }
            set
            {
                datumZavrsetka = value;
                OnPropertyChanged("DatumZavrsetka");
            }
        }

        

        public ObservableCollection<Namestaj> NamestajNaAkciji
        {
            get { return namestajNaAkciji; }
            set
            {
                namestajNaAkciji = value;
                OnPropertyChanged("NamestajNaAkcijiId");
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

            return $"{Naziv}";
            
        }

        public static AkcijskaProdaja GetById(int Id)
        {
            foreach (var akcija in Projekat.Instance.AkcijskaProdaja)
            {
                if (akcija.Id == Id)
                {
                    return akcija;
                }
            }
            return null;
        }

        

        public object Clone()
        {
            return new AkcijskaProdaja()
            {
                Naziv = naziv,
                Popust = popust,
                DatumPocetka = datumPocetka,
                DatumZavrsetka = datumZavrsetka,
                NamestajNaAkciji = new ObservableCollection<Namestaj>(NamestajNaAkciji),
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
        public static ObservableCollection<AkcijskaProdaja> GetAll()
        {
            var akcija = new ObservableCollection<AkcijskaProdaja>();
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();
                cmd.CommandText = "SELECT * FROM AkcijskaProdaja WHERE Obrisan = 0;";
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "AkcijskaProdaja"); // izvrsavanje upita

                

                
                
                foreach (DataRow row in ds.Tables["AkcijskaProdaja"].Rows)
                {
                    var ap = new AkcijskaProdaja();
                    ap.Id = int.Parse(row["Id"].ToString());
                    ap.Naziv = row["Naziv"].ToString();
                    ap.Popust = double.Parse(row["Popust"].ToString());
                    ap.DatumPocetka = DateTime.Parse(row["DatumPocetka"].ToString());
                    ap.DatumZavrsetka = DateTime.Parse(row["DatumZavrsetka"].ToString());
                    ap.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    if (DateTime.Today > ap.DatumZavrsetka)
                    {
                        ap.Obrisan = true;
                        Update(ap);
                    }

                    akcija.Add(ap);
                }
                

            }
            return akcija;
        }

        public static AkcijskaProdaja Create(AkcijskaProdaja ap)
        {

            

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO AkcijskaProdaja (Naziv,Popust,DatumPocetka,DatumZavrsetka,Obrisan) VALUES (@Naziv,@Popust,@DatumPocetka,@DatumZavrsetka,@Obrisan);";
                cmd.CommandText += "SELECT SCOPE_IDENTITY();";
                cmd.Parameters.AddWithValue("Naziv", ap.Naziv);
                cmd.Parameters.AddWithValue("Popust", ap.Popust);
                cmd.Parameters.AddWithValue("DatumPocetka", ap.DatumPocetka);
                cmd.Parameters.AddWithValue("DatumZavrsetka", ap.DatumZavrsetka);
                cmd.Parameters.AddWithValue("Obrisan", ap.Obrisan);

                ap.Id = int.Parse(cmd.ExecuteScalar().ToString()); //executeScalar izvrsava upit

                
                for (int i = 0; i < ap.NamestajNaAkciji.Count; i++)
                {
                    SqlCommand command = conn.CreateCommand();

                    command.CommandText = "INSERT INTO NaAkciji (NamestajId,AkcijskaProdajaId) VALUES (@NamestajId,@AkcijskaProdajaId);";

                    command.Parameters.AddWithValue("NamestajId", ap.NamestajNaAkciji[i].Id);
                    command.Parameters.AddWithValue("AkcijskaProdajaId", ap.Id);
                    command.ExecuteNonQuery();
                }
                


            }

            Projekat.Instance.AkcijskaProdaja.Add(ap);
            return ap;
        }
        //azuriranje baze
        public static void Update(AkcijskaProdaja ap)
        {


            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "UPDATE AkcijskaProdaja SET Naziv = @Naziv,DatumPocetka = @DatumPocetka,DatumZavrsetka = @DatumZavrsetka, Obrisan= @Obrisan WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", ap.Id);
                cmd.Parameters.AddWithValue("Naziv", ap.Naziv);
                cmd.Parameters.AddWithValue("DatumPocetka", ap.DatumPocetka);
                cmd.Parameters.AddWithValue("DatumZavrsetka", ap.DatumZavrsetka);
                cmd.Parameters.AddWithValue("Obrisan", ap.Obrisan);

                cmd.ExecuteNonQuery();

            }
            //azuriranje modela
            foreach (var akcija in Projekat.Instance.AkcijskaProdaja)
            {
                if (ap.Id == akcija.Id)
                {
                    akcija.Naziv = ap.Naziv;
                    akcija.DatumPocetka = ap.DatumPocetka;
                    akcija.DatumZavrsetka = ap.DatumZavrsetka;
                    akcija.Obrisan = ap.Obrisan;
                }
            }

        }

        public static void Delete(AkcijskaProdaja ap)
        {
            ap.Obrisan = true;
            Update(ap);
        }
        #endregion
        /*
        public static AkcijskaProdaja DodajNaAkciju (AkcijskaProdaja ap, ObservableCollection<Namestaj> dodajNaAkciju)
        {
            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                conn.Open();

                SqlCommand cmd = conn.CreateCommand();

                cmd.CommandText = "INSERT INTO NaAkciji (NamestajId,AkcijskaProdajaId) VALUES (@NamestajId,@AkcijskaProdajaId);";
                

                cmd.ExecuteNonQuery();


            }

           
            return ap;
        }*/
    }


}