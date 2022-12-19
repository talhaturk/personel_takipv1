namespace PersonelTakip
{
    partial class ForgetPW
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
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
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ForgetPW));
            this.lblGizliSoru = new System.Windows.Forms.Label();
            this.tbxGizliSoruCevap = new System.Windows.Forms.TextBox();
            this.lblKullaniciAdi = new System.Windows.Forms.Label();
            this.btnOK = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblGizliSoru
            // 
            this.lblGizliSoru.AutoSize = true;
            this.lblGizliSoru.BackColor = System.Drawing.Color.Transparent;
            this.lblGizliSoru.Font = new System.Drawing.Font("Segoe UI Semibold", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblGizliSoru.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lblGizliSoru.Location = new System.Drawing.Point(110, 100);
            this.lblGizliSoru.Name = "lblGizliSoru";
            this.lblGizliSoru.Size = new System.Drawing.Size(74, 20);
            this.lblGizliSoru.TabIndex = 0;
            this.lblGizliSoru.Text = "Gizli Soru";
            // 
            // tbxGizliSoruCevap
            // 
            this.tbxGizliSoruCevap.Location = new System.Drawing.Point(110, 123);
            this.tbxGizliSoruCevap.Name = "tbxGizliSoruCevap";
            this.tbxGizliSoruCevap.Size = new System.Drawing.Size(192, 23);
            this.tbxGizliSoruCevap.TabIndex = 1;
            // 
            // lblKullaniciAdi
            // 
            this.lblKullaniciAdi.AutoSize = true;
            this.lblKullaniciAdi.BackColor = System.Drawing.Color.Transparent;
            this.lblKullaniciAdi.ForeColor = System.Drawing.Color.LavenderBlush;
            this.lblKullaniciAdi.Location = new System.Drawing.Point(337, 254);
            this.lblKullaniciAdi.Name = "lblKullaniciAdi";
            this.lblKullaniciAdi.Size = new System.Drawing.Size(38, 15);
            this.lblKullaniciAdi.TabIndex = 2;
            this.lblKullaniciAdi.Text = "label1";
            this.lblKullaniciAdi.Visible = false;
            // 
            // btnOK
            // 
            this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
            this.btnOK.Location = new System.Drawing.Point(227, 152);
            this.btnOK.Name = "btnOK";
            this.btnOK.Size = new System.Drawing.Size(75, 28);
            this.btnOK.TabIndex = 3;
            this.btnOK.Text = "OK";
            this.btnOK.UseVisualStyleBackColor = true;
            this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
            // 
            // ForgetPW
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.ClientSize = new System.Drawing.Size(424, 281);
            this.Controls.Add(this.btnOK);
            this.Controls.Add(this.lblKullaniciAdi);
            this.Controls.Add(this.tbxGizliSoruCevap);
            this.Controls.Add(this.lblGizliSoru);
            this.MaximizeBox = false;
            this.Name = "ForgetPW";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Personel Takip";
            this.Load += new System.EventHandler(this.ForgetPW_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label lblGizliSoru;
        private TextBox tbxGizliSoruCevap;
        public Label lblKullaniciAdi;
        private Button btnOK;
    }
}