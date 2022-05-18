
namespace NobetDagitimOtomasyonu
{
    partial class Dolu_GunUC
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.nobetciAdiLbl = new System.Windows.Forms.Label();
            this.nobetciIDLbl = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.label1.Location = new System.Drawing.Point(4, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            // 
            // nobetciAdiLbl
            // 
            this.nobetciAdiLbl.AutoSize = true;
            this.nobetciAdiLbl.Font = new System.Drawing.Font("Lucida Bright", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.nobetciAdiLbl.Location = new System.Drawing.Point(4, 40);
            this.nobetciAdiLbl.Name = "nobetciAdiLbl";
            this.nobetciAdiLbl.Size = new System.Drawing.Size(63, 20);
            this.nobetciAdiLbl.TabIndex = 1;
            this.nobetciAdiLbl.Text = "label2";
            // 
            // nobetciIDLbl
            // 
            this.nobetciIDLbl.AutoSize = true;
            this.nobetciIDLbl.Location = new System.Drawing.Point(159, 82);
            this.nobetciIDLbl.Name = "nobetciIDLbl";
            this.nobetciIDLbl.Size = new System.Drawing.Size(38, 15);
            this.nobetciIDLbl.TabIndex = 2;
            this.nobetciIDLbl.Text = "label2";
            this.nobetciIDLbl.Visible = false;
            // 
            // Dolu_GunUC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.nobetciIDLbl);
            this.Controls.Add(this.nobetciAdiLbl);
            this.Controls.Add(this.label1);
            this.Name = "Dolu_GunUC";
            this.Size = new System.Drawing.Size(200, 100);
            this.Load += new System.EventHandler(this.Dolu_GunUC_Load);
            this.Click += new System.EventHandler(this.Dolu_GunUC_Click);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label nobetciAdiLbl;
        private System.Windows.Forms.Label nobetciIDLbl;
    }
}
