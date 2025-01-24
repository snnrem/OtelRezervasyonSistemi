using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_finalOdevOtelOtomasyonu.DOMAIN
{
    internal class yonetici
    {
        string YoneticiAd, YoneticiSoyad, YoneticiKullaniciAdi;
        int YoneticiId, YoneticiSifre;

        public yonetici(string gYoneticiAd, string gYoneticiSoyad, string gYoneticiKullaniciAdi, int gYoneticiSifre)
        {
            this.YAd = gYoneticiAd;
            this.YSoyad = gYoneticiSoyad;
            this.YKullaniciAdi = gYoneticiKullaniciAdi;
            this.YSifre = gYoneticiSifre;
           
        }

        public string YAd
        {
            get { return YoneticiAd; }
            set { YoneticiAd = value; }
        }

        public string YSoyad
        {
            get { return YoneticiSoyad; }
            set { YoneticiSoyad = value; }
        }
        public string YKullaniciAdi
        {
            get { return YoneticiKullaniciAdi; }
            set { YoneticiKullaniciAdi = value; }
        }

        public int YSifre
        {
            get { return YoneticiSifre; }
            set { YoneticiSifre = value; }
        }

        public string OOdaNumarasi { get; internal set; }
        public string ODurum { get; internal set; }
        public string OOdaTuru { get; internal set; }
    }
}
