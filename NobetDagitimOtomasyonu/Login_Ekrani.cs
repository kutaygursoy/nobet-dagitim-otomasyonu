using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NobetDagitimOtomasyonu
{
    public partial class Login_Ekrani : Form
    {

        //---------Sabitler-------//
        public static string ana_yol;
        public static string yetki;
        //--------Yardımcı fonksiyonlar-------//


        //--------------Butonlar-------------//
        private void girisBtn_Click(object sender, EventArgs e)
        {
            MD5Algo kripto = new MD5Algo();
            DataOps veri = new DataOps();
            DataTable giris = new DataTable();

            string login_yol = ana_yol + "login.csv";

            giris = veri.Csv2Dt(login_yol);

            string hash_ka = kripto.MD5cevirici(kullaniciAdi.Text+"ka_salt");
            string hash_pass = kripto.MD5cevirici(sifre.Text+"pass_salt");

            foreach (DataRow test in giris.Rows)
            {
                if ((Equals(hash_ka, test[0].ToString())) && (Equals(hash_pass, test[1].ToString())))
                {
                    yetki = test[2].ToString().Trim();

                    this.Hide();
                    var oturum = new Takvim_Ekrani();
                    oturum.Closed += (s, args) => this.Close();
                    oturum.Show();

                }
            }
                       
        }

        private void yeniKayitBtn_Click(object sender, EventArgs e)
        {
            this.Hide();
            var oturum = new YeniKayit_Ekrani();
            oturum.Closed += (s, args) => this.Close();
            oturum.Show();

        }


        //---------Ana Fonksiyonlar--------//

        public Login_Ekrani()
        {
            InitializeComponent();

            girisBtn.Enabled = false;

            ana_yol = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            ana_yol = ana_yol + "\\NobetMatik\\dosyalar\\";
            if (!Directory.Exists(ana_yol))
            {
                Directory.CreateDirectory(ana_yol);
            }

            if (File.Exists(ana_yol+"login.csv"))
            {
                girisBtn.Enabled = true;
            }
                        
        }
       
    }
}
