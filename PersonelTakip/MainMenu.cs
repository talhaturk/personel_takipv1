using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;
using Microsoft.SqlServer.Management.Common;
using Microsoft.SqlServer.Management.Smo;

namespace PersonelTakip
{
    public partial class MainMenu : Form
    {
        public MainMenu()
        {
            InitializeComponent();
        }

        //-------------------------------------------------------------------------------------------------
        //-----------------------------------------Nesneler
        //-------------------------------------------------------------------------------------------------
        PersonelDal _personelDal = new PersonelDal();
        IzinDal _izinDal = new IzinDal();
        DepartmanDal _departmanDal = new DepartmanDal();
        LogDal _logDal = new LogDal();
        ExcellAktar _excellAktar = new ExcellAktar();
        
        
        //-------------------------------------------------------------------------------------------------
        //-----------------------------------------Fonksiyonlar
        //-------------------------------------------------------------------------------------------------
        public void LoadPersonel()
        {
            string sorgu = @"select * from Personeller as p inner join Departmanlar as d on p.DepartmanID = d.DepartmanID";
            dgwPersonel.DataSource = _personelDal.GetAll(sorgu);
            dgwPersonel.Columns[0].Visible = false;
            dgwPersonel.Columns[1].Visible = false;
            dgwPersonel.Columns[2].HeaderText = "Departman";
            dgwPersonel.Columns[3].HeaderText = "Ad";
            dgwPersonel.Columns[4].HeaderText = "Soyad";
            dgwPersonel.Columns[5].HeaderText = "Cinsiyet";
            dgwPersonel.Columns[6].HeaderText = "Maaş";
            dgwPersonel.Columns[7].HeaderText = "Başlama Tarihi";
            dgwPersonel.Columns[8].HeaderText = "Bitiş Tarihi";
            dgwPersonelIslemleri.DataSource = _personelDal.GetAll(sorgu);
            dgwPersonelIslemleri.Columns[0].Visible = false;
            dgwPersonelIslemleri.Columns[1].HeaderText = "Departman No";
            dgwPersonelIslemleri.Columns[2].HeaderText = "Departman";
            dgwPersonelIslemleri.Columns[3].HeaderText = "Ad";
            dgwPersonelIslemleri.Columns[4].HeaderText = "Soyad";
            dgwPersonelIslemleri.Columns[5].HeaderText = "Cinsiyet";
            dgwPersonelIslemleri.Columns[6].HeaderText = "Maaş";
            dgwPersonelIslemleri.Columns[7].HeaderText = "Başlama Tarihi";
            dgwPersonelIslemleri.Columns[8].HeaderText = "Bitiş Tarihi";
        }

        public void LoadIzin()
        {
            string sorgu = "select * from Izinler i inner join Personeller p on i.PersonelID = p.PersonelID";
            dgwIzinIslemleri.DataSource = _izinDal.GetAll(sorgu);
            dgwIzinIslemleri.Columns[0].HeaderText = "İzin No";
            dgwIzinIslemleri.Columns[1].HeaderText = "Personel No";
            dgwIzinIslemleri.Columns[2].HeaderText = "Adı";
            dgwIzinIslemleri.Columns[3].HeaderText = "Soyadı";
            dgwIzinIslemleri.Columns[4].HeaderText = "İzin Türü";
            dgwIzinIslemleri.Columns[5].HeaderText = "Açıklama";
            dgwIzinIslemleri.Columns[6].HeaderText = "Başlama Tarihi";
            dgwIzinIslemleri.Columns[7].HeaderText = "Bitiş Tarihi";
        }

        public void LoadDepartman()
        {
            string sorgu = "select * from Departmanlar";
            dgwDepartmanIslemleri.DataSource = _departmanDal.GetAll(sorgu);
            dgwDepartmanIslemleri.Columns[0].HeaderText = "Departman No";
            dgwDepartmanIslemleri.Columns[1].HeaderText = "Departman Adı";
        }

        public void LoadLog()
        {
            string sorgu = "select * from Logs";
            dgwLogIslemleri.DataSource = _logDal.GetAll(sorgu);
            dgwLogIslemleri.Columns[0].HeaderText = "Log No";
            dgwLogIslemleri.Columns[1].HeaderText = "Açıklama";
            dgwLogIslemleri.Columns[2].HeaderText = "Tarih";
        }

