using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekomobil
{
    public class NakitÖdeme : IÖdemeYöntemi
    {
        public double MevcutNakit { get; set; }

        public NakitÖdeme(double mevcutNakit)
        {
            MevcutNakit = mevcutNakit;
        }

        public string Tip => "Nakit";

        public bool ÖdemeYap(double miktar)
        {
            if (MevcutNakit >= miktar)
            {
                MevcutNakit -= miktar;
                return true;
            }
            return false;
        }
    }
}