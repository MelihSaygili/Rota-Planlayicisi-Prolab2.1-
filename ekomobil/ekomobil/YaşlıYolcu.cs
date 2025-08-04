using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekomobil
{
    public class YaşlıYolcu : Yolcu
    {
        public override string Tip => "65+ Yaş";

        public override double İndirimUygula(double ücret)
        {
            return ücret * 0.75; // %25 indirim
        }
    }
}