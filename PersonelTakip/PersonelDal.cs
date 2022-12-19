using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace PersonelTakip
{
    public class PersonelDal
    {
        SqlConnection _conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; initial catalog = PersonelTakip; integrated security = true");
       
        public void ConnectionControl()
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
        }

        public List<Personel> GetAll(string sorgu)
        {

            ConnectionControl();
            SqlCommand cmd = new SqlCommand(sorgu, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Personel> personeller = new List<Personel>();
            while (reader.Read())
            {
                Personel personel = new Personel
                {
                    personelID = Convert.ToInt32(reader["PersonelID"]),
                    departmanID = Convert.ToInt32(reader["DepartmanID"]),
                    departman = reader["DepartmanAdi"].ToString(),
                    adi = reader["Adi"].ToString(),
                    soyAdi = reader["Soyadi"].ToString(),
                    cinsiyet = Convert.ToChar(reader["Cinsiyet"]),
                    maas = Convert.ToInt32(reader["Maas"]),
                    baslamaTarihi = Convert.ToDateTime(reader["BaslamaTarihi"]),
                    bitisTarihi = Convert.ToDateTime(reader["BitisTarihi"])

                };
                personeller.Add(personel);
            }
            reader.Close();
            _conn.Close();
            return personeller;
        }

        public List<Personel> GetSP(string sorguKelime,string kelime)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand(sorguKelime, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sorguKelime", kelime);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Personel> personeller = new List<Personel>();
            while (reader.Read())
            {
                Personel personel = new Personel
                {
                    personelID = Convert.ToInt32(reader["PersonelID"]),
                    departmanID = Convert.ToInt32(reader["DepartmanID"]),
                    departman = reader["DepartmanAdi"].ToString(),
                    adi = reader["Adi"].ToString(),
                    soyAdi = reader["Soyadi"].ToString(),
                    cinsiyet = Convert.ToChar(reader["Cinsiyet"]),
                    maas = Convert.ToInt32(reader["Maas"]),
                    baslamaTarihi = Convert.ToDateTime(reader["BaslamaTarihi"]),
                    bitisTarihi = Convert.ToDateTime(reader["BitisTarihi"])

                };
                personeller.Add(personel);
            }
            reader.Close();
            _conn.Close();
            return personeller;
        }

        public void Add(Personel personel)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("insert into Personeller values (@departmanID,@adi,@soyadi,@cinsiyeti,@maas,@baslamaTarihi,@bitisTarihi)", _conn);
            cmd.Parameters.AddWithValue("@departmanID", personel.departmanID);
            cmd.Parameters.AddWithValue("@adi", personel.adi);
            cmd.Parameters.AddWithValue("@soyadi", personel.soyAdi);
            cmd.Parameters.AddWithValue("@cinsiyeti", personel.cinsiyet);
            cmd.Parameters.AddWithValue("@maas", personel.maas);
            cmd.Parameters.AddWithValue("@baslamaTarihi", personel.baslamaTarihi);
            cmd.Parameters.AddWithValue("@bitisTarihi", personel.bitisTarihi);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Update(Personel personel, int id)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("update Personeller set DepartmanID=@departmanID,Adi=@adi,Soyadi=@soyadi,Cinsiyet=@cinsiyeti,Maas=@maas,BaslamaTarihi=@baslamaTarihi,BitisTarihi=@bitisTarihi where PersonelID = @id", _conn);
            cmd.Parameters.AddWithValue("@departmanID", personel.departmanID);
            cmd.Parameters.AddWithValue("@adi", personel.adi);
            cmd.Parameters.AddWithValue("@soyadi", personel.soyAdi);
            cmd.Parameters.AddWithValue("@cinsiyeti", personel.cinsiyet);
            cmd.Parameters.AddWithValue("@maas", personel.maas);
            cmd.Parameters.AddWithValue("@baslamaTarihi", personel.baslamaTarihi);
            cmd.Parameters.AddWithValue("@bitisTarihi", personel.bitisTarihi);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("delete from Personeller where PersonelID = @id", _conn);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

    }
}
