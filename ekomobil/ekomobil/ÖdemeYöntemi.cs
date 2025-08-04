using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ekomobil
{
    public interface IÖdemeYöntemi
    {
        string Tip { get; }
        bool ÖdemeYap(double miktar);
    }
}