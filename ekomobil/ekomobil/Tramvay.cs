namespace ekomobil
{
    public class Tramvay : TopluTaşıma
    {
        public override string Tip => "Tramvay";

        public override double ÜcretHesapla(double mesafe)
        {
            return 2.75;
        }

        public override int SüreHesapla(double mesafe)
        {
            return (int)(mesafe / (25 / 60.0));
        }
    }
}