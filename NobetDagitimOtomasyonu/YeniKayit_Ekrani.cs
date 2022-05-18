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
    public partial class YeniKayit_Ekrani : Form
    {
        //---------Sabitler-------//
        string yetki;

        //--------Yardımcı fonksiyonlar-------//


        //-----------Radio Butonlar-----------//
        private void yetkiliRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            yetki = "1";
        }

        private void vekilRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            yetki = "2";
        }

        //--------------Butonlar-------------//
        private void kaydetBtn_Click(object sender, EventArgs e)
        {
            bool yetki_test = (vekilRdBtn.Checked || yetkiliRdBtn.Checked);

            bool sifre_test = (Equals(sifre1.Text, sifre2.Text)) && (!Equals(sifre1.Text, string.Empty));

            while (yetki_test && sifre_test)
            {
                sifre_test = !sifre_test;
                MD5Algo kripto = new MD5Algo();
                DataOps veri = new DataOps();
                string login_yol = Login_Ekrani.ana_yol + "login.csv";

                string hash_ka = kripto.MD5cevirici(kullaniciAdi.Text+"ka_salt");
                string hash_pass = kripto.MD5cevirici(sifre1.Text+"pass_salt");
                string icerik = hash_ka + "," + hash_pass + "," + yetki;

                veri.veriyaz(login_yol, icerik);

                MessageBox.Show("Kayıt Tamamlandı");


                this.Hide();
                var oturum = new Login_Ekrani();
                oturum.Closed += (s, args) => this.Close();
                oturum.Show();
            }
            
        }



        //---------Ana Fonksiyonlar--------//
        public YeniKayit_Ekrani()
        {
            InitializeComponent();


            string login_yol = Login_Ekrani.ana_yol + "login.csv";

            if (!File.Exists(login_yol))
            {
                DataOps veri = new DataOps();
                string icerik = "kullanıcı,şifre,yetki";
                veri.veriyaz(login_yol, icerik);
            }

        }
    }
}