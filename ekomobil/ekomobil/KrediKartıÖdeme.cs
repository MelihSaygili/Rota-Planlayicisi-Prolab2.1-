using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekomobil
{
    public class KrediKartıÖdeme : IÖdemeYöntemi
    {
        public double KullanılabilirLimit { get; set; }

        public KrediKartıÖdeme(double limit)
        {
            KullanılabilirLimit = limit;
        }

        public string Tip => "Kredi Kartı";

        public bool ÖdemeYap(double miktar)
        {
            if (KullanılabilirLimit >= miktar)
            {
                KullanılabilirLimit -= miktar;
                return true;
            }
            return false;
        }
    }
}
