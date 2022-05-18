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
    public partial class OncekiAy_Ekrani : Form
    {
        public static string ana_yol = Takvim_Ekrani.ana_yol;
        public static int yil, ay;


        //--------------Butonlar-------------//

        private void kayitBtn_Click(object sender, EventArgs e)
        {
            bool flag = (birOnceCBox.SelectedIndex >= 0) && (ikiOnceCBox.SelectedIndex > 0) && (birOnceCBox.SelectedIndex != ikiOnceCBox.SelectedIndex);

            while (flag)
            {

                DateTime secili_zaman = new DateTime(yil, ay, 1);

                int toplam_gun = DateTime.DaysInMonth(yil, ay);
                string iki_onceki_gun = yil.ToString() + ay.ToString().PadLeft(2, '0') + (toplam_gun - 1).ToString().PadLeft(2, '0');
                string bir_onceki_gun = yil.ToString() + ay.ToString().PadLeft(2, '0') + toplam_gun.ToString().PadLeft(2, '0');


                DataOps veri = new DataOps();

                string icerik_2 = iki_onceki_gun + ",0,0," + ikiOnceCBox.SelectedItem.ToString() + "," + (ikiOnceCBox.SelectedIndex + 1).ToString();
                string icerik_1 = bir_onceki_gun + ",0,0," + birOnceCBox.SelectedItem.ToString() + "," + (birOnceCBox.SelectedIndex + 1).ToString();

                string nobet_yol = ana_yol + yil.ToString() + ay.ToString() + "_nobet.csv";

                veri.veriyaz(nobet_yol, icerik_2);
                veri.veriyaz(nobet_yol, icerik_1);

                flag = false;

            }

        }


        //---------Ana Fonksiyonlar--------//
        public OncekiAy_Ekrani()
        {
            InitializeComponent();

            string nobet_yol = ana_yol + yil.ToString() + ay.ToString() + "_nobet.csv";
            File.Create(nobet_yol).Dispose();

            DataOps veri = new DataOps();
            string icerik_nobet = "Gun,Puan,Mazeretli,Nöbetçi,Nöb_Id";
            veri.veriyaz(nobet_yol, icerik_nobet);

        }

        private void OncekiAy_Ekrani_Load(object sender, EventArgs e)
        {
            DataOps veri = new DataOps();

            DataTable personel = new DataTable();
            string personel_yol = ana_yol + "personel.csv";
            personel = veri.Csv2Dt(personel_yol);

            DataTable clone = new DataTable();
            clone.Columns.Add("ID", typeof(int));
            clone.Load(personel.CreateDataReader(), LoadOption.OverwriteChanges);

            clone.DefaultView.Sort = "ID";
            clone = clone.DefaultView.ToTable();
            veri.Dt2Csv(clone, personel_yol);

            foreach (DataRow satir in clone.Rows)
            {
                ikiOnceCBox.Items.Add(satir[1]);
                birOnceCBox.Items.Add(satir[1]);
            }

        }

        
    }
}
