namespace ekomobil
{
    public class Koordinat
    {
        public double Lat { get; set; }
        public double Lon { get; set; }

        public Koordinat(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }
    }
}