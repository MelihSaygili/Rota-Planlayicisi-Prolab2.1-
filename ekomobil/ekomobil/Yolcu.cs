using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekomobil
{
    public abstract class Yolcu
    {
        public abstract string Tip { get; }
        public abstract double İndirimUygula(double ücret);
    }
}
