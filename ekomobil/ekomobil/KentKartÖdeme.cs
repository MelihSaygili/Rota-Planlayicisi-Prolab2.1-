using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekomobil
{
    public class KentKartÖdeme : IÖdemeYöntemi
    {
        public double Bakiye { get; set; }

        public KentKartÖdeme(double bakiye)
        {
            Bakiye = bakiye;
        }

        public string Tip => "KentKart";

        public bool ÖdemeYap(double miktar)
        {
            if (Bakiye >= miktar)
            {
                Bakiye -= miktar;
                return true;
            }
            return false;
        }
    }
}