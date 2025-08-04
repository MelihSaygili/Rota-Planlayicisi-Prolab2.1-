using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekomobil
{
    public class GenelYolcu : Yolcu
    {
        public override string Tip => "Genel Yolcu";

        public override double İndirimUygula(double ücret)
        {
            return ücret; // İndirim yok
        }
    }
}