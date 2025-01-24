using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1_finalOdevOtelOtomasyonu.DOMAIN
{
    internal class odalar
    {
        int OdaNumarasi;
        bool Durum;
        string OdaTuru;
       
        public odalar(int gOdaNumarasi, bool gDurum, string gOdaTuru )
        {
            this.OOdaNumarasi = gOdaNumarasi;
            this.ODurum = gDurum;
            this.OOdaTuru = gOdaTuru;
        }

        public int OOdaNumarasi
        {
            get { return OdaNumarasi; }
            set { OdaNumarasi = value; }
        }

        public bool ODurum
        {
            get { return Durum; }
            set { Durum = value; }
        }
        public string OOdaTuru
        {
            get { return OdaTuru; }
            set { OdaTuru = value; }
        }

    }
}

internal class Odalar
{
    private string gUrunad;
    private double v1;
    private int v2;

    public Odalar(string gUrunad, double v1, int v2)
    {
        this.gUrunad = gUrunad;
        this.v1 = v1;
        this.v2 = v2;
    }
}
