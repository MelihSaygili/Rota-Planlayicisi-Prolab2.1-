# 🚌 Ulaşım Rota Planlayıcısı

**Ulaşım Rota Planlayıcısı**, toplu taşıma araçları, yolcu tipleri ve ödeme yöntemleri arasında ilişki kurarak yolculuk ve ücret hesaplaması yapan bir .NET tabanlı masaüstü uygulamasıdır.

Bu proje, nesne yönelimli programlama (OOP) prensiplerine uygun olarak yapılandırılmıştır ve **WindowsForms** arayüzü ile kullanıcı etkileşimi sağlar.

---

## 🚀 Özellikler

- 🚌 Otobüs, 🚋 Tramvay ve 🚕 Taksi sınıflarının tanımlanması
- 👨‍🎓 Öğrenci, 👵 Yaşlı ve Genel yolcu sınıflarının işlenmesi
- 💳 Nakit, Kredi Kartı, Kent Kartı gibi ödeme yöntemleri
- 📍 Duraklar arası mesafe hesaplaması
- 📦 JSON formatında veri seti desteği (`veriseti.json`)
- 🗺️ Koordinat sistemi ve rota hesaplayıcı
- 🧠 Katmanlı sınıf yapısı ile modüler mimari

---

## 🖥️ Kullanılan Teknolojiler

| Teknoloji | Açıklama |
|----------|----------|
| C# (.NET Framework) | Programlama dili |
| WinForms | Masaüstü arayüz |
| JSON | Veri depolama |
| Visual Studio 2022 | Geliştirme ortamı |

---
🧠 Temel Kavramlar
Nesne yönelimli programlama (kalıtım, çok biçimlilik)

Soyut sınıflar ve arayüzler ile davranışların ayrıştırılması

Gerçek dünya modellemesi: Araç-Yolcu-Ödeme ilişkileri


ProjeYapısı
----------------------------
ekomobil/
├── araç.cs
├── Durak.cs
├── Form1.cs
├── Otobüs.cs
├── Tramvay.cs
├── Taksi.cs
├── ÖğrenciYolcu.cs
├── YaşlıYolcu.cs
├── GenelYolcu.cs
├── KrediKartıÖdeme.cs
├── KentKartÖdeme.cs
├── NakitÖdeme.cs
├── MesafeHesaplayici.cs
├── RotaHesaplayici.cs
├── Koordinat.cs
├── ÖdemeYöntemi.cs
├── veriseti.json
└── Program.cs

