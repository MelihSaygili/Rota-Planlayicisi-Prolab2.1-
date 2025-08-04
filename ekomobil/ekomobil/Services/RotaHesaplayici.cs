using System;
using System.Collections.Generic;
using System.Linq;
using ekomobil.Models;

namespace ekomobil.Services
{
    public class RotaHesaplayici
    {
        private readonly Dictionary<string, Durak> _duraklar;
        private const int MAX_STEPS = 20;

        public RotaHesaplayici(IEnumerable<Durak> duraklar)
        {
            if (duraklar == null)
                throw new ArgumentNullException(nameof(duraklar));

            _duraklar = duraklar.ToDictionary(d => d.Id);
        }

        public (List<string> rota, double toplamUcret, int toplamSure) RotaHesapla(Durak baslangic, Durak hedef)
        {
            if (baslangic == null || hedef == null)
                throw new ArgumentNullException("Başlangıç veya hedef durak null olamaz.");

            if (!_duraklar.ContainsKey(baslangic.Id) || !_duraklar.ContainsKey(hedef.Id))
                throw new ArgumentException("Geçersiz durak ID");

            var rota = new List<string>();
            double toplamUcret = 0;
            int toplamSure = 0;

            if (baslangic.Id == hedef.Id)
            {
                rota.Add("Başlangıç ve hedef aynı durak.");
                return (rota, toplamUcret, toplamSure);
            }

            var queue = new Queue<(Durak, List<string>, double, int)>();
            var visited = new HashSet<string>();
            queue.Enqueue((baslangic, new List<string>(), 0, 0));

            int steps = 0;
            while (queue.Count > 0 && steps < MAX_STEPS)
            {
                var current = queue.Dequeue();
                var currentDurak = current.Item1;
                var path = current.Item2;
                var ucret = current.Item3;
                var sure = current.Item4;

                if (currentDurak.Id == hedef.Id)
                {
                    rota.AddRange(path);
                    toplamUcret = ucret;
                    toplamSure = sure;
                    return (rota, toplamUcret, toplamSure);
                }

                var visitKey = $"{currentDurak.Id}-{path.Count}";
                if (visited.Contains(visitKey)) continue;
                visited.Add(visitKey);

                if (currentDurak.NextStops != null)
                {
                    foreach (var next in currentDurak.NextStops)
                    {
                        if (!_duraklar.TryGetValue(next.StopId, out var sonrakiDurak)) continue;

                        var yeniPath = new List<string>(path)
                        {
                            $"{currentDurak.Type}: {currentDurak.Name} → {sonrakiDurak.Name} " +
                            $"[{next.Mesafe:F2} km, {next.Ucret:F2} TL, {next.Sure} dk]"
                        };
                        queue.Enqueue((sonrakiDurak, yeniPath, ucret + next.Ucret, sure + next.Sure));
                    }
                }

                if (currentDurak.Transfer != null)
                {
                    if (_duraklar.TryGetValue(currentDurak.Transfer.TransferStopId, out var transferDurak))
                    {
                        var transferPath = new List<string>(path)
                        {
                            $"Transfer: {currentDurak.Name} ({currentDurak.Type}) → {transferDurak.Name} ({transferDurak.Type}) " +
                            $"[{currentDurak.Transfer.TransferUcret:F2} TL, {currentDurak.Transfer.TransferSure} dk]"
                        };
                        queue.Enqueue((transferDurak, transferPath, ucret + currentDurak.Transfer.TransferUcret, sure + currentDurak.Transfer.TransferSure));
                    }
                }

                steps++;
            }

            if (steps >= MAX_STEPS)
            {
                rota.Add($"Hedefe ({hedef.Name}) ulaşılamadı. Maksimum adım sayısı ({MAX_STEPS}) aşıldı.");
            }
            else
            {
                rota.Add($"Hedefe ({hedef.Name}) ulaşılamadı. Bağlantı eksik.");
            }

            return (rota, toplamUcret, toplamSure);
        }
    }
} 