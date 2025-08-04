using System;

namespace ekomobil
{
    public class Taksi
    {
        public double OpeningFee { get; set; }
        public double CostPerKm { get; set; }

        public Taksi(double openingFee, double costPerKm)
        {
            OpeningFee = openingFee;
            CostPerKm = costPerKm;
        }

        public double ÜcretHesapla(double mesafe)
        {
            return OpeningFee + (mesafe * CostPerKm);
        }

        public int SüreHesapla(double mesafe)
        {
            // Taksi hızı: 30 km/sa ≈ 0.5 km/dk
            return (int)Math.Ceiling(mesafe / 0.5);
        }
    }
}