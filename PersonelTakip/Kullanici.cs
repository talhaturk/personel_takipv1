using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTakip
{
    public class Kullanici
    {
        public int id { get; set; }
        public string kullaniciAdi { get; set; }
        public string sifre { get; set; }
        public string gizliSoru { get; set; }
        public string gizliSoruCevap { get; set; }
    }
}
