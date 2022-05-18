using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NobetDagitimOtomasyonu
{
    public partial class Mazeret_Ekrani : Form
    {
        
        //---------Sabitler-------//
        
        public string secili_tarih = Takvim_Ekrani.static_yil + Takvim_Ekrani.static_ay.PadLeft(2, '0') + Dolu_GunUC.statik_gun.PadLeft(2, '0');
        public string ana_yol = Takvim_Ekrani.ana_yol;


        //--------Yardımcı fonksiyonlar-------//
        private void mazeret_temizle()
        {
            DataOps veri = new DataOps();
            DataTable mazeretliler = new DataTable();
            string mazeret_yol = ana_yol + Takvim_Ekrani.static_yil + Takvim_Ekrani.static_ay.PadLeft(2, '0') + "_mazeret.csv";

            mazeretliler = veri.Csv2Dt(mazeret_yol);

            DataTable temizlenmis_tablo = mazeretliler.DefaultView.ToTable(true, "Tarih", "Kisi", "Mazeret");

            veri.Dt2Csv(temizlenmis_tablo, mazeret_yol);
        }

        private void listbox_guncelle()
        {
            listBox1.Items.Clear();
            gizliBox.Items.Clear();

            DataOps veri = new DataOps();
            DataTable personel = new DataTable();
            string personel_yol = ana_yol + "personel.csv";
            personel = veri.Csv2Dt(personel_yol);

            DataTable mazeretliler = new DataTable();
            string mazeret_yol = ana_yol + Takvim_Ekrani.static_yil + Takvim_Ekrani.static_ay.PadLeft(2, '0') + "_mazeret.csv";
            mazeretliler = veri.Csv2Dt(mazeret_yol);

            DataTable clone = new DataTable();
            clone.Columns.Add("Tarih", typeof(int));
            clone.Load(mazeretliler.CreateDataReader(), LoadOption.OverwriteChanges);

            clone.DefaultView.Sort = "Tarih";
            clone.DefaultView.ToTable();


            DataRow[] mazeretli_kisi = clone.Select("Tarih = '" + secili_tarih + "'");
            foreach (DataRow sira in mazeretli_kisi)
            {
                if (!Equals(sira[1].ToString(), "puan"))        //özel gün + mazeretliden kaçış
                {
                    int id = Int32.Parse(sira[1].ToString());
                    id += 1;
                    DataRow[] isim = personel.Select("ID = '" + id + "'");
                    foreach (DataRow sira_prsnl in isim)
                    {
                        gizliBox.Items.Add(sira_prsnl[0]);
                        listBox1.Items.Add(sira_prsnl[1].ToString());

                    }

                }

            }
        }


        //------------Radio Butonlar-----------//
        private void normalRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            string secili_ay = Takvim_Ekrani.static_yil + Takvim_Ekrani.static_ay.PadLeft(2, '0');
            string mazeret_yol = ana_yol + secili_ay + "_mazeret.csv";

            DataOps veri = new DataOps();

            DataTable gün_dt = new DataTable();
            gün_dt = veri.Csv2Dt(mazeret_yol);

            string icerik = "Tarih = '" + secili_tarih + "' AND Kisi = 'puan'";

            DataRow[] silinecek = gün_dt.Select(icerik);
            foreach (DataRow sil in silinecek)
            {
                gün_dt.Rows.Remove(sil);
            }
            veri.Dt2Csv(gün_dt, mazeret_yol);

            mazeret_temizle();
        }

        private void resmiTatilRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            normalRdBtn_CheckedChanged(sender, e);
            //puan.csv -7-
            string secili_ay = Takvim_Ekrani.static_yil + Takvim_Ekrani.static_ay.PadLeft(2, '0');
            string yol = ana_yol + secili_ay + "_mazeret.csv";

            DataOps veri = new DataOps();
            string icerik = secili_tarih + "," + "puan" + ",7";
            veri.veriyaz(yol, icerik);
            mazeret_temizle();

        }

        private void diniTatilRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            normalRdBtn_CheckedChanged(sender, e);
            //puan.csv -8-
            string secili_ay = Takvim_Ekrani.static_yil + Takvim_Ekrani.static_ay.PadLeft(2, '0');
            string yol = ana_yol + secili_ay + "_mazeret.csv";

            DataOps veri = new DataOps();
            string icerik = secili_tarih + "," + "puan" + ",8";
            veri.veriyaz(yol, icerik);
            mazeret_temizle();
        }

        private void idariTatilRdBtn_CheckedChanged(object sender, EventArgs e)
        {
            normalRdBtn_CheckedChanged(sender, e);
            //puan.csv -9-
            string secili_ay = Takvim_Ekrani.static_yil + Takvim_Ekrani.static_ay.PadLeft(2, '0');
            string yol = ana_yol + secili_ay + "_mazeret.csv";

            DataOps veri = new DataOps();
            string icerik = secili_tarih + "," + "puan" + ",9";
            veri.veriyaz(yol, icerik);
            mazeret_temizle();
        }

        //--------------Butonlar-------------//

        private void mazeretKayitBtn_Click(object sender, EventArgs e)
        {
            DataOps veri = new DataOps();

            string secili_ay = Takvim_Ekrani.static_yil + Takvim_Ekrani.static_ay.PadLeft(2, '0');
            string mazeret_yol = ana_yol + secili_ay + "_mazeret.csv";

            string icerik = secili_tarih + "," + comboBox1.SelectedIndex.ToString() + ",-1";

            veri.veriyaz(mazeret_yol, icerik);

            mazeret_temizle();

            listBox1.Items.Add(comboBox1.SelectedItem.ToString());

            listbox_guncelle();
        }
        private void mazeretSilBtn_Click(object sender, EventArgs e)
        {
            DataOps veri = new DataOps();
            DataTable mazeretliler = new DataTable();
            string mazeret_yol = ana_yol + Takvim_Ekrani.static_yil + Takvim_Ekrani.static_ay.PadLeft(2, '0') + "_mazeret.csv";

            mazeretliler = veri.Csv2Dt(mazeret_yol);

            int indis = listBox1.SelectedIndex;

            int id = Convert.ToInt32(gizliBox.Items[indis]);
            gizliBox.Items.RemoveAt(indis);
            listBox1.Items.Remove(listBox1.SelectedItem);

            listBox1.Update();
            gizliBox.Update();

            string icerik = "Tarih = '" + secili_tarih + "' AND Kisi = '" + (id - 1) + "'";

            DataRow[] silinecek = mazeretliler.Select(icerik);
            foreach (DataRow sil in silinecek)
            {
                mazeretliler.Rows.Remove(sil);
            }
            veri.Dt2Csv(mazeretliler, mazeret_yol);

        }

        private void ikameNobBtn_Click(object sender, EventArgs e)
        {
            string id = Dolu_GunUC.nobetci_id;



            DataTable nobet = new DataTable();
            DataOps veri = new DataOps();
            string nobet_yol = ana_yol + Takvim_Ekrani.static_yil + Takvim_Ekrani.static_ay.PadLeft(2, '0') + "_nobet.csv";
            nobet = veri.Csv2Dt(nobet_yol);

            DataRow[] silinecek = nobet.Select("Gun = '" + secili_tarih + "'");
            foreach (DataRow sil in silinecek)
            {
                nobet.Rows.Remove(sil);
            }
            veri.Dt2Csv(nobet, nobet_yol);

            int yil = Convert.ToInt32(Takvim_Ekrani.static_yil);
            int ay = Convert.ToInt32(Takvim_Ekrani.static_ay);
            int gun = Convert.ToInt32(Dolu_GunUC.statik_gun);

            Takvim_Ekrani.nobetmatik(gun, gun, yil, ay);

            Dolu_GunUC ucgunler = new Dolu_GunUC();

            nobet = veri.Csv2Dt(nobet_yol);
            nobet.DefaultView.Sort = "Gun";
            nobet = nobet.DefaultView.ToTable();
            veri.Dt2Csv(nobet, nobet_yol);

            string yeni_nobetci = nobet.Rows[gun - 1]["Nöbetçi"].ToString();
            string yeni_id = nobet.Rows[gun - 1]["Nöb_Id"].ToString();

            ucgunler.gunler(gun, yeni_nobetci, yeni_id);
        }

        //---------Ana Fonksiyonlar--------//
        public Mazeret_Ekrani()
        {
            InitializeComponent();
        }

        private void Mazeret_Ekrani_Load(object sender, EventArgs e)
        {
            

            mazeret_temizle();

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
                comboBox1.Items.Add(satir[1]);
            }

            listbox_guncelle();
        }

      
    }
}
