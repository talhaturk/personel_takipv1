using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTakip
{
    public class DepartmanDal
    {
        SqlConnection _conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; initial catalog = PersonelTakip; integrated security = true");

        public void ConnectionControl()
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
        }

        public List<Departman> GetAll(string sorgu)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand(sorgu, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Departman> departmanlar = new List<Departman>();
            while (reader.Read())
            {
                Departman departman = new Departman
                {
                    departmanID = Convert.ToInt32(reader["DepartmanID"]),
                    departmanAdi = reader["DepartmanAdi"].ToString()
                };
                departmanlar.Add(departman);
            }
            reader.Close();
            _conn.Close();
            return departmanlar;
        }

        public List<Departman> GetSP(string sorgu,string kelime)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand(sorgu, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sorguKelime",kelime);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Departman> departmanlar = new List<Departman>();
            while (reader.Read())
            {
                Departman departman = new Departman
                {
                    departmanID = Convert.ToInt32(reader["DepartmanID"]),
                    departmanAdi = reader["DepartmanAdi"].ToString()
                };
                departmanlar.Add(departman);
            }
            reader.Close();
            _conn.Close();
            return departmanlar;
        }

        public void Add(Departman departman)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("insert into Departmanlar values (@departmanAdi)", _conn);
            cmd.Parameters.AddWithValue("@departmanAdi", departman.departmanAdi);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Update(Departman departman, int id)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("update Departmanlar set DepartmanAdi = @departmanAdi where DepartmanID = @departmanID", _conn);
            cmd.Parameters.AddWithValue("@departmanAdi", departman.departmanAdi);
            cmd.Parameters.AddWithValue("@departmanID", id);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("delete from Departmanlar where DepartmanID = @departmanID", _conn);
            cmd.Parameters.AddWithValue("@departmanID", id);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }
    }
}
