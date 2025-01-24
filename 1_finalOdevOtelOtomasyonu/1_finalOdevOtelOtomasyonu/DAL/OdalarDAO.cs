using _1_finalOdevOtelOtomasyonu.DOMAIN;
using _1_finalOdevOtelOtomasyonu.SERVICE;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_finalOdevOtelOtomasyonu.DAL
{
    internal class OdalarDAO
    {
        public void OdaSil(yonetici gOdalar)
        {
            new MySqlCommand("INSERT INTO Odalar (OdaNumarasi, Durum, OdaTuru) values ('" +
                gOdalar.OOdaNumarasi + "','" + gOdalar.ODurum + "','" + gOdalar.OOdaTuru + "')", (new dbBaglanti()).baglantiGetir()).ExecuteNonQuery();
        }

        internal void odaKaydet(Odalar odalar)
        {
            throw new NotImplementedException();
        }
    }
}
