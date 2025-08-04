using System;

namespace ekomobil
{
    public static class MesafeHesaplayici
    {
        private const double EarthRadiusKm = 6371.0; // Dünya'nın yarıçapı (km)

        public static double Hesapla(double lat1, double lon1, double lat2, double lon2)
        {
            // Dereceleri radyana çevir
            var dLat = ToRadians(lat2 - lat1);
            var dLon = ToRadians(lon2 - lon1);

            // Haversine formülü
            var a = Math.Sin(dLat / 2) * Math.Sin(dLat / 2) +
                    Math.Cos(ToRadians(lat1)) * Math.Cos(ToRadians(lat2)) *
                    Math.Sin(dLon / 2) * Math.Sin(dLon / 2);

            var c = 2 * Math.Atan2(Math.Sqrt(a), Math.Sqrt(1 - a));

            return EarthRadiusKm * c; // Kilometre cinsinden mesafe
        }

        private static double ToRadians(double degree)
        {
            return degree * (Math.PI / 180);
        }
    }
}