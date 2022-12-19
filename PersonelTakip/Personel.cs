using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTakip
{
    public class Personel
    {
        public int personelID { get; set; }
        public int departmanID { get; set; }
        public string departman { get; set; }
        public string adi { get; set; }
        public string soyAdi { get; set; }
        public char cinsiyet { get; set; }
        public decimal maas { get; set; }
        public DateTime baslamaTarihi { get; set; }
        public DateTime bitisTarihi { get; set; }
    }
}
