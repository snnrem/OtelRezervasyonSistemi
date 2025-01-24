using _1_finalOdevOtelOtomasyonu.DAL;
using _1_finalOdevOtelOtomasyonu.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_finalOdevOtelOtomasyonu.SERVICE
{
    internal class YoneticiService
    {
        internal void YoneticiKaydet(string gYoneticiAd, string gYoneticiSoyad, string gYoneticiKullaniciAdi, string gYoneticiSifre)
        {
            (new PersonelDAO()).YoneticiKaydet((new yonetici(gYoneticiAd, gYoneticiSoyad, gYoneticiKullaniciAdi, Convert.ToInt32(gYoneticiSifre))));
        }

        internal void YoneticiSil(int gId)
        {
            (new PersonelDAO()).PersonelSil(gId);
        }

        internal void YoneticiGuncelle(int gId, string gYoneticiAd, string gYoneticiSoyad, string gYoneticiKullaniciAdi, string gYoneticiSifre)
        {
            (new PersonelDAO()).PersonelGuncelle(gId, new yonetici(gYoneticiAd, gYoneticiSoyad, gYoneticiKullaniciAdi, Convert.ToInt32(gYoneticiSifre)));
        }


    }
}
