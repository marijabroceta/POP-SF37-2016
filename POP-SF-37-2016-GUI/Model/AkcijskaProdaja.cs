using POP_SF_37_2016_GUI.Model;
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
        public ObservableCollection<NaAkciji> NamestajAkcija { get; set; }

        public int NamestajId { get; set; }

        private bool obrisan;

        public AkcijskaProdaja()
        {
            NamestajNaAkciji = new ObservableCollection<Namestaj>();
            NamestajAkcija = new ObservableCollection<NaAkciji>();
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
                OnPropertyChanged("NamestajNaAkciji");
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
                Id = id,
                Naziv = naziv,
                Popust = popust,
                DatumPocetka = datumPocetka,
                DatumZavrsetka = datumZavrsetka,
                NamestajNaAkciji = new ObservableCollection<Namestaj>(NamestajNaAkciji),
                NamestajId = NamestajId,
                NamestajAkcija = new ObservableCollection<NaAkciji>(NamestajAkcija),
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
                        AkcijskaProdaja.Delete(ap);
                        
                    }

                    akcija.Add(ap);



                }


                
                return akcija;

            }
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

                
                for (int i = 0; i < ap.NamestajAkcija.Count; i++)
                {
                    SqlCommand command = conn.CreateCommand();

                    command.CommandText = "INSERT INTO NaAkciji (NamestajId,AkcijskaProdajaId,Obrisan) VALUES (@NamestajId,@AkcijskaProdajaId,@Obrisan);";

                    command.Parameters.AddWithValue("NamestajId", ap.NamestajAkcija[i].NamestajId);
                    command.Parameters.AddWithValue("AkcijskaProdajaId", ap.Id);
                    command.Parameters.AddWithValue("Obrisan", ap.Obrisan);
                    command.ExecuteNonQuery();

                    foreach (var n in Projekat.Instance.Namestaj)
                    {


                        if (n.Id == ap.NamestajAkcija[i].NamestajId)
                        {
                            n.CenaNaAkciji = n.JedinicnaCena - n.JedinicnaCena * (ap.Popust / 100);
                            n.AkcijaId = ap.Id;
                            Namestaj.Update(n);
                        }


                    }

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

                cmd.CommandText = "UPDATE AkcijskaProdaja SET Naziv = @Naziv,Popust = @Popust,DatumPocetka = @DatumPocetka,DatumZavrsetka = @DatumZavrsetka, Obrisan= @Obrisan WHERE Id = @Id";
                cmd.Parameters.AddWithValue("Id", ap.Id);
                cmd.Parameters.AddWithValue("Naziv", ap.Naziv);
                cmd.Parameters.AddWithValue("Popust", ap.Popust);
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
                    akcija.Popust = ap.Popust;
                    akcija.DatumPocetka = ap.DatumPocetka;
                    akcija.DatumZavrsetka = ap.DatumZavrsetka;
                    akcija.Obrisan = ap.Obrisan;
                }
            }

        }

        public static void Delete(AkcijskaProdaja ap)
        {
            
            ap.Obrisan = true;

            if (ap.NamestajNaAkciji.Count > 0)
            {
                for (int i = 0; i < ap.NamestajNaAkciji.Count; i++)
                {
                    ap.NamestajNaAkciji[i].CenaNaAkciji = 0;
                    Namestaj.Update(ap.NamestajNaAkciji[i]);
                    foreach (var n in Projekat.Instance.Namestaj)
                    {
                        if (n.Id == ap.NamestajNaAkciji[i].Id)
                        {
                            n.CenaNaAkciji = 0;
                        }
                    }
                }
            }
                
            Update(ap);
        }
        #endregion
        #region Search

        public enum TipPretrage
        {
            NAZIV,
            DATUMP,
            DATUMZ,
            NAMESTAJ

        }


        public static ObservableCollection<AkcijskaProdaja> PretragaAkcije(string unos, TipPretrage tipPretrage,DateTime? poDatumu)
        {
            var akcija = new ObservableCollection<AkcijskaProdaja>();

            using (var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["POP"].ConnectionString))
            {
                SqlCommand cmd = conn.CreateCommand();
                SqlDataAdapter da = new SqlDataAdapter();

                switch (tipPretrage)
                {
                    case TipPretrage.NAZIV:
                        cmd.CommandText = "SELECT * FROM AkcijskaProdaja WHERE Naziv LIKE @unos AND Obrisan = 0;";
                        cmd.Parameters.AddWithValue("unos", "%" + unos.Trim() + "%");
                        break;
                    case TipPretrage.DATUMP:
                        cmd.CommandText = "SELECT * FROM AkcijskaProdaja  WHERE  Obrisan = 0 AND DatumPocetka = @poDatumu;";
                        cmd.Parameters.AddWithValue("poDatumu", poDatumu);
                        break;
                    case TipPretrage.DATUMZ:
                        cmd.CommandText = "SELECT * FROM AkcijskaProdaja WHERE DatumZavrsetka = @poDatumu AND Obrisan = 0;";
                        cmd.Parameters.AddWithValue("poDatumu", poDatumu);
                        break;
                    case TipPretrage.NAMESTAJ:
                        cmd.CommandText = "SELECT * FROM AkcijskaProdaja ap INNER JOIN NaAkciji na ON ap.Id = na.AkcijskaProdajaId INNER JOIN Namestaj n ON n.Id = na.NamestajId WHERE n.Naziv LIKE @unos;";

                        cmd.Parameters.AddWithValue("unos", "%" + unos.Trim() + "%");
                        break;

                }
                
                da.SelectCommand = cmd;
                DataSet ds = new DataSet();
                da.Fill(ds, "AkcijskaProdaja");

                foreach (DataRow row in ds.Tables["AkcijskaProdaja"].Rows)
                {
                    var ap = new AkcijskaProdaja();
                    ap.Id = int.Parse(row["Id"].ToString());
                    ap.DatumPocetka = DateTime.Parse(row["DatumPocetka"].ToString());
                    ap.DatumZavrsetka = DateTime.Parse(row["DatumZavrsetka"].ToString());
                    ap.Popust = int.Parse(row["Popust"].ToString());
                    ap.Naziv = row["Naziv"].ToString();                   
                    ap.Obrisan = bool.Parse(row["Obrisan"].ToString());

                    akcija.Add(ap);
                }

            }
            return akcija;
        }

        #endregion
    }
}