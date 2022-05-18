using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace NobetDagitimOtomasyonu
{
    public partial class Veri_Ekrani : Form
    {
        //---------Sabitler-------//
        public string ana_yol;



        //------ Personel Tab Butonlar ----//
        private void okuBtn_Click(object sender, EventArgs e)
        {
            DataOps get_veri = new DataOps();
            string yol = ana_yol + "personel.csv";
            personelDGV.DataSource = get_veri.Csv2Dt(yol);
        }

        private void kaydetBtn_Click(object sender, EventArgs e)
        {
            DataOps get_veri = new DataOps();
            string yol = ana_yol + "personel.csv";

            get_veri.Dgv2Csv(personelDGV, yol);
        }

        private void ekleBtn_Click(object sender, EventArgs e)
        {
            DataOps get_veri = new DataOps();
            DataTable yeni_dt = new DataTable();
            string yol = ana_yol + "personel.csv";
            yeni_dt = get_veri.Csv2Dt(yol);
            DataRow dr = null;
            dr = yeni_dt.NewRow();
            dr[0] = nobetciID.Text;
            dr[1] = nobetciAdi.Text;
            for (int i = 2; i < dr.Table.Columns.Count; i++)
            {
                dr[i] = "0";
            }
            yeni_dt.Rows.Add(dr);

            personelDGV.DataSource = yeni_dt;
            get_veri.Dgv2Csv(personelDGV, yol);
        }


        //------Puantaj Tab Butonlar ----//


        private void puantajOkuBtn_Click(object sender, EventArgs e)
        {
            DataOps get_veri = new DataOps();
            string yol = ana_yol + "puan.csv";
            puantajDGV.DataSource = get_veri.Csv2Dt(yol);
        }

        private void puanKaydetBtn_Click(object sender, EventArgs e)
        {
            DataOps get_veri = new DataOps();
            string yol = ana_yol + "puan.csv";

            get_veri.Dgv2Csv(puantajDGV, yol);
        }

        //---------Ana Fonksiyonlar--------//
        public Veri_Ekrani()
        {
            InitializeComponent();

            ana_yol = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            ana_yol = ana_yol + "\\NobetMatik\\dosyalar\\";
            if (!Directory.Exists(ana_yol))
            {
                Directory.CreateDirectory(ana_yol);
            }

        }

    }
}
