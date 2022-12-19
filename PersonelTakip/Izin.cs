using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonelTakip
{
    public class Izin
    {
        public int izinID { get; set; }
        public int personelID { get; set; }
        public string personelAdi { get; set; }
        public string personelSoyadi { get; set; }
        public string izinTur { get; set; }
        public string aciklama { get; set; }
        public DateTime baslamaTarihi { get; set; }
        public DateTime bitisTarihi { get; set; }
    }
}
