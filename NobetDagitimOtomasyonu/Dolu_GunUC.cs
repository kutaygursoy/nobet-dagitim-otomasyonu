using System;
using System.Windows.Forms;

namespace NobetDagitimOtomasyonu
{
    public partial class Dolu_GunUC : UserControl
    {
        //---------Sabitler-------//
        public static string statik_gun;
        public static string nobetci_id;


        //---------Yardımcı Fonksiyonlar--------//
        public void gunler(int sayi, string nobetci, string nobetci_id)
        {
            label1.Text = sayi + "";
            nobetciAdiLbl.Text = nobetci;
            nobetciIDLbl.Text = nobetci_id;
        }

        private void Dolu_GunUC_Click(object sender, EventArgs e)
        {
            statik_gun = label1.Text;
            nobetci_id = nobetciIDLbl.Text;
            Mazeret_Ekrani mazeret = new Mazeret_Ekrani();
            mazeret.Show();

        }



        //---------Ana Fonksiyonlar--------//
        public Dolu_GunUC()
        {
            InitializeComponent();
        }

        private void Dolu_GunUC_Load(object sender, EventArgs e)
        {

        }
    }
}
