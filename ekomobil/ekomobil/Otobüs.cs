namespace ekomobil
{
    public class Otobüs : TopluTaşıma
    {
        // Tip özelliğini uyguluyoruz
        public override string Tip => "Otobüs";

        public override double ÜcretHesapla(double mesafe)
        {
            // Örnek uygulama - duraklar arası sabit ücret
            return 3.50;
        }

        public override int SüreHesapla(double mesafe)
        {
            // Örnek: 20 km/saat hızla dakika cinsinden süre
            return (int)(mesafe / (20/60.0));
        }
    }
}