        //-------------------------------------------------------------------------------------------------
        //-----------------------------------------Form Load ve Closing
        //-------------------------------------------------------------------------------------------------
        private void MainMenu_Load(object sender, EventArgs e)
        {
            LoadPersonel();
            LoadIzin();
            LoadDepartman();
            LoadLog();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;

            cbox_sorgu.SelectedIndex = 0;
            cbxCinsiyeti.SelectedIndex = 0;

        }

        private void MainMenu_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }
        //-------------------------------------------------------------------------------------------------
        //-----------------------------------------Personeller
        //-------------------------------------------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(tbxSorgu.Text))
            {
                tbxSorgu.Focus();
                return;
            }

            if (cbox_sorgu.Text == "")
            {
                MessageBox.Show("Lütfen arama türünü seçiniz.");
            }

            if (cbox_sorgu.SelectedIndex == 0)
            {

                dgwPersonel.DataSource = _personelDal.GetSP("SP_ADSOYADAGORE", tbxSorgu.Text);

            }
            else if (cbox_sorgu.SelectedIndex == 1)
            {
                dgwPersonel.DataSource = _personelDal.GetSP("SP_DEPARTMANAGORE", tbxSorgu.Text);

            }
        }
        //-------------------------------------------------------------------------------------------------
        //-----------------------------------------Personel işlemleri
        //-------------------------------------------------------------------------------------------------
        private void btnTemizle_Click(object sender, EventArgs e)
        {
            tbxAdi.Text = "";
            tbxSoyadi.Text = "";
            tbxDepartmanID.Text = "";
            tbxMaasi.Text = "";
            tbxAraPersonel.Text = "";
            cbxCinsiyeti.SelectedIndex = 0;
            dtpBaslamaTarihi.Value = DateTime.Now;
            dtpBitisTarihi.Value = DateTime.Now;
        }

        private void btnYenilePersonel_Click(object sender, EventArgs e)
        {
            LoadPersonel();
        }

        private void btnAraPersonel_Click(object sender, EventArgs e)
        {
            dgwPersonelIslemleri.DataSource = _personelDal.GetSP("SP_ADSOYADAGORE", tbxAraPersonel.Text);
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                if (tbxDepartmanID.Text == "")
                {
                    MessageBox.Show("Lütfen departman no alanını doldurunuz.");
                    tbxDepartmanID.Focus();
                }
                else if (tbxAdi.Text == "")
                {
                    MessageBox.Show("Lütfen ad alanını doldurunuz.");
                    tbxAdi.Focus();
                }
                else if (tbxSoyadi.Text == "")
                {
                    MessageBox.Show("Lütfen soyad alanını doldurunuz.");
                    tbxSoyadi.Focus();
                }
                else if (tbxMaasi.Text == "")
                {
                    MessageBox.Show("Lütfen maaş alanını doldurunuz.");
                    tbxMaasi.Focus();
                }
                else if (cbxCinsiyeti.Text == "")
                {
                    MessageBox.Show("Lütfen cinsiyeti seçiniz.");
                    cbxCinsiyeti.Focus();
                }
                else
                {
                    _personelDal.Add
                    (
                    new Personel
                    {
                        departmanID = Convert.ToInt32(tbxDepartmanID.Text),
                        adi = tbxAdi.Text,
                        soyAdi = tbxSoyadi.Text,
                        cinsiyet = Convert.ToChar(cbxCinsiyeti.SelectedItem),
                        maas = Convert.ToDecimal(tbxMaasi.Text),
                        baslamaTarihi = dtpBaslamaTarihi.Value,
                        bitisTarihi = dtpBaslamaTarihi.Value
                    }
                    );
                    MessageBox.Show("Personel eklendi.");
                    LoadPersonel();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Geçersiz departman no girdiniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            
            
        }

        private void dgwPersonelIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxDepartmanID.Text = dgwPersonelIslemleri.CurrentRow.Cells[1].Value.ToString();
            tbxAdi.Text = dgwPersonelIslemleri.CurrentRow.Cells[3].Value.ToString();
            tbxSoyadi.Text = dgwPersonelIslemleri.CurrentRow.Cells[4].Value.ToString();
            cbxCinsiyeti.SelectedItem = dgwPersonelIslemleri.CurrentRow.Cells[5].Value.ToString();
            tbxMaasi.Text = dgwPersonelIslemleri.CurrentRow.Cells[6].Value.ToString();
            dtpBaslamaTarihi.Value = Convert.ToDateTime(dgwPersonelIslemleri.CurrentRow.Cells[7].Value);
            dtpBitisTarihi.Value = Convert.ToDateTime(dgwPersonelIslemleri.CurrentRow.Cells[8].Value);

        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgwPersonelIslemleri.CurrentRow.Cells[0].Value);
                if (tbxDepartmanID.Text == "")
                {
                    MessageBox.Show("Lütfen departman no alanını doldurunuz.");
                    tbxDepartmanID.Focus();
                }
                else if (tbxAdi.Text == "")
                {
                    MessageBox.Show("Lütfen ad alanını doldurunuz.");
                    tbxAdi.Focus();
                }
                else if (tbxSoyadi.Text == "")
                {
                    MessageBox.Show("Lütfen soyad alanını doldurunuz.");
                    tbxSoyadi.Focus();
                }
                else if (tbxMaasi.Text == "")
                {
                    MessageBox.Show("Lütfen maaş alanını doldurunuz.");
                    tbxMaasi.Focus();
                }
                else if (cbxCinsiyeti.Text == "")
                {
                    MessageBox.Show("Lütfen cinsiyeti seçiniz.");
                    cbxCinsiyeti.Focus();
                }
                else
                {
                    _personelDal.Update
                    (
                    new Personel
                    {
                        departmanID = Convert.ToInt32(tbxDepartmanID.Text),
                        adi = tbxAdi.Text,
                        soyAdi = tbxSoyadi.Text,
                        cinsiyet = Convert.ToChar(cbxCinsiyeti.SelectedItem),
                        maas = Convert.ToDecimal(tbxMaasi.Text),
                        baslamaTarihi = dtpBaslamaTarihi.Value,
                        bitisTarihi = dtpBitisTarihi.Value
                    }, id
                    );
                    MessageBox.Show("Personel güncellendi.");
                    LoadPersonel();
                    LoadLog();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Geçersiz departman no girdiniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            

        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwPersonelIslemleri.CurrentRow.Cells[0].Value);
            _personelDal.Delete(id);
            MessageBox.Show("Personel Silindi");
            LoadPersonel();
            LoadIzin();
            LoadLog();
        }

        private void tbxAdi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void tbxSoyadi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void tbxMaasi_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbxDepartmanID_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbxAraPersonel_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }


        //-------------------------------------------------------------------------------------------------
        //-----------------------------------------İzin işlemleri
        //-------------------------------------------------------------------------------------------------
        private void btnYenile_Click(object sender, EventArgs e)
        {
            LoadIzin();
        }

        private void btnAraIzin_Click(object sender, EventArgs e)
        {
            dgwIzinIslemleri.DataSource = _izinDal.GetSP("SP_IZINGETIR",tbxAraIzin.Text);
        }

        private void btnTemizleIzin_Click(object sender, EventArgs e)
        {
            tbxPersonelNoIzin.Text = "";
            tbxIzinTuru.Text = "";
            rtbxAciklamaIzin.Text = "";
            dtpBaslamaTarihiIzin.Value = DateTime.Now;
            dtpBitisTarihiIzin.Value = DateTime.Now;
        }
        
        private void btnEkleIzin_Click(object sender, EventArgs e)
        {

            try
            {
                if (tbxPersonelNoIzin.Text == "")
                {
                    MessageBox.Show("Lütfen personel no alanını doldurunuz.");
                    tbxPersonelNoIzin.Focus();
                }
                else if (tbxIzinTuru.Text == "")
                {
                    MessageBox.Show("Lütfen izin türü alanını doldurunuz.");
                    tbxIzinTuru.Focus();
                }
                else if (rtbxAciklamaIzin.Text == "")
                {
                    MessageBox.Show("Lütfen açıklama alanını doldurunuz.");
                    rtbxAciklamaIzin.Focus();
                }
                else
                {
                    _izinDal.Add
                    (
                    new Izin
                    {
                        personelID = Convert.ToInt32(tbxPersonelNoIzin.Text),
                        izinTur = tbxIzinTuru.Text,
                        aciklama = rtbxAciklamaIzin.Text,
                        baslamaTarihi = dtpBaslamaTarihiIzin.Value,
                        bitisTarihi = dtpBitisTarihiIzin.Value

                    }
                    );
                    MessageBox.Show("İzin eklendi.");
                    LoadIzin();
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Geçersiz departman no girdiniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void dgwIzinIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxPersonelNoIzin.Text = dgwIzinIslemleri.CurrentRow.Cells[1].Value.ToString();
            tbxIzinTuru.Text = dgwIzinIslemleri.CurrentRow.Cells[4].Value.ToString();
            dtpBaslamaTarihiIzin.Value = Convert.ToDateTime(dgwIzinIslemleri.CurrentRow.Cells[6].Value);
            dtpBitisTarihiIzin.Value = Convert.ToDateTime(dgwIzinIslemleri.CurrentRow.Cells[7].Value);
            rtbxAciklamaIzin.Text = dgwIzinIslemleri.CurrentRow.Cells[5].Value.ToString();
        }
        private void btnGuncelleIzin_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgwIzinIslemleri.CurrentRow.Cells[0].Value);
                if (tbxPersonelNoIzin.Text == "")
                {
                    MessageBox.Show("Lütfen personel no alanını doldurunuz.");
                    tbxPersonelNoIzin.Focus();
                }
                else if (tbxIzinTuru.Text == "")
                {
                    MessageBox.Show("Lütfen izin türü alanını doldurunuz.");
                    tbxIzinTuru.Focus();
                }
                else if (rtbxAciklamaIzin.Text == "")
                {
                    MessageBox.Show("Lütfen açıklama alanını doldurunuz.");
                    rtbxAciklamaIzin.Focus();
                }
                else
                {
                    _izinDal.Update
                    (
                    new Izin
                    {
                        personelID = Convert.ToInt32(tbxPersonelNoIzin.Text),
                        izinTur = tbxIzinTuru.Text,
                        aciklama = rtbxAciklamaIzin.Text,
                        baslamaTarihi = dtpBaslamaTarihiIzin.Value,
                        bitisTarihi = dtpBitisTarihiIzin.Value

                    }, id
                    );
                    MessageBox.Show("İzin güncellendi.");
                    LoadIzin();
                    LoadLog();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Geçersiz departman no girdiniz!", "Hata!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSilIzin_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwIzinIslemleri.CurrentRow.Cells[0].Value);
            _izinDal.Delete(id);
            MessageBox.Show("İzin silindi.");
            LoadIzin();
            LoadLog();

        }

        private void tbxAraIzin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void tbxPersonelNoIzin_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void tbxIzinTuru_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }


        //-------------------------------------------------------------------------------------------------
        //-----------------------------------------Departman işlemleri
        //-------------------------------------------------------------------------------------------------
        private void dgwDepartmanIslemleri_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            tbxDepartmanAdiDepartman.Text = dgwDepartmanIslemleri.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnAraDepartman_Click(object sender, EventArgs e)
        {
            dgwDepartmanIslemleri.DataSource = _departmanDal.GetSP("SP_DEPARTMANARA",tbxAraDepartman.Text);
        }

        private void btnYenileDepartman_Click(object sender, EventArgs e)
        {
            LoadDepartman();
        }

        private void btnTemizleDepartman_Click(object sender, EventArgs e)
        {
            tbxDepartmanAdiDepartman.Text = "";
        }

        private void btnEkleDepartman_Click(object sender, EventArgs e)
        {
            if (tbxDepartmanAdiDepartman.Text == "")
            {
                MessageBox.Show("Lütfen departman adı alanını doldurunuz.");
                tbxDepartmanAdiDepartman.Focus();
            }
            else
            {
                _departmanDal.Add
                (
                new Departman
                {
                    departmanAdi = tbxDepartmanAdiDepartman.Text,
                }
                );
                MessageBox.Show("Departman eklendi.");
                LoadDepartman();
            }
        }

        private void btnGuncelleDepartman_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwDepartmanIslemleri.CurrentRow.Cells[0].Value);
            if (tbxDepartmanAdiDepartman.Text == "")
            {
                MessageBox.Show("Lütfen departman adı alanını doldurunuz.");
                tbxDepartmanAdiDepartman.Focus();
            }
            else
            {
                _departmanDal.Update
                (
                new Departman
                {
                    departmanAdi = tbxDepartmanAdiDepartman.Text,
                }, id
                );
                MessageBox.Show("Departman güncellendi.");
                LoadDepartman();
                LoadPersonel();
                LoadLog();
            }
        }

        private void btnSilDepartman_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgwDepartmanIslemleri.CurrentRow.Cells[0].Value);
            _departmanDal.Delete(id);
            MessageBox.Show("Departman silindi.");
            LoadDepartman();
            LoadLog();
        }

        private void tbxAraDepartman_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }

        private void tbxDepartmanAdiDepartman_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsLetter(e.KeyChar) && !char.IsControl(e.KeyChar) && !char.IsSeparator(e.KeyChar);
        }


        //-------------------------------------------------------------------------------------------------
        //-----------------------------------------Log işlemleri
        //-------------------------------------------------------------------------------------------------
        private void btnYenileLog_Click(object sender, EventArgs e)
        {
            LoadLog();
        }

        private void btnAraLog_Click(object sender, EventArgs e)
        {
            dgwLogIslemleri.DataSource = _logDal.GetSP("SP_LOGARA", tbxAraLog.Text);
        }

        private void btnExcellAktar_Click(object sender, EventArgs e)
        {
            _excellAktar.ExcellAktarma(dgwLogIslemleri);
        }




        //-------------------------------------------------------------------------------------------------
        //-----------------------------------------Yedekleme işlemleri
        //-------------------------------------------------------------------------------------------------
        private void btnYolYedeklemeIslemleri_Click(object sender, EventArgs e)
        {
            sfdDosyaYolu.Title = "Yedeklenecek dosya yolunu belirtiniz.";
            sfdDosyaYolu.Filter = "Yedekleme Dosyaları(*.bak) |*.bak |Tüm Dosyalar(*.*) |*.*";
            if(sfdDosyaYolu.ShowDialog() == DialogResult.OK)
            {
                tbxDosyaYolu.Text = sfdDosyaYolu.FileName;
            }
        }

        private void btnYedekle_Click(object sender, EventArgs e)
        {
            try
            {
                Server dbServer = new Server(new ServerConnection("(localdb)\\MSSQLLocalDB"));
                Backup dbBackUp = new Backup();
                dbBackUp.Action = BackupActionType.Database;
                dbBackUp.Database = "PersonelTakip";
                dbBackUp.Devices.AddDevice(tbxDosyaYolu.Text, DeviceType.File);
                dbBackUp.Initialize = false;
                dbBackUp.Complete += DbBackUp_Complete;
                dbBackUp.SqlBackup(dbServer);
            }
            catch (Exception)
            {

                MessageBox.Show("Geçerli dosya yolu giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void DbBackUp_Complete(object sender, ServerMessageEventArgs e)
        {
            try
            {
                MessageBox.Show("Yedekleme işlemi başarılı bir şekilde gerçekleşti","Bilgi",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            catch (Exception)
            {

                MessageBox.Show("Yedek alma işlemi başarısız oldu.", "Hata",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
        }

        private void btnYedektenGeriYukle_Click(object sender, EventArgs e)
        {
            try
            {
                Server dbServer = new Server(new ServerConnection("(localdb)\\MSSQLLocalDB"));
                Restore dbRestore = new Restore();
                dbRestore.Action = RestoreActionType.Database;
                dbRestore.Database = "PersonelTakip";
                dbRestore.Devices.AddDevice(tbxDosyaYolu.Text, DeviceType.File);
                dbRestore.Complete += DbRestore_Complete;
                dbServer.KillAllProcesses("PersonelTakip");
                dbRestore.SqlRestore(dbServer);
            }
            catch (Exception)
            {

                MessageBox.Show("Geçerli dosya yolu giriniz!", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        private void DbRestore_Complete(object sender, ServerMessageEventArgs e)
        {
            try
            {
                MessageBox.Show("Yedekten geri yükleme işlemi başarılı bir şekilde gerçekleşti", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);
                LoadIzin();
                LoadLog();
                LoadPersonel();
                LoadDepartman();
            }
            catch (Exception)
            {

                MessageBox.Show("Yedekten geri dönme işlemi başarısız oldu.", "Hata", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}