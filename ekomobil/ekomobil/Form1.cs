using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace ekomobil
{
    public partial class Form1 : Form
    {
        private List<Durak> _duraklar;
        private RotaHesaplayici _rotaHesaplayici;
        private Taksi _taksi = new Taksi(10.0, 3.0);
        private const double MAX_YURUME_MESAFE = 3.0; // km

        public Form1()
        {
            InitializeComponent();
            InitializeUI();
            InitializeComboboxes();
            LoadData();
        }

        private void InitializeUI()
        {
            this.Text = "EKOMOBİL";
            this.Size = new Size(910, 622);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;

            InitializePlaceholder(txtBaslangicLat, "Enlem");
            InitializePlaceholder(txtBaslangicLon, "Boylam");
            InitializePlaceholder(txtHedefLat, "Enlem");
            InitializePlaceholder(txtHedefLon, "Boylam");
        }

        private void InitializePlaceholder(TextBox textBox, string placeholder)
        {
            textBox.Text = placeholder;
            textBox.ForeColor = Color.Gray;
            textBox.GotFocus += (s, e) => RemovePlaceholder(textBox, placeholder);
            textBox.LostFocus += (s, e) => SetPlaceholder(textBox, placeholder);
        }

        private void RemovePlaceholder(TextBox textBox, string placeholder)
        {
            if (textBox.Text == placeholder)
            {
                textBox.Text = "";
                textBox.ForeColor = Color.Black;
            }
        }

        private void SetPlaceholder(TextBox textBox, string placeholder)
        {
            if (string.IsNullOrWhiteSpace(textBox.Text))
            {
                textBox.Text = placeholder;
                textBox.ForeColor = Color.Gray;
            }
        }

        private void InitializeComboboxes()
        {
            cmbYolcuTipi.Items.AddRange(new[] { "Genel Yolcu", "Öğrenci (%50)", "65+ Yaş (%25)" });
            cmbYolcuTipi.SelectedIndex = 0;

            cmbOdemeTipi.Items.AddRange(new[] { "Nakit", "Kredi Kartı", "KentKart" });
            cmbOdemeTipi.SelectedIndex = 0;
        }

        private void LoadData()
        {
            try
            {
                string dosyaYolu = Path.Combine(Application.StartupPath, "veriseti.json");
                var (duraklar, taksi) = VeriYukleyici.VerileriYukle(dosyaYolu);
                _duraklar = duraklar;
                _taksi = taksi;
                _rotaHesaplayici = new RotaHesaplayici(_duraklar);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Veri yükleme hatası: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                Application.Exit();
            }
        }

        private void btnHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                if (!ValidateInputs()) return;

                var baslangic = GetCoordinate(txtBaslangicLat.Text, txtBaslangicLon.Text);
                var hedef = GetCoordinate(txtHedefLat.Text, txtHedefLon.Text);

                var (startStop, startDistance) = FindNearestStop(baslangic);
                var (endStop, endDistance) = FindNearestStop(hedef);

                bool isStudent = cmbYolcuTipi.SelectedIndex == 1;
                var (rota, sure, ucret) = _rotaHesaplayici.RotaHesapla(startStop, endStop, isStudent);

                DisplayResults(rota, startStop, endStop, startDistance, endDistance, sure, ucret);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Hata: {ex.Message}", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (_rotaHesaplayici == null)
            {
                MessageBox.Show("Rota hesaplayıcı yüklenemedi.", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (!IsValidCoordinate(txtBaslangicLat.Text, txtBaslangicLon.Text) ||
                !IsValidCoordinate(txtHedefLat.Text, txtHedefLon.Text))
            {
                MessageBox.Show("Geçersiz koordinat formatı! Lütfen sayısal değerler girin.", "Hata",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            return true;
        }

        private Koordinat GetCoordinate(string latText, string lonText)
        {
            return new Koordinat(
                double.Parse(latText),
                double.Parse(lonText));
        }

        private (Durak stop, double distance) FindNearestStop(Koordinat koordinat)
        {
            var nearestStop = _duraklar
                .OrderBy(d => MesafeHesaplayici.Hesapla(
                    koordinat.Lat, koordinat.Lon, d.Lat, d.Lon))
                .First();

            var distance = MesafeHesaplayici.Hesapla(
                koordinat.Lat, koordinat.Lon,
                nearestStop.Lat, nearestStop.Lon);

            return (nearestStop, distance);
        }

        private void DisplayResults(List<string> rota, Durak startStop, Durak endStop,
            double startDistance, double endDistance, int toplamSure, decimal toplamUcret)
        {
            lstSonuclar.Items.Clear();
            lstSonuclar.Items.Add($"BAŞLANGIÇ: {startStop.Name} ({startStop.Type})");
            lstSonuclar.Items.Add($"HEDEF: {endStop.Name} ({endStop.Type})");
            lstSonuclar.Items.Add("----------------------------------------");

            // Başlangıç taksi ücreti
            if (startDistance > MAX_YURUME_MESAFE)
            {
                decimal taksiCost = (decimal)_taksi.ÜcretHesapla(startDistance);
                lstSonuclar.Items.Add($"TAKSİ: Başlangıç → {startStop.Name} [{startDistance:F2} km, {taksiCost:N2} TL]");
                toplamSure += _taksi.SüreHesapla(startDistance);
                toplamUcret += taksiCost;
            }

            // Rota detayları
            foreach (var step in rota)
            {
                lstSonuclar.Items.Add(step);
            }

            // Hedef taksi ücreti
            if (endDistance > MAX_YURUME_MESAFE)
            {
                decimal taksiCost = (decimal)_taksi.ÜcretHesapla(endDistance);
                lstSonuclar.Items.Add($"TAKSİ: {endStop.Name} → Hedef [{endDistance:F2} km, {taksiCost:N2} TL]");
                toplamSure += _taksi.SüreHesapla(endDistance);
                toplamUcret += taksiCost;
            }

            // İndirim bilgisi
            decimal orijinalUcret = GetOrijinalUcret(toplamUcret, cmbYolcuTipi.SelectedIndex);

            lstSonuclar.Items.Add("----------------------------------------");
            lstSonuclar.Items.Add($"TOPLAM SÜRE: {toplamSure} dakika");
            lstSonuclar.Items.Add($"TOPLAM MALİYET: {toplamUcret:N2} TL)");
            lstSonuclar.Items.Add($"YOLCU TİPİ: {cmbYolcuTipi.SelectedItem}");
            lstSonuclar.Items.Add($"ÖDEME TİPİ: {cmbOdemeTipi.SelectedItem}");
        }

        private decimal GetOrijinalUcret(decimal indirimliUcret, int yolcuTipiIndex)
        {
            switch (yolcuTipiIndex)
            {
                case 1: return indirimliUcret / 0.5m; // Öğrenci
                case 2: return indirimliUcret / 0.75m; // 65+ Yaş
                default: return indirimliUcret; // Genel Yolcu
            }
        }

        private bool IsValidCoordinate(string lat, string lon)
        {
            return !string.IsNullOrWhiteSpace(lat) &&
                   !string.IsNullOrWhiteSpace(lon) &&
                   double.TryParse(lat, out _) &&
                   double.TryParse(lon, out _);
        }
    }


}