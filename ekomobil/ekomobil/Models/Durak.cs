using System.Collections.Generic;

namespace ekomobil
{
    public class Durak
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public double Lat { get; set; }
        public double Lon { get; set; }
        public List<NextStop> NextStops { get; set; }
        public Transfer Transfer { get; set; }
    }

    public class NextStop
    {
        public string StopId { get; set; }
        public double Mesafe { get; set; }
        public double Ucret { get; set; }
        public int Sure { get; set; }
    }

    public class Transfer
    {
        public string TransferStopId { get; set; }
        public double TransferUcret { get; set; }
        public int TransferSure { get; set; }
    }

    public class Taxi
    {
        public double OpeningFee { get; set; }
        public double CostPerKm { get; set; }
    }

    public class VeriSeti
    {
        public List<Durak> Duraklar { get; set; }
        public Taxi Taxi { get; set; }
    }

    public class Koordinat
    {
        public double Lat { get; }
        public double Lon { get; }

        public Koordinat(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }
    }
} 