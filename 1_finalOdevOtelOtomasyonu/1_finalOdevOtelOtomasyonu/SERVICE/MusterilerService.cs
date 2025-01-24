using _1_finalOdevOtelOtomasyonu.DAL;
using _1_finalOdevOtelOtomasyonu.DOMAIN;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;
using System.Collections;


namespace _1_finalOdevOtelOtomasyonu.SERVICE
{
    public class MusterilerService
    {
        internal void MusterileriKaydet(string gMusteriAd, string gMusteriSoyad, string gMusteriTelefon, string gMusteriMail, string gMusteriTc,
            string gMusteriCinsiyet, string gMusteriOdaNumarasi, string gMusteriUcret, DateTime gMusteriGirisTarihi, DateTime gMusteriCikisTarihi)
        {
            int ucret;
            if (int.TryParse(gMusteriUcret.Replace(" TL", ""), out ucret))
            {
                (new MusterilerDAO()).MusterileriKaydet(new musteriler(gMusteriAd, gMusteriSoyad, gMusteriTelefon, gMusteriMail, gMusteriTc,
                    gMusteriCinsiyet, gMusteriOdaNumarasi, ucret, gMusteriGirisTarihi.ToString("yyyy-MM-dd"), gMusteriCikisTarihi.ToString("yyyy-MM-dd")));
            }
            else
            {
                // Hata durumunu uygun şekilde ele alın
                throw new FormatException("gMusteriUcret için geçersiz format");
            }
        }

        internal ArrayList MusterileriOku()
        {
            return (new MusterilerDAO()).MusterileriGetir();
        }

        internal void MusteriSil(int gId)
        {
            (new MusterilerDAO()).MusteriSil(gId);
        }
    }

}
