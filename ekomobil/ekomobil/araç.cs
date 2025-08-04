namespace ekomobil
{
    public abstract class Araç
    {
        public abstract string Tip { get; }
        public abstract double ÜcretHesapla(double mesafe);
        public abstract int SüreHesapla(double mesafe);
    }
}