namespace PersonelTakip
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.tbxKullaniciAdi = new System.Windows.Forms.TextBox();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.lblParola = new System.Windows.Forms.Label();
            this.tbxParola = new System.Windows.Forms.TextBox();
            this.btn_giris = new System.Windows.Forms.Button();
            this.lbl_sifremiUnuttum = new System.Windows.Forms.LinkLabel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            this.splitContainer1.Size = new System.Drawing.Size(150, 100);
            this.splitContainer1.TabIndex = 0;
            // 
            // tbxKullaniciAdi
            // 
            this.tbxKullaniciAdi.Location = new System.Drawing.Point(91, 70);
            this.tbxKullaniciAdi.Name = "tbxKullaniciAdi";
            this.tbxKullaniciAdi.Size = new System.Drawing.Size(245, 23);
            this.tbxKullaniciAdi.TabIndex = 0;
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.BackColor = System.Drawing.Color.Transparent;
            this.lblKullaniciAdi.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblKullaniciAdi.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(91, 47);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(102, 20);
            this.lblKullaniciAdi.TabIndex = 1;
            this.lblKullaniciAdi.Text = "Kullanıcı Adı :";
            // 
            // lblParola
            // 
            this.lblParola.AutoSize = true;
            this.lblParola.BackColor = System.Drawing.Color.Transparent;
            this.lblParola.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblParola.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lblParola.Location = new System.Drawing.Point(91, 122);
            this.lblParola.Name = "lblParola";
            this.lblParola.Size = new System.Drawing.Size(61, 20);
            this.lblParola.TabIndex = 3;
            this.lblParola.Text = "Parola :";
            // 
            // tbxParola
            // 
            this.tbxParola.Location = new System.Drawing.Point(91, 145);
            this.tbxParola.Name = "tbxParola";
            this.tbxParola.PasswordChar = '*';
            this.tbxParola.Size = new System.Drawing.Size(245, 23);
            this.tbxParola.TabIndex = 2;
            // 
            // btn_giris
            // 
            this.btn_giris.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btn_giris.BackgroundImage")));
            this.btn_giris.Location = new System.Drawing.Point(242, 178);
            this.btn_giris.Name = "btn_giris";
            this.btn_giris.Size = new System.Drawing.Size(94, 44);
            this.btn_giris.TabIndex = 4;
            this.btn_giris.Text = "Giriş";
            this.btn_giris.UseVisualStyleBackColor = true;
            this.btn_giris.Click += new System.EventHandler(this.btn_giris_Click);
            // 
            // lbl_sifremiUnuttum
            // 
            this.lbl_sifremiUnuttum.AutoSize = true;
            this.lbl_sifremiUnuttum.BackColor = System.Drawing.Color.Transparent;
            this.lbl_sifremiUnuttum.Cursor = System.Windows.Forms.Cursors.Hand;
            this.lbl_sifremiUnuttum.Font = new System.Drawing.Font("Segoe UI Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point);
            this.lbl_sifremiUnuttum.LinkColor = System.Drawing.Color.GreenYellow;
            this.lbl_sifremiUnuttum.Location = new System.Drawing.Point(91, 188);
            this.lbl_sifremiUnuttum.Name = "lbl_sifremiUnuttum";
            this.lbl_sifremiUnuttum.Size = new System.Drawing.Size(129, 21);
            this.lbl_sifremiUnuttum.TabIndex = 5;
            this.lbl_sifremiUnuttum.TabStop = true;
            this.lbl_sifremiUnuttum.Text = "Şifremi Unuttum";
            this.lbl_sifremiUnuttum.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lbl_sifremiUnuttum_LinkClicked);
            // 
            // Login
            // 
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(424, 281);
            this.Controls.Add(this.lbl_sifremiUnuttum);
            this.Controls.Add(this.btn_giris);
            this.Controls.Add(this.lblParola);
            this.Controls.Add(this.tbxParola);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.tbxKullaniciAdi);
            this.MaximizeBox = false;
            this.Name = "Login";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Personel Takip";
            this.Load += new System.EventHandler(this.Login_Load);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private SplitContainer splitContainer1;
        private TextBox tbxKullaniciAdi;
        private Label lblKullaniciAdi;
        private Label lblParola;
        private TextBox tbxParola;
        private Button btn_giris;
        private LinkLabel lbl_sifremiUnuttum;
    }
}