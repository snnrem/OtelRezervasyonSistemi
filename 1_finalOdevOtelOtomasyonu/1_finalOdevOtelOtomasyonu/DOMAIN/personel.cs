using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_finalOdevOtelOtomasyonu.DOMAIN
{
    internal class personel
    {
        string PersonelAd, PersonelSoyad, PersonelTc, PersonelTelefon, PersonelMail, PersonelAdres, PersonelDepartmanAdi, PersonelGorev, PersonelGirisTarihi;
        int PersonelId, PersonelMaas;

        public personel(string gPersonelAd, string gPersonelSoyad, string gPersonelTc, string gPersonelTelefon, string gPersonelMail,
            string gPersonelAdres, string gPersonelDepartmanAdi, string gPersonelGorev, int gPersonelMaas, string gMusteriGirisTarihi)
        {
            this.PersonelAd = gPersonelAd;
            this.PersonelSoyad = gPersonelSoyad;
            this.PersonelTc = gPersonelTc;
            this.PersonelTelefon = gPersonelTelefon;
            this.PersonelMail = gPersonelMail;
            this.PersonelAdres = gPersonelAdres;
            this.PersonelDepartmanAdi = gPersonelDepartmanAdi;
            this.PersonelGorev = gPersonelGorev;
            this.PersonelMaas = gPersonelMaas;
            this.PersonelGirisTarihi = gMusteriGirisTarihi;
        }

        public string PAd
        {
            get { return PersonelAd; }
            set { PersonelAd = value; }
        }

        public string PSoyad
        {
            get { return PersonelSoyad; }
            set { PersonelSoyad = value; }
        }
        public string PTc
        {
            get { return PersonelTc; }
            set { PersonelTc = value; }
        }

        public string PTelefon
        {
            get { return PersonelTelefon; }
            set { PersonelTelefon = value; }
        }

        public string PMail
        {
            get { return PersonelMail; }
            set { PersonelMail = value; }
        }

        public string PAdres
        {
            get { return PersonelAdres; }
            set { PersonelAdres = value; }
        }

        public string PDepartmanAdi
        {
            get { return PersonelDepartmanAdi; }
            set { PersonelDepartmanAdi = value; }
        }

        public string PGorev
        {
            get { return PersonelGorev; }
            set { PersonelGorev = value; }
        }

        public int PMaas
        {
            get { return PersonelMaas; }
            set { PersonelMaas = value; }
        }

        public string PGirisTarihi
        {
            get { return PersonelGirisTarihi; }
            set { PersonelGirisTarihi = value; }
        }

    }


    internal class Personel
    {
        private int v1;
        private string v2;
        private int v3;

        public Personel(int v1, string v2, int v3, string v, string v4)
        {
            this.v1 = v1;
            this.v2 = v2;
            this.v3 = v3;
        }

        public Personel(int v1, string v2, int v3, string v, string v4, string v5, string v6, string v7, string v8, string v9, string v10) : this(v1, v2, v3, v, v4)
        {
        }
    }
}
