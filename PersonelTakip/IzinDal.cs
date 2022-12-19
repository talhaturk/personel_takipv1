using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace PersonelTakip
{
    public class IzinDal
    {
        SqlConnection _conn = new SqlConnection("server = (localdb)\\MSSQLLocalDB; initial catalog = PersonelTakip; integrated security = true");

        public void ConnectionControl()
        {
            if (_conn.State == ConnectionState.Closed)
            {
                _conn.Open();
            }
        }

        public List<Izin> GetAll(string sorgu)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand(sorgu, _conn);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Izin> izinler = new List<Izin>();
            while(reader.Read())
            {
                Izin izin = new Izin
                {
                    izinID = Convert.ToInt32(reader["IzinID"]),
                    personelID = Convert.ToInt32(reader["PersonelID"]),
                    personelAdi = reader["Adi"].ToString(),
                    personelSoyadi = reader["Soyadi"].ToString(),
                    izinTur = reader["IzinTur"].ToString(),
                    aciklama = reader["Aciklama"].ToString(),
                    baslamaTarihi = Convert.ToDateTime(reader["BaslamaTarihi"]),
                    bitisTarihi = Convert.ToDateTime(reader["BitisTarihi"])
                };
                izinler.Add(izin);
            }
            reader.Close();
            _conn.Close();
            return izinler;
        }

        public List<Izin> GetSP(string sorgu,string kelime)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand(sorgu, _conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@sorguKelime", kelime);
            SqlDataReader reader = cmd.ExecuteReader();
            List<Izin> izinler = new List<Izin>();
            while (reader.Read())
            {
                Izin izin = new Izin
                {
                    izinID = Convert.ToInt32(reader["IzinID"]),
                    personelID = Convert.ToInt32(reader["PersonelID"]),
                    personelAdi = reader["Adi"].ToString(),
                    personelSoyadi = reader["Soyadi"].ToString(),
                    izinTur = reader["IzinTur"].ToString(),
                    aciklama = reader["Aciklama"].ToString(),
                    baslamaTarihi = Convert.ToDateTime(reader["BaslamaTarihi"]),
                    bitisTarihi = Convert.ToDateTime(reader["BitisTarihi"])
                };
                izinler.Add(izin);
            }
            reader.Close();
            _conn.Close();
            return izinler;
        }

        public void Add(Izin izin)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("insert into Izinler values (@personelID,@izinTur,@aciklama,@baslamaTarihi,@bitisTarihi)", _conn);
            cmd.Parameters.AddWithValue("@personelID", izin.personelID);
            cmd.Parameters.AddWithValue("@izinTur", izin.izinTur);
            cmd.Parameters.AddWithValue("@aciklama", izin.aciklama);
            cmd.Parameters.AddWithValue("@baslamaTarihi", izin.baslamaTarihi);
            cmd.Parameters.AddWithValue("@bitisTarihi", izin.bitisTarihi);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Update(Izin izin,int id)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("update Izinler set PersonelID=@personelID, IzinTur=@izinTur, Aciklama=@aciklama, BaslamaTarihi=@baslamaTarihi, BitisTarihi=@bitisTarihi where IzinID=@id", _conn);
            cmd.Parameters.AddWithValue("@personelID", izin.personelID);
            cmd.Parameters.AddWithValue("@izinTur", izin.izinTur);
            cmd.Parameters.AddWithValue("@aciklama", izin.aciklama);
            cmd.Parameters.AddWithValue("@baslamaTarihi", izin.baslamaTarihi);
            cmd.Parameters.AddWithValue("@bitisTarihi", izin.bitisTarihi);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }

        public void Delete(int id)
        {
            ConnectionControl();
            SqlCommand cmd = new SqlCommand("delete from Izinler where IzinID = @id", _conn);
            cmd.Parameters.AddWithValue("@id",id);
            cmd.ExecuteNonQuery();
            _conn.Close();
        }
    }
}
