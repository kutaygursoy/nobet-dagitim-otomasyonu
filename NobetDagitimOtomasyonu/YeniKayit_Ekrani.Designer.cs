
namespace NobetDagitimOtomasyonu
{
    partial class YeniKayit_Ekrani
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
            this.sifre1 = new System.Windows.Forms.TextBox();
            this.kullaniciAdi = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.kaydetBtn = new System.Windows.Forms.Button();
            this.sifre2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.yetkiliRdBtn = new System.Windows.Forms.RadioButton();
            this.vekilRdBtn = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // sifre1
            // 
            this.sifre1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sifre1.Location = new System.Drawing.Point(130, 55);
            this.sifre1.Name = "sifre1";
            this.sifre1.PasswordChar = '*';
            this.sifre1.Size = new System.Drawing.Size(302, 29);
            this.sifre1.TabIndex = 2;
            // 
            // kullaniciAdi
            // 
            this.kullaniciAdi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.kullaniciAdi.Location = new System.Drawing.Point(130, 18);
            this.kullaniciAdi.Name = "kullaniciAdi";
            this.kullaniciAdi.Size = new System.Drawing.Size(302, 29);
            this.kullaniciAdi.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(8, 55);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(113, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Şifre                :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Kullanıcı Adı :";
            // 
            // kaydetBtn
            // 
            this.kaydetBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kaydetBtn.Location = new System.Drawing.Point(316, 129);
            this.kaydetBtn.Name = "kaydetBtn";
            this.kaydetBtn.Size = new System.Drawing.Size(115, 31);
            this.kaydetBtn.TabIndex = 6;
            this.kaydetBtn.Text = "Kaydet";
            this.kaydetBtn.UseVisualStyleBackColor = true;
            this.kaydetBtn.Click += new System.EventHandler(this.kaydetBtn_Click);
            // 
            // sifre2
            // 
            this.sifre2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.sifre2.Location = new System.Drawing.Point(130, 92);
            this.sifre2.Name = "sifre2";
            this.sifre2.PasswordChar = '*';
            this.sifre2.Size = new System.Drawing.Size(302, 29);
            this.sifre2.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(8, 92);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(112, 21);
            this.label3.TabIndex = 9;
            this.label3.Text = "Şifre  Tekrar  :";
            // 
            // yetkiliRdBtn
            // 
            this.yetkiliRdBtn.AutoSize = true;
            this.yetkiliRdBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.yetkiliRdBtn.Location = new System.Drawing.Point(130, 129);
            this.yetkiliRdBtn.Name = "yetkiliRdBtn";
            this.yetkiliRdBtn.Size = new System.Drawing.Size(76, 25);
            this.yetkiliRdBtn.TabIndex = 4;
            this.yetkiliRdBtn.TabStop = true;
            this.yetkiliRdBtn.Text = "Yetkili";
            this.yetkiliRdBtn.UseVisualStyleBackColor = true;
            this.yetkiliRdBtn.CheckedChanged += new System.EventHandler(this.yetkiliRdBtn_CheckedChanged);
            // 
            // vekilRdBtn
            // 
            this.vekilRdBtn.AutoSize = true;
            this.vekilRdBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.vekilRdBtn.Location = new System.Drawing.Point(229, 129);
            this.vekilRdBtn.Name = "vekilRdBtn";
            this.vekilRdBtn.Size = new System.Drawing.Size(66, 25);
            this.vekilRdBtn.TabIndex = 5;
            this.vekilRdBtn.TabStop = true;
            this.vekilRdBtn.Text = "Vekil";
            this.vekilRdBtn.UseVisualStyleBackColor = true;
            this.vekilRdBtn.CheckedChanged += new System.EventHandler(this.vekilRdBtn_CheckedChanged);
            // 
            // YeniKayit_Ekrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(444, 171);
            this.Controls.Add(this.vekilRdBtn);
            this.Controls.Add(this.yetkiliRdBtn);
            this.Controls.Add(this.sifre2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.kaydetBtn);
            this.Controls.Add(this.sifre1);
            this.Controls.Add(this.kullaniciAdi);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "YeniKayit_Ekrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Yeni Kullanıcı Kaydı";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox sifre1;
        private System.Windows.Forms.TextBox kullaniciAdi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button kaydetBtn;
        private System.Windows.Forms.TextBox sifre2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.RadioButton yetkiliRdBtn;
        private System.Windows.Forms.RadioButton vekilRdBtn;
    }
}