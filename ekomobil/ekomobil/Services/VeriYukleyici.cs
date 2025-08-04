using System;
using System.IO;
using System.Text.Json;
using ekomobil.Models;

namespace ekomobil
{
    public static class VeriYukleyici
    {
        public static VeriSeti VeriSetiniYukle(string dosyaYolu)
        {
            if (string.IsNullOrEmpty(dosyaYolu))
                throw new ArgumentNullException(nameof(dosyaYolu));

            if (!File.Exists(dosyaYolu))
                throw new FileNotFoundException($"Dosya bulunamadı: {dosyaYolu}");

            try
            {
                string json = File.ReadAllText(dosyaYolu);
                var veriSeti = JsonSerializer.Deserialize<VeriSeti>(json);

                if (veriSeti == null || veriSeti.Duraklar == null || veriSeti.Taxi == null)
                    throw new InvalidDataException("Geçersiz veri seti formatı");

                return veriSeti;
            }
            catch (JsonException ex)
            {
                throw new InvalidDataException("JSON dosyası geçersiz format içeriyor", ex);
            }
            catch (Exception ex)
            {
                throw new Exception("Veri yükleme hatası", ex);
            }
        }
    }
} 