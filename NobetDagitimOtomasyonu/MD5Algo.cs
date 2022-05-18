using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace NobetDagitimOtomasyonu
{
    class MD5Algo
    {
        public string MD5cevirici(string sifre)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            byte[] veri = Encoding.UTF8.GetBytes(sifre);
            veri = md5.ComputeHash(veri);
            StringBuilder sb = new StringBuilder();

            foreach (byte ba in veri)
            {
                sb.Append(ba.ToString("x2").ToLower());
            }

            return sb.ToString();
        }
    }
}
