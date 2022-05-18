
namespace NobetDagitimOtomasyonu
{
    partial class OncekiAy_Ekrani
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
            this.kayitBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.ikiOnceCBox = new System.Windows.Forms.ComboBox();
            this.birOnceCBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // kayitBtn
            // 
            this.kayitBtn.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.kayitBtn.Location = new System.Drawing.Point(317, 85);
            this.kayitBtn.Name = "kayitBtn";
            this.kayitBtn.Size = new System.Drawing.Size(115, 31);
            this.kayitBtn.TabIndex = 6;
            this.kayitBtn.Text = "Kaydet";
            this.kayitBtn.UseVisualStyleBackColor = true;
            this.kayitBtn.Click += new System.EventHandler(this.kayitBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label2.Location = new System.Drawing.Point(8, 53);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(161, 21);
            this.label2.TabIndex = 5;
            this.label2.Text = "Bir Önceki Nöbetçi :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(8, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(159, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "İki Önceki Nöbetçi :";
            // 
            // ikiOnceCBox
            // 
            this.ikiOnceCBox.FormattingEnabled = true;
            this.ikiOnceCBox.Location = new System.Drawing.Point(179, 12);
            this.ikiOnceCBox.Name = "ikiOnceCBox";
            this.ikiOnceCBox.Size = new System.Drawing.Size(252, 23);
            this.ikiOnceCBox.TabIndex = 7;
            // 
            // birOnceCBox
            // 
            this.birOnceCBox.FormattingEnabled = true;
            this.birOnceCBox.Location = new System.Drawing.Point(179, 55);
            this.birOnceCBox.Name = "birOnceCBox";
            this.birOnceCBox.Size = new System.Drawing.Size(252, 23);
            this.birOnceCBox.TabIndex = 8;
            // 
            // OncekiAy_Ekrani
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(457, 192);
            this.Controls.Add(this.birOnceCBox);
            this.Controls.Add(this.ikiOnceCBox);
            this.Controls.Add(this.kayitBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "OncekiAy_Ekrani";
            this.Text = "Nöbetçi Girişi";
            this.Load += new System.EventHandler(this.OncekiAy_Ekrani_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button kayitBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox ikiOnceCBox;
        private System.Windows.Forms.ComboBox birOnceCBox;
    }
}