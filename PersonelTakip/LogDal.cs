using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PersonelTakip
{
    public class LogDal
    {
        SqlConnection _conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; initial catalog = PersonelTakip; integrated security = true");

        public void ConnectionControl()
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
        }

        public List<Log> GetAll(string sorgu)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand(sorgu, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Log> loglar = new List<Log>();
            while (reader.Read())
            {
                Log log = new Log
                {
                    logID = Convert.ToInt32(reader["LogID"]),
                    aciklama = reader["Aciklama"].ToString(),
                    tarih = Convert.ToDateTime(reader["Tarih"]),
                };
                loglar.Add(log);
            }
            reader.Close();
            _conn.Close();
            return loglar;
        }

        public List<Log> GetSP(string sorgu,string kelime)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand(sorgu, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sorguKelime",kelime);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Log> loglar = new List<Log>();
            while (reader.Read())
            {
                Log log = new Log
                {
                    logID = Convert.ToInt32(reader["LogID"]),
                    aciklama = reader["Aciklama"].ToString(),
                    tarih = Convert.ToDateTime(reader["Tarih"]),
                };
                loglar.Add(log);
            }
            reader.Close();
            _conn.Close();
            return loglar;
        }

    }
}
