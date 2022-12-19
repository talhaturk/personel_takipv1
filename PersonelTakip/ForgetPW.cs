using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PersonelTakip
{
    public partial class ForgetPW : Form
    {
        public ForgetPW()
        {
            InitializeComponent();
        }

        private void ForgetPW_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            KullaniciDal kullaniciDal = new KullaniciDal();
            List<Kullanici> kullanicilar = new List<Kullanici>();
            kullanicilar = kullaniciDal.GetALL();
            foreach (Kullanici kullanici in kullanicilar)
            {
                if (lblKullaniciAdi.Text == kullanici.kullaniciAdi.ToString())
                {
                    lblGizliSoru.Text = kullanici.gizliSoru.ToString();
                }
            }

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            KullaniciDal kullaniciDal = new KullaniciDal();
            List<Kullanici> kullanicilar = new List<Kullanici>();
            kullanicilar = kullaniciDal.GetALL();
            int sayac = 0;
            foreach (Kullanici kullanici in kullanicilar)
            {
                if (lblKullaniciAdi.Text == kullanici.kullaniciAdi.ToString() && tbxGizliSoruCevap.Text == kullanici.gizliSoruCevap.ToString())
                {
                    sayac = 0;
                    MessageBox.Show(kullanici.sifre.ToString(), "Şifreniz:");
                    this.Close();
                    break;
                }
                else
                    sayac++;
            }
            if ( sayac > 0 )
                MessageBox.Show("Girilen cevap hatalı!");
        }
    }
}
