using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_finalOdevOtelOtomasyonu.DOMAIN
{
    public class musteriler
    {
        string MusteriAd, MusteriSoyad, MusteriTelefon, MusteriMail, MusteriTc, MusteriCinsiyet, MusteriOdaNumarasi,MusteriGirisTarihi, MusteriCikisTarihi;
        int MusteriUcret;
        int MusteriId;

        public musteriler(string gMusteriAd, string gMusteriSoyad, string gMusteriTelefon, string gMusteriMail, string gMusteriTc,
            string gMusteriCinsiyet, string gMusteriOdaNumarasi, int gMusteriUcret, string gMusteriGirisTarihi, string gMusteriCikisTarihi)
        {
            this.Ad = gMusteriAd;
            this.Soyad = gMusteriSoyad;
            this.Telefon = gMusteriTelefon;
            this.Mail = gMusteriMail;
            this.Tc = gMusteriTc;
            this.Cinsiyet = gMusteriCinsiyet;
            this.OdaNumarasi = gMusteriOdaNumarasi;
            this.Ucret = gMusteriUcret;
            this.GirisTarihi = gMusteriGirisTarihi;
            this.CikisTarihi = gMusteriCikisTarihi;          
        }

        public musteriler(int v1, string v2, double v3, int v4, string v5, string v6, string v7, string v8, string v9, string v10, string v11)
        {
        }

        public string Ad
        {
            get { return MusteriAd; }
            set { MusteriAd = value; }
        }

        public string Soyad
        {
            get { return MusteriSoyad; }
            set { MusteriSoyad = value; }
        }

        public string Telefon
        {
            get { return MusteriTelefon; }
            set { MusteriTelefon = value; }
        }

        public string Mail
        {
            get { return MusteriMail; }
            set { MusteriMail = value; }
        }

        public string Tc
        {
            get { return MusteriTc; }
            set { MusteriTc = value; }
        }

        public string Cinsiyet
        {
            get { return MusteriCinsiyet; }
            set { MusteriCinsiyet = value; }
        }

        public string OdaNumarasi
        {
            get { return MusteriOdaNumarasi; }
            set { MusteriOdaNumarasi = value; }
        }

        public string GirisTarihi
        {
            get { return MusteriGirisTarihi; }
            set { MusteriGirisTarihi = value; }
        }

        public string CikisTarihi
        {
            get { return MusteriCikisTarihi; }
            set { MusteriCikisTarihi = value; }
        }

        public int Ucret
        {
            get { return MusteriUcret; }
            set { MusteriUcret = value; }
        }  
    }
}
