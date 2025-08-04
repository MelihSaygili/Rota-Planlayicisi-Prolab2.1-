using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekomobil
{
    public class ÖğrenciYolcu : Yolcu
    {
        public override string Tip => "Öğrenci";

        public override double İndirimUygula(double ücret)
        {
            return ücret * 0.5; // %50 indirim
        }
    }
}
