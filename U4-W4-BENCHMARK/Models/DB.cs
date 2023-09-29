using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace U4_W4_BENCHMARK.Models
{
    public class DB
    {
        public static string connectionString = ConfigurationManager.ConnectionStrings["ConnectionDB"].ConnectionString.ToString();
        public static SqlConnection conn = new SqlConnection(connectionString);

        public static List<Trasgressore> getTrasgressori()
        {
            List<Trasgressore> lista = new List<Trasgressore>();
            SqlCommand cmd = new SqlCommand("select * from Anagrafica", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Trasgressore utente = new Trasgressore();
                utente.IdTrasgressore = Convert.ToInt32(sqlDataReader["IdAnagrafica"]);
                utente.Nome = sqlDataReader["Nome"].ToString();
                utente.Cognome = sqlDataReader["Cognome"].ToString();
                utente.Citta = sqlDataReader["Citta"].ToString();
                utente.Indirizzo = sqlDataReader["Indirizzo"].ToString();
                utente.Cap = Convert.ToInt32(sqlDataReader["Cap"]);
                utente.CodiceFiscale = sqlDataReader["CodiceFiscale"].ToString();
                lista.Add(utente);
            }
            conn.Close();
            return lista;
        }

        public static List<Verbale> getVerbali()
        {
            List<Verbale> verbaliList = new List<Verbale>();
            SqlCommand cmd = new SqlCommand("select *, Nome, Cognome, Descrizione from Verbale INNER JOIN Anagrafica on Verbale.IdAnagrafica = Anagrafica.IdAnagrafica INNER JOIN Tipoviolazione on verbale.IdViolazione = Tipoviolazione.IdViolazione", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Verbale verbale = new Verbale();
                verbale.IdVerbale = Convert.ToInt32(sqlDataReader["IdVerbale"]);
                verbale.DataViolazione = Convert.ToDateTime(sqlDataReader["DataViolazione"]);
                verbale.DataVerbale = Convert.ToDateTime(sqlDataReader["DataVerbale"]);
                verbale.Importo = Convert.ToInt32(sqlDataReader["Importo"]);
                verbale.IndirizzoViolazione = sqlDataReader["IndirizzoViolazione"].ToString();
                verbale.NominativoAgente = sqlDataReader["NominativoAgente"].ToString();
                verbale.Violazione = sqlDataReader["Descrizione"].ToString();
                verbale.Trasgressore = $"{sqlDataReader["Cognome"]} " + $"{sqlDataReader["Nome"]}";
                verbale.DecurtamentoPunti = Convert.ToInt32(sqlDataReader["DecurtamentoPunti"]);
                verbaliList.Add(verbale);

            }
            conn.Close();
            return verbaliList;
        }

        public static List<Violazione> getViolazioni()
        {
            List<Violazione> violazioniList = new List<Violazione>();
            SqlCommand cmd = new SqlCommand("select * from Tipoviolazione", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Violazione violazione = new Violazione();
                violazione.IdViolazione = Convert.ToInt32(sqlDataReader["IdViolazione"]);
                violazione.Descrizione = sqlDataReader["Descrizione"].ToString();
                violazioniList.Add(violazione);

            }
            conn.Close();
            return violazioniList;
        }

        public static void insertAnagrafica(Trasgressore t)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO Anagrafica Values(@Cognome, @Nome, @Indirizzo, @Citta, @Cap, @CodiceFiscale)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("Cognome", t.Cognome);
            cmd.Parameters.AddWithValue("Nome", t.Nome);
            cmd.Parameters.AddWithValue("Indirizzo", t.Indirizzo);
            cmd.Parameters.AddWithValue("Citta", t.Citta);
            cmd.Parameters.AddWithValue("Cap", t.Cap);
            cmd.Parameters.AddWithValue("CodiceFiscale", t.CodiceFiscale);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void insertViolazione(Violazione v)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO Tipoviolazione Values(@Descrizione)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("Descrizione", v.Descrizione);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static void insertVerbale(Verbale v)
        {
            SqlCommand cmd = new SqlCommand("Insert INTO Verbale Values(@DataViolazione, @IndirizzoViolazione, @NominativoAgente, @Dataverbale, @Importo, @DecurtamentoPunti, @IdAnagrafica, @IdViolazione)", conn);
            conn.Open();
            cmd.Parameters.AddWithValue("DataViolazione", v.DataViolazione);
            cmd.Parameters.AddWithValue("IndirizzoViolazione", v.IndirizzoViolazione);
            cmd.Parameters.AddWithValue("NominativoAgente", v.NominativoAgente);
            cmd.Parameters.AddWithValue("DataVerbale", v.DataVerbale);
            cmd.Parameters.AddWithValue("Importo", v.Importo);
            cmd.Parameters.AddWithValue("DecurtamentoPunti", v.DecurtamentoPunti);
            cmd.Parameters.AddWithValue("IdAnagrafica", v.Trasgressore);
            cmd.Parameters.AddWithValue("IdViolazione", v.Violazione);
            cmd.ExecuteNonQuery();
            conn.Close();
        }

        public static List<VerbaliTotali> verbaliPerTrasgressore()
        {
            List<VerbaliTotali> verbaliList = new List<VerbaliTotali>();
            SqlCommand cmd = new SqlCommand("select Nome, Cognome, Count(*) as NumeroVerbali from Verbale INNER JOIN Anagrafica on Verbale.IdAnagrafica = Anagrafica.IdAnagrafica group by Cognome, Nome", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                VerbaliTotali verbale = new VerbaliTotali();
                verbale.Cognome = sqlDataReader["Cognome"].ToString();
                verbale.Nome = sqlDataReader["Nome"].ToString();
                verbale.Totale = Convert.ToInt32(sqlDataReader["NumeroVerbali"]);
                verbaliList.Add(verbale);

            }
            conn.Close();
            return verbaliList;
        }

        public static List<PuntiTotali> puntiPerTrasgressore()
        {
            List<PuntiTotali> puntiList = new List<PuntiTotali>();
            SqlCommand cmd = new SqlCommand("select Nome, Cognome, Sum(DecurtamentoPunti) as PuntiTotali from Verbale INNER JOIN Anagrafica on Verbale.IdAnagrafica = Anagrafica.IdAnagrafica group by Cognome, Nome", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                PuntiTotali verbale = new PuntiTotali();
                verbale.Cognome = sqlDataReader["Cognome"].ToString();
                verbale.Nome = sqlDataReader["Nome"].ToString();
                verbale.Totale = Convert.ToInt32(sqlDataReader["PuntiTotali"]);
                puntiList.Add(verbale);

            }
            conn.Close();
            return puntiList;
        }

        public static List<Over10>overDieciPerTrasgressore()
        {
            List<Over10> puntiList = new List<Over10>();
            SqlCommand cmd = new SqlCommand("select Nome, Cognome, Importo, DecurtamentoPunti, DataViolazione from Verbale INNER JOIN Anagrafica on Verbale.IdAnagrafica = Anagrafica.IdAnagrafica where DecurtamentoPunti > 10", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                Over10 verbale = new Over10();
                verbale.Cognome = sqlDataReader["Cognome"].ToString();
                verbale.Nome = sqlDataReader["Nome"].ToString();
                verbale.Importo = Convert.ToInt32(sqlDataReader["Importo"]);
                verbale.DataViolazione = Convert.ToDateTime(sqlDataReader["DataViolazione"]);
                verbale.DecurtamentoPunti = Convert.ToInt32(sqlDataReader["DecurtamentoPunti"]);
                puntiList.Add(verbale);

            }
            conn.Close();
            return puntiList;
        }

        public static List<MaxiMulte> MaxiMulte()
        {
            List<MaxiMulte> maxiList = new List<MaxiMulte>();
            SqlCommand cmd = new SqlCommand("select Nome, Cognome, Importo, DataViolazione from Verbale INNER JOIN Anagrafica on Verbale.IdAnagrafica = Anagrafica.IdAnagrafica where Importo > 400", conn);
            SqlDataReader sqlDataReader;
            conn.Open();
            sqlDataReader = cmd.ExecuteReader();

            while (sqlDataReader.Read())
            {
                MaxiMulte verbale = new MaxiMulte();
                verbale.Cognome = sqlDataReader["Cognome"].ToString();
                verbale.Nome = sqlDataReader["Nome"].ToString();
                verbale.Importo = Convert.ToInt32(sqlDataReader["Importo"]);
                verbale.DataViolazione = Convert.ToDateTime(sqlDataReader["DataViolazione"]);
                maxiList.Add(verbale);

            }
            conn.Close();
            return maxiList;
        }
    }
}