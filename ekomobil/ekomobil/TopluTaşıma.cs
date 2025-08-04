namespace ekomobil
{
    public abstract class TopluTaşıma : Araç
    {
        public string HatAdı { get; set; }
        public string DurakId { get; set; }

        // Araç sınıfındaki soyut üyeleri uyguluyoruz
        public override abstract string Tip { get; }
        public override abstract double ÜcretHesapla(double mesafe);
        public override abstract int SüreHesapla(double mesafe);
    }

}