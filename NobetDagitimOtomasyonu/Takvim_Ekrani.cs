using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;
using System.Text;

namespace NobetDagitimOtomasyonu
{
    
    public partial class Takvim_Ekrani : Form
    {

        //---------Sabitler-------//

        int yil, ay;
        public static string static_yil, static_ay, ana_yol;
        public static string yetki = Login_Ekrani.yetki.Trim();

        public enum gun_adi
        {
            pazar,
            pazartesi,
            salı,
            çarşamba,
            perşembe,
            cuma,
            cumartesi,
            resmi_tatil,
            dini_tatil,
            idari_tatil,
            toplam_puan
        }

        //---------Yardımcı Fonksiyonlar--------//
        public static void nobetmatik(int ilk_gun, int son_gun, int yil, int ay)
        {
            //----Zaman bilgisi ---- //
            DateTime aybasi = new DateTime(yil, ay, 1);
            int toplam_gun = DateTime.DaysInMonth(yil, ay);
            int dayofweek = Convert.ToInt32(aybasi.DayOfWeek.ToString("d"));
            int onceki_ay = ay - 1;
            int onceki_yil = yil;

            if (ay == 1)
            {
                onceki_ay = 12;
                onceki_yil = yil - 1;
            }

            //------ Dosya yolları ---- //
            string mazeret_yol = ana_yol + yil.ToString() + ay.ToString().PadLeft(2, '0') + "_mazeret.csv";
            string personel_yol = ana_yol + "personel.csv";
            string puan_yol = ana_yol + "puan.csv";
            string nobet_yol = ana_yol + yil.ToString() + ay.ToString().PadLeft(2, '0') + "_nobet.csv";
            string onceki_nobet_yol = ana_yol + onceki_yil.ToString() + onceki_ay.ToString().PadLeft(2, '0') + "_nobet.csv";

            // ----- DT oluştur ----//
            DataOps veri = new DataOps();
            DataTable mazeret_dt = new DataTable();
            DataTable personel_dt = new DataTable();
            DataTable puan_dt = new DataTable();
            DataTable aylik_nobet = new DataTable();
            DataTable gecen_ay = new DataTable();

            //----- DT Doldur ---//
            mazeret_dt = veri.Csv2Dt(mazeret_yol);
            personel_dt = veri.Csv2Dt(personel_yol);
            puan_dt = veri.Csv2Dt(puan_yol);
            gecen_ay = veri.Csv2Dt(onceki_nobet_yol);


            mazeret_dt.DefaultView.Sort = "Tarih"; // mazeret ve ek puanları tarihe göre sıraladık
            mazeret_dt = mazeret_dt.DefaultView.ToTable();
            veri.Dt2Csv(mazeret_dt, mazeret_yol);

            //DataRow[]dr = puan_dt.AsEnumerable().Take(1).ToArray();
            //object[] buffer = dr[0].ItemArray;
            //int[] sabit_puanlar = Array.ConvertAll(buffer, (p => Convert.ToInt32(p)));  //puanları okuduk sabit puan katarına yükledik

            int[] aylik_puanlar = new int[toplam_gun];
            int[,] mazeretli_listesi = new int[toplam_gun, personel_dt.Rows.Count];

            //int[] mazeretli_listesi = new int[toplam_gun];

            for (int i = 0; i < toplam_gun; i++)            //özel gün yokmuş gibi standart aylık puanları dağıt
            {
                //aylik_puanlar[i] = sabit_puanlar[dayofweek%7];
                aylik_puanlar[i] = (dayofweek % 7);
                dayofweek++;
            }
            dayofweek = Convert.ToInt32(aybasi.DayOfWeek.ToString("d")); // orijinal haline geri döndür

            DataRow[] ek_puan = mazeret_dt.Select("Kisi = 'puan'");     // mazeretlerden özel günleri çek
            foreach (DataRow sira in ek_puan)                           //özel gün puanlarını mevcut puanla değiştir
            {
                int sub = Int32.Parse(sira[0].ToString().Substring(6, 2));
                int x = Int32.Parse(sira[2].ToString());

                aylik_puanlar[sub - 1] = x;
                //aylik_puanlar[sub - 1] = sabit_puanlar[x];// ilk gün 0 dan başlıyor 1 çıkart

            }


            int flag_out = 0; ;
            int yatay = 0;
            DataRow[] mazeretli_kisi = mazeret_dt.Select("Kisi <> 'puan'", "Tarih ASC"); // mazeretlerden mazeretli personeli çek
            foreach (DataRow sira in mazeretli_kisi)
            {
                int flag_in = Int32.Parse(sira[0].ToString().Substring(6, 2));
                int mazeret_id = Int32.Parse(sira[1].ToString());

                if (flag_in == flag_out)
                {
                    yatay++;
                    mazeretli_listesi[flag_in - 1, yatay] = mazeret_id + 1;             // ilk gün 0 dan başlıyor 1 çıkart, personel indisi 1 arttır yoksa hep 0 mazeretli
                    flag_out = flag_in;

                }
                else
                {
                    yatay = 0;
                    mazeretli_listesi[flag_in - 1, 0] = mazeret_id + 1;             // ilk gün 0 dan başlıyor 1 çıkart, personel indisi 1 arttır yoksa hep 0 mazeretli
                    flag_out = flag_in;

                }
            }

            //----Dağıtım motoruna girecek değişkenler ---//
            string nobetci_adi, gun = "";
            int nobetci_id, eski_puan, yeni_puan;
            bool m_flag1, m_flag2 = false;
            int indis, bir_onceki_nobetci, iki_onceki_nobetci = 0;
            int[] mazeretli_idler = new int[personel_dt.Rows.Count];

            if (!File.Exists(nobet_yol))
            {
                aylik_nobet.Columns.Add(new DataColumn("Gun", typeof(string)));
                aylik_nobet.Columns.Add(new DataColumn("Puan", typeof(int)));
                aylik_nobet.Columns.Add(new DataColumn("Mazeretli", typeof(int)));
                aylik_nobet.Columns.Add(new DataColumn("Nöbetçi", typeof(string)));
                aylik_nobet.Columns.Add(new DataColumn("Nöb_Id", typeof(int)));
                veri.Dt2Csv(aylik_nobet, nobet_yol);

            }
            else
            {
                aylik_nobet = veri.Csv2Dt(nobet_yol);
            }


            try
            {
                for (int i = ilk_gun; i <= son_gun; i++)
                {
                    gun = yil.ToString() + ay.ToString().PadLeft(2, '0') + i.ToString().PadLeft(2, '0');

                    if (i == 1)
                    {


                        iki_onceki_nobetci = Convert.ToInt32(gecen_ay.Rows[gecen_ay.Rows.Count - 2][4]);    //Geçen ayın son 2 nöbetçisini al
                        bir_onceki_nobetci = Convert.ToInt32(gecen_ay.Rows[gecen_ay.Rows.Count - 1][4]);

                        if (aylik_puanlar[i - 1] > 6)  // özel gün tespiti
                        {
                            personel_dt = veri.Csv2Dt(personel_yol);
                            indis = aylik_puanlar[i - 1];
                            var enum_getir = (gun_adi)indis;                            //10 nu yapmalı araştırmak lazım adaletsiz olabiliyor
                            string gunadi = enum_getir.ToString();
                            string arama = gunadi+ ",toplam_puan";
                            personel_dt.DefaultView.Sort = arama;                      //o gün(dow) için en düşük puana göre sırala
                            personel_dt = personel_dt.DefaultView.ToTable();

                        }
                        else
                        {
                            personel_dt = veri.Csv2Dt(personel_yol);
                            indis = dayofweek % 7;
                            var enum_getir = (gun_adi)indis;
                            string gunadi = enum_getir.ToString();
                            string arama = gunadi + ",toplam_puan";
                            personel_dt.DefaultView.Sort = arama;                         //o gün(dow) için en düşük puana göre sırala
                            personel_dt = personel_dt.DefaultView.ToTable();
                        }

                        nobetci_adi = personel_dt.Rows[0][1].ToString();            //en düşük puanlı ilk personel
                        nobetci_id = Convert.ToInt32(personel_dt.Rows[0][0]);

                        m_flag1 = (Equals(nobetci_id, bir_onceki_nobetci) || Equals(nobetci_id, iki_onceki_nobetci));  // öncekilerle seçileni kontrol et
                        m_flag2 = (mazeretli_listesi[i - 1, 0] > 0);                                                      // seçilen mazeretli mi

                        if (mazeretli_listesi[i - 1, 0] > 0)
                        {

                            for (int s = 0; s < personel_dt.Rows.Count; s++)
                            {
                                mazeretli_idler[s] = mazeretli_listesi[i - 1, s];
                            }

                        }

                        int a = 1;
                        while (m_flag1 || m_flag2)                                      // iki kontrole göre bir sonraki personeli seç
                        {
                            nobetci_adi = personel_dt.Rows[a][1].ToString();
                            nobetci_id = Convert.ToInt32(personel_dt.Rows[a][0]);


                            if (Equals(nobetci_id, bir_onceki_nobetci) || Equals(nobetci_id, iki_onceki_nobetci))
                            {
                                a++;
                                m_flag1 = true;
                            }
                            else
                            {
                                m_flag1 = false;
                            }


                            if (mazeretli_idler.Contains(nobetci_id))
                            {
                                a++;
                            }
                            else
                            {

                                m_flag2 = false;
                            }

                            if (a >= personel_dt.Rows.Count)
                            {
                                m_flag1 = false;
                                m_flag2 = false;
                                throw new Exception("Yetersiz Personel\nGün: " + gun);

                            }

                        }

                        int z = 0;
                        DataRow[] puan = personel_dt.Select("ID = '" + nobetci_id + "'");
                        eski_puan = Int32.Parse(puan[0][indis + 2].ToString());
                        yeni_puan = eski_puan + Convert.ToInt32(puan_dt.Rows[0][aylik_puanlar[i - 1]]);
                        puan[0][indis + 2] = yeni_puan.ToString();
                        personel_dt.AcceptChanges();
                        for (int t = 2; t < personel_dt.Columns.Count - 2; t++)
                        {
                            z += int.Parse(puan[0][t].ToString());
                        }
                        puan[0][personel_dt.Columns.Count - 1] = z.ToString();
                        personel_dt.AcceptChanges();
                        veri.Dt2Csv(personel_dt, personel_yol);


                        aylik_nobet.Rows.Add(gun, aylik_puanlar[i - 1], mazeretli_listesi[i - 1, 0], nobetci_adi, nobetci_id);
                        veri.Dt2Csv(aylik_nobet, nobet_yol);

                        dayofweek++;


                    }
                    else if (i == 2)
                    {


                        iki_onceki_nobetci = Convert.ToInt32(gecen_ay.Rows[gecen_ay.Rows.Count - 1][4]); //Geçen ayın son, bu ayın ilk nöbetçisini al
                        bir_onceki_nobetci = Convert.ToInt32(aylik_nobet.Rows[i - 2][4]);

                        if (aylik_puanlar[i - 1] > 6)  // özel gün tespiti
                        {
                            personel_dt = veri.Csv2Dt(personel_yol);
                            indis = aylik_puanlar[i - 1];
                            var enum_getir = (gun_adi)indis;
                            string gunadi = enum_getir.ToString();
                            string arama = gunadi + ",toplam_puan";
                            personel_dt.DefaultView.Sort = arama;                      //o gün(dow) için en düşük puana göre sırala
                            personel_dt = personel_dt.DefaultView.ToTable();

                        }
                        else
                        {
                            personel_dt = veri.Csv2Dt(personel_yol);
                            indis = dayofweek % 7;
                            var enum_getir = (gun_adi)indis;
                            string gunadi = enum_getir.ToString();
                            string arama = gunadi + ",toplam_puan";
                            personel_dt.DefaultView.Sort = arama;                      //o gün(dow) için en düşük puana göre sırala
                            personel_dt = personel_dt.DefaultView.ToTable();
                        }

                        nobetci_adi = personel_dt.Rows[0][1].ToString();            //en düşük puanlı ilk personel
                        nobetci_id = Convert.ToInt32(personel_dt.Rows[0][0]);

                        m_flag1 = (Equals(nobetci_id, bir_onceki_nobetci) || Equals(nobetci_id, iki_onceki_nobetci));  // öncekilerle seçileni kontrol et
                        m_flag2 = (mazeretli_listesi[i - 1, 0] > 0);                                                      // seçilen mazeretli mi

                        if (mazeretli_listesi[i - 1, 0] > 0)
                        {

                            for (int s = 0; s < personel_dt.Rows.Count; s++)
                            {
                                mazeretli_idler[s] = mazeretli_listesi[i - 1, s];
                            }

                        }

                        int a = 1;
                        while (m_flag1 || m_flag2)                                      // iki kontrole göre bir sonraki personeli seç
                        {
                            nobetci_adi = personel_dt.Rows[a][1].ToString();
                            nobetci_id = Convert.ToInt32(personel_dt.Rows[a][0]);


                            if (Equals(nobetci_id, bir_onceki_nobetci) || Equals(nobetci_id, iki_onceki_nobetci))
                            {
                                a++;
                                m_flag1 = true;
                            }
                            else
                            {
                                m_flag1 = false;
                            }


                            if (mazeretli_idler.Contains(nobetci_id))
                            {
                                a++;
                            }
                            else
                            {
                                m_flag2 = false;
                            }

                            if (a >= personel_dt.Rows.Count)
                            {
                                m_flag1 = false;
                                m_flag2 = false;
                                throw new Exception("Yetersiz Personel\nGün: " + gun);

                            }

                        }

                        int z = 0;
                        DataRow[] puan = personel_dt.Select("ID = '" + nobetci_id + "'");
                        eski_puan = Int32.Parse(puan[0][indis + 2].ToString());
                        yeni_puan = eski_puan + Convert.ToInt32(puan_dt.Rows[0][aylik_puanlar[i - 1]]);
                        puan[0][indis + 2] = yeni_puan.ToString();
                        personel_dt.AcceptChanges();
                        for (int t = 2; t < personel_dt.Columns.Count - 2; t++)
                        {
                            z += int.Parse(puan[0][t].ToString());
                        }
                        puan[0][personel_dt.Columns.Count - 1] = z.ToString();
                        personel_dt.AcceptChanges();
                        veri.Dt2Csv(personel_dt, personel_yol);


                        aylik_nobet.Rows.Add(gun, aylik_puanlar[i - 1], mazeretli_listesi[i - 1, 0], nobetci_adi, nobetci_id);
                        veri.Dt2Csv(aylik_nobet, nobet_yol);

                        dayofweek++;

                    }
                    else
                    {
                        iki_onceki_nobetci = Convert.ToInt32(aylik_nobet.Rows[i - 3][4]);  // bugünden önceki iki nöbetçiyi al
                        bir_onceki_nobetci = Convert.ToInt32(aylik_nobet.Rows[i - 2][4]);

                        if (aylik_puanlar[i - 1] > 6)  // özel gün tespiti
                        {
                            personel_dt = veri.Csv2Dt(personel_yol);
                            indis = aylik_puanlar[i - 1];
                            var enum_getir = (gun_adi)indis;
                            string gunadi = enum_getir.ToString();
                            string arama = gunadi + ",toplam_puan";
                            personel_dt.DefaultView.Sort = arama;                      //o gün(dow) için en düşük puana göre sırala
                            personel_dt = personel_dt.DefaultView.ToTable();

                        }
                        else
                        {
                            personel_dt = veri.Csv2Dt(personel_yol);
                            indis = dayofweek % 7;
                            var enum_getir = (gun_adi)indis;
                            string gunadi = enum_getir.ToString();
                            string arama = gunadi + ",toplam_puan";
                            personel_dt.DefaultView.Sort = arama;                      //o gün(dow) için en düşük puana göre sırala
                            personel_dt = personel_dt.DefaultView.ToTable();
                        }

                        nobetci_adi = personel_dt.Rows[0][1].ToString();            //en düşük puanlı ilk personel
                        nobetci_id = Convert.ToInt32(personel_dt.Rows[0][0]);

                        m_flag1 = (Equals(nobetci_id, bir_onceki_nobetci) || Equals(nobetci_id, iki_onceki_nobetci));  // öncekilerle seçileni kontrol et
                        m_flag2 = (mazeretli_listesi[i - 1, 0] > 0);                                                      // seçilen mazeretli mi

                        if (mazeretli_listesi[i - 1, 0] > 0)
                        {

                            for (int s = 0; s < personel_dt.Rows.Count; s++)
                            {
                                mazeretli_idler[s] = mazeretli_listesi[i - 1, s];
                            }


                        }

                        int a = 1;
                        while (m_flag1 || m_flag2)                                      // iki kontrole göre bir sonraki personeli seç
                        {
                            nobetci_adi = personel_dt.Rows[a][1].ToString();
                            nobetci_id = Convert.ToInt32(personel_dt.Rows[a][0]);


                            if (Equals(nobetci_id, bir_onceki_nobetci) || Equals(nobetci_id, iki_onceki_nobetci))
                            {
                                a++;
                                m_flag1 = true;
                            }
                            else
                            {
                                m_flag1 = false;
                            }


                            if (mazeretli_idler.Contains(nobetci_id))
                            {
                                a++;
                            }
                            else
                            {
                                m_flag2 = false;
                            }

                            if (a >= personel_dt.Rows.Count)
                            {
                                m_flag1 = false;
                                m_flag2 = false;
                                throw new Exception("Yetersiz Personel\nGün: " + gun);

                            }
                        }

                        int z = 0;
                        DataRow[] puan = personel_dt.Select("ID = '" + nobetci_id + "'");
                        eski_puan = Int32.Parse(puan[0][indis + 2].ToString());
                        yeni_puan = eski_puan + Convert.ToInt32(puan_dt.Rows[0][aylik_puanlar[i - 1]]);
                        puan[0][indis + 2] = yeni_puan.ToString();
                        personel_dt.AcceptChanges();
                        for (int t = 2; t < personel_dt.Columns.Count - 2; t++)
                        {
                            z += int.Parse(puan[0][t].ToString());
                        }
                        puan[0][personel_dt.Columns.Count - 1] = z.ToString();
                        personel_dt.AcceptChanges();
                        veri.Dt2Csv(personel_dt, personel_yol);


                        aylik_nobet.Rows.Add(gun, aylik_puanlar[i - 1], mazeretli_listesi[i - 1, 0], nobetci_adi, nobetci_id);
                        veri.Dt2Csv(aylik_nobet, nobet_yol);

                        dayofweek++;

                    }


                }

                veri.Dt2Csv(aylik_nobet, nobet_yol);
                //test_grid.DataSource = aylik_nobet;

                personel_dt = veri.Csv2Dt(personel_yol);



                DataTable clone = new DataTable();
                clone.Columns.Add("ID", typeof(int));
                clone.Load(personel_dt.CreateDataReader(), LoadOption.OverwriteChanges);

                clone.DefaultView.Sort = "ID";
                clone = clone.DefaultView.ToTable();
                veri.Dt2Csv(clone, personel_yol);


                MessageBox.Show("Dağıtım Yapıldı", "Başarılı");
            }
            catch (Exception ex)
            {

                MessageBox.Show("Dağıtımda bir hata oluştu!\nMazeretleri ve Veritabanlarını kontrol ediniz\n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void Mazeret_olustur(DateTime aybasi)
        {
            DataOps mazeret_olustur = new DataOps();
            string icerik = "Tarih,Kisi,Mazeret";
            string mazeret_yol = ana_yol + aybasi.Year.ToString() + aybasi.Month.ToString().PadLeft(2, '0') + "_mazeret.csv";
            if (!File.Exists(mazeret_yol))
            {
                mazeret_olustur.veriyaz(mazeret_yol, icerik);
            }

        }

        private void gunleriGoster(DateTime zaman)
        {

            yil = zaman.Year;
            ay = zaman.Month;
            int bos_sayisi = 0;

            static_yil = yil.ToString();
            static_ay = ay.ToString();


            string nobet_yol = ana_yol + yil.ToString() + ay.ToString().PadLeft(2, '0') + "_nobet.csv";
            DataOps veri = new DataOps();
            DataTable aylik_nobet = new DataTable();
            aylik_nobet = veri.Csv2Dt(nobet_yol);
            string nobetci = "";
            string id = "";

           yil_ay_etiketi.Text = "YIL : " + yil.ToString() + " AY : " + ay.ToString();

            DateTime aybasi = new DateTime(yil, ay, 1);

            int toplam_gun = DateTime.DaysInMonth(yil, ay);

            int dayofweek = Convert.ToInt32(aybasi.DayOfWeek.ToString("d"));

            if (dayofweek == 0)
            {
                for (int i = 0; i < 6; i++)
                {
                    Bos_GunUC ucbos = new Bos_GunUC();

                    takvim_gorunum.Controls.Add(ucbos);
                    bos_sayisi++;
                }

            }
            else
            {
                for (int i = 1; i < dayofweek; i++)
                {
                    Bos_GunUC ucbos = new Bos_GunUC();

                    takvim_gorunum.Controls.Add(ucbos);
                    bos_sayisi++;
                }

            }


            for (int i = 1; i <= toplam_gun; i++)
            {
                Dolu_GunUC ucgunler = new Dolu_GunUC();
                if (aylik_nobet.Rows.Count > 1)
                {
                    nobetci = aylik_nobet.Rows[i - 1]["Nöbetçi"].ToString();
                    id = aylik_nobet.Rows[i - 1]["Nöb_Id"].ToString();
                }

                ucgunler.gunler(i, nobetci, id);
                if (((bos_sayisi) + (i % 7)) % 7 == 6 || ((bos_sayisi) + (i % 7)) % 7 == 0)
                {
                    ucgunler.BackColor = Color.Gray;
                }

                takvim_gorunum.Controls.Add(ucgunler);

            }


        }



        //--------------Butonlar-------------//

        private void oncekiAyBtn_Click(object sender, EventArgs e)
        {
            takvim_gorunum.Controls.Clear();

            if (ay == 1)
            {
                yil--;
                ay = 12;

            }
            else
            {
                ay--;
            }

            DateTime aybasi = new DateTime(yil, ay, 1);
            Mazeret_olustur(aybasi);
            gunleriGoster(aybasi);

        }

        private void sonrakiAyBtn_Click(object sender, EventArgs e)
        {
            takvim_gorunum.Controls.Clear();

            if (ay == 12)
            {
                yil++;
                ay = 1;
            }
            else
            {
                ay++;
            }

            DateTime aybasi = new DateTime(yil, ay, 1);
            Mazeret_olustur(aybasi);
            gunleriGoster(aybasi);
        }

        private void nobetDagitimBtn_Click(object sender, EventArgs e)
        {
            //----Zaman bilgisi ---- //
            DateTime aybasi = new DateTime(yil, ay, 1);
            int toplam_gun = DateTime.DaysInMonth(yil, ay);

            OncekiAy_Ekrani.yil = aybasi.Year;
            OncekiAy_Ekrani.ay = aybasi.Month - 1;
            if (OncekiAy_Ekrani.ay == 1)
            {
                OncekiAy_Ekrani.yil -= 1;
                OncekiAy_Ekrani.ay = 12;

            }
            string onceki_nobet_yol = ana_yol + OncekiAy_Ekrani.yil.ToString() + OncekiAy_Ekrani.ay.ToString().PadLeft(2, '0') + "_nobet.csv";
            DataOps veri = new DataOps();
            DataTable gecen_ay = new DataTable();
            gecen_ay = veri.Csv2Dt(onceki_nobet_yol);


            if (gecen_ay.Rows.Count>1)
            {
                nobetmatik(1, toplam_gun, yil, ay);
                takvim_gorunum.Controls.Clear();
                gunleriGoster(aybasi);
            }
            else
            {
                MessageBox.Show("Nöbetlerin dağıtımı için lütfen bir önceki\nayın son iki nöbetçisini giriniz", "Dağıtım Hatası", MessageBoxButtons.OK, MessageBoxIcon.Stop);

                OncekiAy_Ekrani oturum = new OncekiAy_Ekrani();
                oturum.Show();

            }
           
        }

        private void veriIslemBtn_Click(object sender, EventArgs e)
        {
            Veri_Ekrani yeni_ekran = new Veri_Ekrani();
            yeni_ekran.Show();
        }

        private void printerBtn_Click(object sender, EventArgs e)
        {
            DataOps veri = new DataOps();
            DataTable aylik_nobet = new DataTable();
            string nobet_yol = ana_yol + yil.ToString() + ay.ToString().PadLeft(2, '0') + "_nobet.csv";
            string pdf_yol = ana_yol + yil.ToString() + ay.ToString().PadLeft(2, '0') + "_nobet.pdf";

            if (File.Exists(pdf_yol))
            {
                File.Delete(pdf_yol);

            }

            aylik_nobet = veri.Csv2Dt(nobet_yol);

            DataTable print_dt = aylik_nobet.DefaultView.ToTable(false, "Gun", "Nöbetçi");

           

            try
            {

                Document document = new Document();
                PdfWriter writer = PdfWriter.GetInstance(document, new FileStream(pdf_yol, FileMode.Create));
                document.Open();

                Encoding.RegisterProvider(CodePagesEncodingProvider.Instance); // Türkçe karakter sorunu çözümü
                var Cp1254 = Encoding.GetEncoding(1254);

                iTextSharp.text.pdf.BaseFont Helvetica_Turkish = iTextSharp.text.pdf.BaseFont.CreateFont("Helvetica", "Cp1254", iTextSharp.text.pdf.BaseFont.NOT_EMBEDDED); // yeni font kayıtlıyoruz

                iTextSharp.text.Font font12 = new iTextSharp.text.Font(Helvetica_Turkish, 12, iTextSharp.text.Font.NORMAL);

                               

                PdfPTable tablo = new PdfPTable(print_dt.Columns.Count);
                PdfPRow satir = null;
                float[] widths = new float[print_dt.Columns.Count];
                for (int i = 0; i < print_dt.Columns.Count; i++)
                    widths[i] = 4f;

                tablo.SetWidths(widths);

                tablo.WidthPercentage = 100;
                int iCol = 0;
                string colname = "";
                PdfPCell cell = new PdfPCell(new Phrase("Products"));

                cell.Colspan = print_dt.Columns.Count;

                foreach (DataColumn c in print_dt.Columns)
                {
                    tablo.AddCell(new Phrase(c.ColumnName, font12));
                }

                foreach (DataRow r in print_dt.Rows)
                {
                    if (print_dt.Rows.Count > 0)
                    {
                        for (int h = 0; h < print_dt.Columns.Count; h++)
                        {
                            tablo.AddCell(new Phrase(r[h].ToString(), font12));
                        }
                    }
                }
                document.Add(tablo);
                document.Close();

                MessageBox.Show("PDF Yazıldı");

            }
            catch (Exception ex)
            {
                MessageBox.Show("Yazım Hatası\n"+ex.ToString());

            }
        }

       

        //---------Ana Fonksiyonlar--------//
        public Takvim_Ekrani()
        {
            InitializeComponent();

            veriIslemBtn.Enabled = false;

            if (yetki == "1")
            {
                veriIslemBtn.Enabled = true;
            }

            ana_yol = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
            ana_yol = ana_yol + "\\NobetMatik\\dosyalar\\";
            if (!Directory.Exists(ana_yol))
            {
                Directory.CreateDirectory(ana_yol);
            }

            DataOps veri = new DataOps();
            //--personel csv kontrol--//
            string icerik_personel = "ID,ad_soyad,pazar,pazartesi,salı,çarşamba,perşembe,cuma,cumartesi,resmi_tatil,dini_tatil,idari_tatil,toplam_puan";
            string icerik_puan = "pazar, pazartesi, salı, çarşamba, perşembe, cuma, cumartesi, resmi_tatil, dini_tatil, idari_tatil, toplam_puan";
            string personel_yol = ana_yol + "personel.csv";
            string puan_yol = ana_yol + "puan.csv";

            if (!File.Exists(personel_yol))
            {
                File.Create(personel_yol).Dispose();
                veri.veriyaz(personel_yol, icerik_personel);
            }

            if (!File.Exists(puan_yol))
            {
                File.Create(puan_yol).Dispose();
                veri.veriyaz(puan_yol, icerik_puan);
            }

        }

        private void Takvim_Ekrani_Load(object sender, EventArgs e)
        {
            DateTime aybasi = DateTime.Now;            

            Mazeret_olustur(aybasi);

            gunleriGoster(aybasi);

        }
    }
}
