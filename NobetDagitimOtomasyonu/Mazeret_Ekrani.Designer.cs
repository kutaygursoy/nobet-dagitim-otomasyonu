
namespace NobetDagitimOtomasyonu
{
    partial class Mazeret_Ekrani
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.mazeretKayitBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.mazeretSilBtn = new System.Windows.Forms.Button();
            this.ikameNobBtn = new System.Windows.Forms.Button();
            this.normalRdBtn = new System.Windows.Forms.RadioButton();
            this.resmiTatilRdBtn = new System.Windows.Forms.RadioButton();
            this.diniTatilRdBtn = new System.Windows.Forms.RadioButton();
            this.idariTatilRdBtn = new System.Windows.Forms.RadioButton();
            this.gizliBox = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(22, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(193, 21);
            this.label1.TabIndex = 1;
            this.label1.Text = "Mazeretli Personeli Seçiniz";
            // 
            // comboBox1
            // 
            this.comboBox1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(22, 58);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(254, 23);
            this.comboBox1.TabIndex = 2;
            // 
            // mazeretKayitBtn
            // 
            this.mazeretKayitBtn.Location = new System.Drawing.Point(283, 53);
            this.mazeretKayitBtn.Name = "mazeretKayitBtn";
            this.mazeretKayitBtn.Size = new System.Drawing.Size(135, 30);
            this.mazeretKayitBtn.TabIndex = 3;
            this.mazeretKayitBtn.Text = "Mazeret Kaydet";
            this.mazeretKayitBtn.UseVisualStyleBackColor = true;
            this.mazeretKayitBtn.Click += new System.EventHandler(this.mazeretKayitBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(22, 99);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(137, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Mazeretli Personel";
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 15;
            this.listBox1.Location = new System.Drawing.Point(22, 127);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(254, 139);
            this.listBox1.TabIndex = 5;
            // 
            // mazeretSilBtn
            // 
            this.mazeretSilBtn.Location = new System.Drawing.Point(283, 127);
            this.mazeretSilBtn.Name = "mazeretSilBtn";
            this.mazeretSilBtn.Size = new System.Drawing.Size(135, 30);
            this.mazeretSilBtn.TabIndex = 6;
            this.mazeretSilBtn.Text = "Mazeret Sil";
            this.mazeretSilBtn.UseVisualStyleBackColor = true;
            this.mazeretSilBtn.Click += new System.EventHandler(this.mazeretSilBtn_Click);
            // 
            // ikameNobBtn
            // 
            this.ikameNobBtn.Location = new System.Drawing.Point(282, 236);
            this.ikameNobBtn.Name = "ikameNobBtn";
            this.ikameNobBtn.Size = new System.Drawing.Size(135, 30);
            this.ikameNobBtn.TabIndex = 7;
            this.ikameNobBtn.Text = "İkame Nöbetçi";
            this.ikameNobBtn.UseVisualStyleBackColor = true;
            this.ikameNobBtn.Click += new System.EventHandler(this.ikameNobBtn_Click);
            // 
            // normalRdBtn
            // 
            this.normalRdBtn.AutoSize = true;
            this.normalRdBtn.Location = new System.Drawing.Point(22, 286);
            this.normalRdBtn.Name = "normalRdBtn";
            this.normalRdBtn.Size = new System.Drawing.Size(90, 19);
            this.normalRdBtn.TabIndex = 8;
            this.normalRdBtn.TabStop = true;
            this.normalRdBtn.Text = "Normal Gün";
            this.normalRdBtn.UseVisualStyleBackColor = true;
            this.normalRdBtn.CheckedChanged += new System.EventHandler(this.normalRdBtn_CheckedChanged);
            // 
            // resmiTatilRdBtn
            // 
            this.resmiTatilRdBtn.AutoSize = true;
            this.resmiTatilRdBtn.Location = new System.Drawing.Point(22, 311);
            this.resmiTatilRdBtn.Name = "resmiTatilRdBtn";
            this.resmiTatilRdBtn.Size = new System.Drawing.Size(81, 19);
            this.resmiTatilRdBtn.TabIndex = 9;
            this.resmiTatilRdBtn.TabStop = true;
            this.resmiTatilRdBtn.Text = "Resmi Tatil";
            this.resmiTatilRdBtn.UseVisualStyleBackColor = true;
            this.resmiTatilRdBtn.CheckedChanged += new System.EventHandler(this.resmiTatilRdBtn_CheckedChanged);
            // 
            // diniTatilRdBtn
            // 
            this.diniTatilRdBtn.AutoSize = true;
            this.diniTatilRdBtn.Location = new System.Drawing.Point(22, 336);
            this.diniTatilRdBtn.Name = "diniTatilRdBtn";
            this.diniTatilRdBtn.Size = new System.Drawing.Size(70, 19);
            this.diniTatilRdBtn.TabIndex = 10;
            this.diniTatilRdBtn.TabStop = true;
            this.diniTatilRdBtn.Text = "Dini Tatil";
            this.diniTatilRdBtn.UseVisualStyleBackColor = true;
            this.diniTatilRdBtn.CheckedChanged += new System.EventHandler(this.diniTatilRdBtn_CheckedChanged);
            // 
            // idariTatilRdBtn
            // 
            this.idariTatilRdBtn.AutoSize = true;
            this.idariTatilRdBtn.Location = new System.Drawing.Point(22, 361);
            this.idariTatilRdBtn.Name = "idariTatilRdBtn";
            this.idariTatilRdBtn.Size = new System.Drawing.Size(72, 19);
            this.idariTatilRdBtn.TabIndex = 11;
            this.idariTatilRdBtn.TabStop = true;
            this.idariTatilRdBtn.Text = "İdari Tatil";
            this.idariTatilRdBtn.UseVisualStyleBackColor = true;
            this.idariTatilRdBtn.CheckedChanged += new System.EventHandler(this.idariTatilRdBtn_CheckedChanged);
            // 
            // gizliBox
            // 
            this.gizliBox.FormattingEnabled = true;
            this.gizliBox.ItemHeight = 15;
            this.gizliBox.Location = new System.Drawing.Point(297, 361);
            this.gizliBox.Name = "gizliBox";
            this.gizliBox.Size = new System.Drawing.Size(120, 19);
            this.gizliBox.TabIndex = 12;
            this.gizliBox.Visible = false;
            // 
            // Mazeret_Ekrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(429, 387);
            this.Controls.Add(this.gizliBox);
            this.Controls.Add(this.idariTatilRdBtn);
            this.Controls.Add(this.diniTatilRdBtn);
            this.Controls.Add(this.resmiTatilRdBtn);
            this.Controls.Add(this.normalRdBtn);
            this.Controls.Add(this.ikameNobBtn);
            this.Controls.Add(this.mazeretSilBtn);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.mazeretKayitBtn);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "Mazeret_Ekrani";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Mazeret / Özel Gün / İkame";
            this.Load += new System.EventHandler(this.Mazeret_Ekrani_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button mazeretKayitBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button mazeretSilBtn;
        private System.Windows.Forms.Button ikameNobBtn;
        private System.Windows.Forms.RadioButton normalRdBtn;
        private System.Windows.Forms.RadioButton resmiTatilRdBtn;
        private System.Windows.Forms.RadioButton diniTatilRdBtn;
        private System.Windows.Forms.RadioButton idariTatilRdBtn;
        private System.Windows.Forms.ListBox gizliBox;
    }
}