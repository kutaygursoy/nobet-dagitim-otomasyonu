
namespace NobetDagitimOtomasyonu
{
    partial class Veri_Ekrani
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.personelTab = new System.Windows.Forms.TabPage();
            this.puantajTab = new System.Windows.Forms.TabPage();
            this.nobetciAdi = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.kaydetBtn = new System.Windows.Forms.Button();
            this.okuBtn = new System.Windows.Forms.Button();
            this.ekleBtn = new System.Windows.Forms.Button();
            this.personelDGV = new System.Windows.Forms.DataGridView();
            this.nobetciID = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.puantajDGV = new System.Windows.Forms.DataGridView();
            this.puantajOkuBtn = new System.Windows.Forms.Button();
            this.puanKaydetBtn = new System.Windows.Forms.Button();
            this.tabControl1.SuspendLayout();
            this.personelTab.SuspendLayout();
            this.puantajTab.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.personelDGV)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.puantajDGV)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.personelTab);
            this.tabControl1.Controls.Add(this.puantajTab);
            this.tabControl1.Location = new System.Drawing.Point(22, 22);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(1473, 670);
            this.tabControl1.TabIndex = 0;
            // 
            // personelTab
            // 
            this.personelTab.Controls.Add(this.nobetciID);
            this.personelTab.Controls.Add(this.label1);
            this.personelTab.Controls.Add(this.personelDGV);
            this.personelTab.Controls.Add(this.ekleBtn);
            this.personelTab.Controls.Add(this.okuBtn);
            this.personelTab.Controls.Add(this.kaydetBtn);
            this.personelTab.Controls.Add(this.nobetciAdi);
            this.personelTab.Controls.Add(this.label3);
            this.personelTab.Location = new System.Drawing.Point(4, 24);
            this.personelTab.Name = "personelTab";
            this.personelTab.Padding = new System.Windows.Forms.Padding(3);
            this.personelTab.Size = new System.Drawing.Size(1465, 642);
            this.personelTab.TabIndex = 0;
            this.personelTab.Text = "Personel Verisi";
            this.personelTab.UseVisualStyleBackColor = true;
            // 
            // puantajTab
            // 
            this.puantajTab.Controls.Add(this.puantajDGV);
            this.puantajTab.Controls.Add(this.puantajOkuBtn);
            this.puantajTab.Controls.Add(this.puanKaydetBtn);
            this.puantajTab.Location = new System.Drawing.Point(4, 24);
            this.puantajTab.Name = "puantajTab";
            this.puantajTab.Padding = new System.Windows.Forms.Padding(3);
            this.puantajTab.Size = new System.Drawing.Size(1465, 642);
            this.puantajTab.TabIndex = 1;
            this.puantajTab.Text = "Puantaj";
            this.puantajTab.UseVisualStyleBackColor = true;
            // 
            // nobetciAdi
            // 
            this.nobetciAdi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nobetciAdi.Location = new System.Drawing.Point(128, 57);
            this.nobetciAdi.Name = "nobetciAdi";
            this.nobetciAdi.Size = new System.Drawing.Size(302, 29);
            this.nobetciAdi.TabIndex = 8;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label3.Location = new System.Drawing.Point(13, 65);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(109, 21);
            this.label3.TabIndex = 7;
            this.label3.Text = "Nöbetçi Adı :";
            // 
            // kaydetBtn
            // 
            this.kaydetBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kaydetBtn.Location = new System.Drawing.Point(574, 65);
            this.kaydetBtn.Name = "kaydetBtn";
            this.kaydetBtn.Size = new System.Drawing.Size(188, 31);
            this.kaydetBtn.TabIndex = 9;
            this.kaydetBtn.Text = "Veritabanını Kaydet";
            this.kaydetBtn.UseVisualStyleBackColor = true;
            this.kaydetBtn.Click += new System.EventHandler(this.kaydetBtn_Click);
            // 
            // okuBtn
            // 
            this.okuBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.okuBtn.Location = new System.Drawing.Point(574, 20);
            this.okuBtn.Name = "okuBtn";
            this.okuBtn.Size = new System.Drawing.Size(188, 31);
            this.okuBtn.TabIndex = 10;
            this.okuBtn.Text = "Veritabanını Oku";
            this.okuBtn.UseVisualStyleBackColor = true;
            this.okuBtn.Click += new System.EventHandler(this.okuBtn_Click);
            // 
            // ekleBtn
            // 
            this.ekleBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.ekleBtn.Location = new System.Drawing.Point(315, 92);
            this.ekleBtn.Name = "ekleBtn";
            this.ekleBtn.Size = new System.Drawing.Size(115, 31);
            this.ekleBtn.TabIndex = 11;
            this.ekleBtn.Text = "Ekle";
            this.ekleBtn.UseVisualStyleBackColor = true;
            this.ekleBtn.Click += new System.EventHandler(this.ekleBtn_Click);
            // 
            // personelDGV
            // 
            this.personelDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.personelDGV.Location = new System.Drawing.Point(8, 159);
            this.personelDGV.Name = "personelDGV";
            this.personelDGV.RowTemplate.Height = 25;
            this.personelDGV.Size = new System.Drawing.Size(1422, 465);
            this.personelDGV.TabIndex = 12;
            // 
            // nobetciID
            // 
            this.nobetciID.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.nobetciID.Location = new System.Drawing.Point(128, 20);
            this.nobetciID.Name = "nobetciID";
            this.nobetciID.Size = new System.Drawing.Size(302, 29);
            this.nobetciID.TabIndex = 14;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(13, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 21);
            this.label1.TabIndex = 13;
            this.label1.Text = "Nöbetçi ID   :";
            // 
            // puantajDGV
            // 
            this.puantajDGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.puantajDGV.Location = new System.Drawing.Point(21, 158);
            this.puantajDGV.Name = "puantajDGV";
            this.puantajDGV.RowTemplate.Height = 25;
            this.puantajDGV.Size = new System.Drawing.Size(1422, 465);
            this.puantajDGV.TabIndex = 15;
            // 
            // puantajOkuBtn
            // 
            this.puantajOkuBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.puantajOkuBtn.Location = new System.Drawing.Point(587, 19);
            this.puantajOkuBtn.Name = "puantajOkuBtn";
            this.puantajOkuBtn.Size = new System.Drawing.Size(188, 31);
            this.puantajOkuBtn.TabIndex = 14;
            this.puantajOkuBtn.Text = "Puanları Oku";
            this.puantajOkuBtn.UseVisualStyleBackColor = true;
            this.puantajOkuBtn.Click += new System.EventHandler(this.puantajOkuBtn_Click);
            // 
            // puanKaydetBtn
            // 
            this.puanKaydetBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.puanKaydetBtn.Location = new System.Drawing.Point(587, 64);
            this.puanKaydetBtn.Name = "puanKaydetBtn";
            this.puanKaydetBtn.Size = new System.Drawing.Size(188, 31);
            this.puanKaydetBtn.TabIndex = 13;
            this.puanKaydetBtn.Text = "Puanları Kaydet";
            this.puanKaydetBtn.UseVisualStyleBackColor = true;
            this.puanKaydetBtn.Click += new System.EventHandler(this.puanKaydetBtn_Click);
            // 
            // Veri_Ekrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1520, 703);
            this.Controls.Add(this.tabControl1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Veri_Ekrani";
            this.Text = "Veri İşlemleri";
            this.tabControl1.ResumeLayout(false);
            this.personelTab.ResumeLayout(false);
            this.personelTab.PerformLayout();
            this.puantajTab.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.personelDGV)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.puantajDGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage personelTab;
        private System.Windows.Forms.TabPage puantajTab;
        private System.Windows.Forms.TextBox nobetciAdi;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button ekleBtn;
        private System.Windows.Forms.Button okuBtn;
        private System.Windows.Forms.Button kaydetBtn;
        private System.Windows.Forms.DataGridView personelDGV;
        private System.Windows.Forms.TextBox nobetciID;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView puantajDGV;
        private System.Windows.Forms.Button puantajOkuBtn;
        private System.Windows.Forms.Button puanKaydetBtn;
    }
}