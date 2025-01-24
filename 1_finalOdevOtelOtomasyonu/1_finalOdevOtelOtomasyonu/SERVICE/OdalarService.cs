using _1_finalOdevOtelOtomasyonu.DAL;
using _1_finalOdevOtelOtomasyonu.DOMAIN;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_finalOdevOtelOtomasyonu.SERVICE
{
    internal class OdalarService
    {
        internal void OdaSil(int gOdaNumarasi, bool gDurum, string gOdaTuru)
        {
            //(new OdalarDAO()).OdaKaydet((new odalar(Convert.ToInt32(gOdaNumarasi), gDurum, gOdaTuru)));
        }

        internal void urunKaydet(string gUrunad, string gUrunFiyat, string gUrunAdet)
        {
            (new OdalarDAO()).odaKaydet(new Odalar(gUrunad, Convert.ToDouble(gUrunFiyat), Convert.ToInt32(gUrunAdet)));
        }

        internal void odaKaydet(string gUrunad, string gUrunFiyat, string gUrunAdet)
        {
            (new OdalarDAO()).odaKaydet(new Odalar(gUrunad, Convert.ToDouble(gUrunFiyat), Convert.ToInt32(gUrunAdet)));
        }
    }
}
