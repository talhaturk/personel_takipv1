using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data;
using System.Data.SqlClient;

namespace PersonelTakip
{
    public partial class Login : Form
    {      
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
        }
        private void btn_giris_Click(object sender, EventArgs e)
        {
            MainMenu mainMenu = new MainMenu();
            KullaniciDal kullaniciDal = new KullaniciDal();
            List<Kullanici> kullanicilar = new List<Kullanici>();
            kullanicilar = kullaniciDal.GetALL();
            int sayac = 0;
            foreach (Kullanici kullanici in kullanicilar)
            {
                if (tbxKullaniciAdi.Text == kullanici.kullaniciAdi.ToString() && tbxParola.Text == kullanici.sifre.ToString())
                {
                    sayac = 0;
                    mainMenu.Show();
                    this.Hide();
                    break;
                }
                else
                    sayac++;
            }

            if (sayac > 0)
                MessageBox.Show("Giriş bilgileri hatalı!");

        }

        private void lbl_sifremiUnuttum_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            ForgetPW forgetPW = new ForgetPW();
            KullaniciDal kullaniciDal = new KullaniciDal();
            List<Kullanici> kullanicilar = new List<Kullanici>();
            kullanicilar = kullaniciDal.GetALL();
            int sayac = 0;
            foreach (Kullanici kullanici in kullanicilar)
            {
                if ( tbxKullaniciAdi.Text == kullanici.kullaniciAdi.ToString() )
                {
                    sayac = 0;
                    forgetPW.lblKullaniciAdi.Text = tbxKullaniciAdi.Text;
                    forgetPW.ShowDialog();
                    break;
                }
                else 
                {
                    sayac += 1;
                }      
            }

            if (sayac > 0)
            {
                MessageBox.Show("Lütfen geçerli kullanıcı adı giriniz.");
            }
        }

    }
}