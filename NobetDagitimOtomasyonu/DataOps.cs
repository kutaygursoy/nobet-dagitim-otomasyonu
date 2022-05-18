using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace NobetDagitimOtomasyonu
{
    class DataOps
    {
        public DataTable Csv2Dt(string dosya_yolu)
        {
            DataTable csv_dt = new DataTable();
            string tum_metin;
            if (File.Exists(dosya_yolu))
            {
                using (StreamReader sr = new StreamReader(dosya_yolu))
                {
                    while (!sr.EndOfStream)
                    {
                        tum_metin = sr.ReadToEnd().ToString();      // tüm metni oku
                        string[] satirlar = tum_metin.Split('\n');  // satırlara böl
                        for (int i = 0; i < satirlar.Count() - 1; i++)
                        {
                            var regex = new Regex("\\\"(.*?)\\\"");
                            var output = regex.Replace(satirlar[i], m => m.Value.Replace(",", "\\c"));

                            string[] satir_verisi = output.Split(',');  // virgülle ayır
                            {
                                if (i == 0)                             // Başlık Sütunlarını adlandır
                                {
                                    for (int j = 0; j < satir_verisi.Count(); j++)
                                    {
                                        csv_dt.Columns.Add(satir_verisi[j].Replace("\\c", ",").Trim());
                                    }

                                }
                                else
                                {
                                    try
                                    {
                                        DataRow dr = csv_dt.NewRow();
                                        for (int k = 0; k < satir_verisi.Count(); k++)
                                        {
                                            if (k >= dr.Table.Columns.Count) // başlıklardan fazla sütun verisi varsa ekle
                                            {
                                                csv_dt.Columns.Add("Sütun" + k);
                                                dr = csv_dt.NewRow();
                                            }
                                            dr[k] = satir_verisi[k].Replace("\\c", ",");

                                        }
                                        csv_dt.Rows.Add(dr);            //satır verisini ekle
                                    }
                                    catch (Exception ex)
                                    {
                                        MessageBox.Show("Okuma Hatası \n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                }
                            }
                        }
                    }
                }
            }

            return csv_dt;
        }

        public void Dt2Csv(DataTable alinan_dt, string dosya_yolu)
        {
            StreamWriter sw = new StreamWriter(dosya_yolu, false);

            for (int i = 0; i < alinan_dt.Columns.Count; i++)
            {
                sw.Write(alinan_dt.Columns[i].ToString().Trim());                     //başlıklar
                if (i < alinan_dt.Columns.Count - 1)
                {
                    sw.Write(",");
                }
            }
            sw.Write(sw.NewLine);
            foreach (DataRow dr in alinan_dt.Rows)
            {
                for (int i = 0; i < alinan_dt.Columns.Count; i++)
                {
                    if (!Convert.IsDBNull(dr[i]))
                    {
                        string hucre_degeri = dr[i].ToString().Trim();
                        if (hucre_degeri.Contains(','))
                        {
                            hucre_degeri = String.Format("\"{0}\"", hucre_degeri);
                            sw.Write(hucre_degeri);
                        }
                        else
                        {
                            sw.Write(dr[i].ToString().Trim());
                        }
                    }
                    if (i < alinan_dt.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.Write(sw.NewLine);
            }
            sw.Close();
        }

        public void Dgv2Csv(DataGridView alinan_grid, string cikti_dosyasi)
        {

            int sutun_satisi = alinan_grid.ColumnCount;         // alınan griddeki sütun sayısı
            string sutun_adlari = "";
            string[] veri = new string[alinan_grid.RowCount];   // satır sayısı kadar dizi oluştur

            for (int i = 0; i < sutun_satisi - 1; i++)
            {
                sutun_adlari += alinan_grid.Columns[i].Name.ToString().Trim() + ","; // sütun adlarını yaz
            }
            sutun_adlari += alinan_grid.Columns[sutun_satisi - 1].Name.ToString().Trim(); // son sütun adından sonra virgül koyma
            veri[0] += sutun_adlari;

            for (int i = 1; (i - 1) < alinan_grid.RowCount; i++)
            {
                for (int j = 0; j < sutun_satisi - 1; j++)
                {
                    if (alinan_grid.Rows[i - 1].Cells[j].Value != null)     //boş veri kontrolü
                    {
                        veri[i] += alinan_grid.Rows[i - 1].Cells[j].Value.ToString().Trim() + ","; // sütunlara ait verileri yaz
                    }
                }

                if (alinan_grid.Rows[i - 1].Cells[sutun_satisi - 1].Value != null) //boş veri kontrolü
                {
                    veri[i] += alinan_grid.Rows[i - 1].Cells[sutun_satisi - 1].Value.ToString().Trim(); // son sütuna ait verileri yaz virgül koyma
                }

            }

            try
            {
                System.IO.File.WriteAllLines(cikti_dosyasi, veri, System.Text.Encoding.UTF8);

                MessageBox.Show("Veriler Yazıldı", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler Yazılamadı \n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }

        public void veriyaz(string yol, string icerik)
        {
            try
            {
                using (StreamWriter dosya = new StreamWriter(yol, true))
                {
                    dosya.WriteLine(icerik);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Veriler Yazılamadı \n" + ex.Message, "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


    }
}
