using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace _1_finalOdevOtelOtomasyonu.DOMAIN
{
    internal class Musterilerr
    {

        string adi, soyadi, telefon, mail, tc, cinsiyet, odaNumarasi;
        DateTime girisTarihi, cikisTarihi;
        long ucret;
        private string gAd;
        private string gSoyad;
        private string gTelefon;
        private string gMail;
        private string gTc;
        private string gCinsiyet;
        private string gOdaNumarasi;
        private string v1;
        private string v2;
        private long gUcret;

        public string Ad
        {
            get { return adi; }
            set { adi = value; }
        }


        public string Soyad
        {
            get { return soyadi; }
            set { soyadi = value; }
        }

        public string Telefon
        {
            get { return telefon; }
            set { telefon = value; }
        }


        public string Mail
        {
            get { return mail; }
            set { mail = value; }
        }

        public string Tc
        {
            get { return tc; }
            set { tc = value; }
        }


        public string Cinsiyet
        {
            get { return cinsiyet; }
            set { cinsiyet = value; }
        }

        public string OdaNumarasi
        {
            get { return odaNumarasi; }
            set { odaNumarasi = value; }
        }


        public DateTime GirisTarihi
        {
            get { return girisTarihi; }
            set { girisTarihi = value; }
        }


        public DateTime CikisTarihi
        {
            get { return cikisTarihi; }
            set { cikisTarihi = value; }
        }


        public long Ucret
        {
            get { return ucret; }
            set { ucret = value; }
        }


        public Musterilerr(string gAd, string gSoyad, string gTelefon, string gMail, string gTc, string gCinsiyet, string gOdaNumarasi, string gTc1, DateTime gGirisTarihi, DateTime gCikisTarihi, long gUcret)
        { 
            this.Ad = gAd;
            this.Soyad = gSoyad;
            this.Telefon = gTelefon;
            this.Mail = gMail;
            this.Tc = gTc;
            this.Cinsiyet = gCinsiyet;
            this.OdaNumarasi = gOdaNumarasi;
            this.GirisTarihi = gGirisTarihi;
            this.CikisTarihi = gCikisTarihi;
            this.Ucret = gUcret;
        }

        public Musterilerr(string gAd, string gSoyad, string gTelefon, string gMail, string gTc, string gCinsiyet, string gOdaNumarasi, string v1, string v2, long gUcret)
        {
            this.gAd = gAd;
            this.gSoyad = gSoyad;
            this.gTelefon = gTelefon;
            this.gMail = gMail;
            this.gTc = gTc;
            this.gCinsiyet = gCinsiyet;
            this.gOdaNumarasi = gOdaNumarasi;
            this.v1 = v1;
            this.v2 = v2;
            this.gUcret = gUcret;
        }

        //public Musterilerr(string gAd, string gSoyad, string gTelefon, string gMail, string gTc, string gCinsiyet, string gOdaNumarasi, DateTime gGirisTarihi, DateTime gCikisTarihi, long gUcret)
        //{
        //    this.gAd = gAd;
        //    this.gSoyad = gSoyad;
        //    this.gTelefon = gTelefon;
        //    this.gMail = gMail;
        //    this.gTc = gTc;
        //    this.gCinsiyet = gCinsiyet;
        //    this.gOdaNumarasi = gOdaNumarasi;
        //    this.gGirisTarihi = gGirisTarihi;
        //    this.gCikisTarihi = gCikisTarihi;
        //    this.gUcret = gUcret;
        //}


        //public Musterilerr(string ad, string soyad)
        //{
        //    this.Ad = adi;
        //    this.Soyad = soyadi;
        //}

        //public override string ToString()
        //{
        //    return this.adi + "-" + this.soyadi + "-" + this.mail + "-" + this.cinsiyet +  "-" + this.telefon + "-" + this.odaNumarasi + "-" + this.ucret + "-" + this.girisTarihi + "-" + this.cikisTarihi;
        //}

    }

}

