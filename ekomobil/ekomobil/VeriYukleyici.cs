// Taksi.cs
using ekomobil;
using Newtonsoft.Json.Serialization;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace ekomobil
{


    // VeriYukleyici.cs
    public static class VeriYukleyici
    {
        public static (List<Durak> Duraklar, Taksi Taksi) VerileriYukle(string dosyaYolu)
        {
            var settings = new JsonSerializerSettings
            {
                ContractResolver = new DefaultContractResolver
                {
                    NamingStrategy = new CamelCaseNamingStrategy()
                }
            };

            var veri = JsonConvert.DeserializeObject<VeriSeti>(File.ReadAllText(dosyaYolu), settings);
            return (veri.Duraklar, new Taksi(veri.taxi.OpeningFee, veri.taxi.CostPerKm));
        }

        private class VeriSeti
        {
            public taxi taxi { get; set; }
            public List<Durak> Duraklar { get; set; }
        }

        private class taxi
        {
            public double OpeningFee { get; set; }
            public double CostPerKm { get; set; }
        }
    }
}