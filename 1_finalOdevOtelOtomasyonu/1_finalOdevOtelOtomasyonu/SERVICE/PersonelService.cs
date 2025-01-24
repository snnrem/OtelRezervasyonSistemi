using _1_finalOdevOtelOtomasyonu.DAL;
using _1_finalOdevOtelOtomasyonu.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

namespace _1_finalOdevOtelOtomasyonu.SERVICE
{
    internal class PersonelService
    {
        internal void PersonelKaydet(string gPersonelAd, string gPersonelSoyad, string gPersonelTc, string gPersonelTelefon, string gPersonelMail,
            string gPersonelAdres, string gPersonelDepartmanAdi, string gPersonelGorev, string gPersonelMaas, DateTime gMusteriGirisTarihi)
        {
            (new PersonelDAO()).PersonelKaydet((new personel(gPersonelAd, gPersonelSoyad, gPersonelTc, gPersonelTelefon, gPersonelMail,
                gPersonelAdres, gPersonelDepartmanAdi, gPersonelGorev, Convert.ToInt32(gPersonelMaas), gMusteriGirisTarihi.Year + "-" + gMusteriGirisTarihi.Month
                + "-" + gMusteriGirisTarihi.Day)));
        }

        internal void PersonelSil(int gId)
        {
            (new PersonelDAO()).PersonelSil(gId);
        }

        internal void PersonelGuncelle(int gId, string gPersonelAd, string gPersonelSoyad, string gPersonelTc, string gPersonelTelefon, string gPersonelMail,
            string gPersonelAdres, string gPersonelDepartmanAdi, string gPersonelGorev, string gPersonelMaas, DateTime gMusteriGirisTarihi)
        {
            (new PersonelDAO()).PersonelGuncelle(gId, (new personel(gPersonelAd, gPersonelSoyad, gPersonelTc, gPersonelTelefon, gPersonelMail,
                gPersonelAdres, gPersonelDepartmanAdi, gPersonelGorev, Convert.ToInt32(gPersonelMaas), gMusteriGirisTarihi.Year + "-" + gMusteriGirisTarihi.Month
                + "-" + gMusteriGirisTarihi.Day)));
        }

    }
}