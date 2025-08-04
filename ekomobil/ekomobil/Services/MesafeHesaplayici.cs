using System;

namespace ekomobil
{
    public static class MesafeHesaplayici
    {
        private const double R = 6371; // Dünya'nın yarıçapı (km)

        public static double Hesapla(double lat1, double lon1, double lat2, double lon2)
        {
            var dLat = ToRadyan(lat2 - lat1);
            var dLon = ToRadyan(lon2 - lon1);
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadyan(lat1)) * Math.Cos(ToRadyan(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);
            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));
            return R * c;
        }

        private static double ToRadyan(double derece) => derece * (Math.PI / 180);
    }
} 