using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PersonelTakip
{
    public class KullaniciDal
    {
        SqlConnection _conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; initial catalog = PersonelTakip; integrated security = true");

        public void ConnectionControl()
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
        }
        public List<Kullanici> GetALL()
        {

            ConnectionControl();
            SqlCommand cmd = new SqlCommand("select * from Kullanicilar", _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Kullanici> kullanicilar = new List<Kullanici>();
            while (reader.Read())
            {
                Kullanici kullanici = new Kullanici
                {
                    id = Convert.ToInt32(reader["ID"]),
                    kullaniciAdi = reader["KullaniciAdi"].ToString(),
                    sifre = reader["Sifre"].ToString(),
                    gizliSoru = reader["GizliSoru"].ToString(),
                    gizliSoruCevap = reader["GizliSoruCevap"].ToString()
                };
                kullanicilar.Add(kullanici);
            }
            reader.Close();
            _conn.Close();
            return kullanicilar;
        }
    }
}
