using System;
using System.Collections.Generic;
using System.Linq;

namespace ekomobil
{
    public class RotaHesaplayici
    {
        private List<Durak> _duraklar;

        public RotaHesaplayici(List<Durak> duraklar)
        {
            _duraklar = duraklar;
        }

        public (List<string> Rota, int ToplamSure, decimal ToplamUcret) RotaHesapla(Durak baslangic, Durak hedef, bool isStudent)
        {
            // BFS için kuyruk
            var queue = new Queue<(Durak Durak, List<string> Rota, decimal Ucret, int Sure)>();
            // Ziyaret edilen durakları takip etmek için
            var visited = new HashSet<string>();
            // Her durak için en kısa yolu saklamak
            var shortestPath = new Dictionary<string, (List<string> Rota, decimal Ucret, int Sure)>();

            // Başlangıç durumunu kuyruğa ekle
            queue.Enqueue((baslangic, new List<string> { $"{baslangic.Name} ({baslangic.Type})" }, 0m, 0));
            shortestPath[baslangic.Id] = (new List<string> { $"{baslangic.Name} ({baslangic.Type})" }, 0m, 0);

            while (queue.Count > 0)
            {
                var (current, currentRota, currentUcret, currentSure) = queue.Dequeue();

                // Hedefe ulaştıysak, mevcut rotayı güncelle
                if (current.Id == hedef.Id)
                {
                    if (!shortestPath.ContainsKey(hedef.Id) || currentSure < shortestPath[hedef.Id].Sure)
                    {
                        shortestPath[hedef.Id] = (currentRota, currentUcret, currentSure);
                    }
                    continue;
                }

                // Eğer bu durak daha önce ziyaret edildiyse ve daha kısa bir süreyle, devam etme
                if (visited.Contains(current.Id) && shortestPath[current.Id].Sure < currentSure)
                    continue;

                visited.Add(current.Id);

                // NextStops bağlantılarını keşfet
                foreach (var nextStop in current.NextStops)
                {
                    var nextDurak = _duraklar.Find(d => d.Id == nextStop.StopId);
                    if (nextDurak == null || visited.Contains(nextDurak.Id))
                        continue;

                    var newRota = new List<string>(currentRota)
                    {
                        $"{current.Name} ({current.Type}) → {nextDurak.Name} ({nextDurak.Type}) [{nextStop.Sure} dk, {nextStop.Ucret:F2} TL]"
                    };
                    var newUcret = currentUcret + (decimal)nextStop.Ucret;
                    var newSure = currentSure + nextStop.Sure;

                    if (!shortestPath.ContainsKey(nextDurak.Id) || newSure < shortestPath[nextDurak.Id].Sure)
                    {
                        shortestPath[nextDurak.Id] = (newRota, newUcret, newSure);
                        queue.Enqueue((nextDurak, newRota, newUcret, newSure));
                    }
                }

                // Transfer bağlantısını keşfet
                if (current.Transfer != null)
                {
                    var transferTo = _duraklar.Find(d => d.Id == current.Transfer.TransferStopId);
                    if (transferTo == null || visited.Contains(transferTo.Id))
                        continue;

                    var newRota = new List<string>(currentRota)
                    {
                        $"Aktarma: {current.Name} → {transferTo.Name} [{current.Transfer.TransferSure} dk, {current.Transfer.TransferUcret:F2} TL]",
                        $"{transferTo.Name} ({transferTo.Type})"
                    };
                    var newUcret = currentUcret + (decimal)current.Transfer.TransferUcret;
                    var newSure = currentSure + current.Transfer.TransferSure;

                    if (!shortestPath.ContainsKey(transferTo.Id) || newSure < shortestPath[transferTo.Id].Sure)
                    {
                        shortestPath[transferTo.Id] = (newRota, newUcret, newSure);
                        queue.Enqueue((transferTo, newRota, newUcret, newSure));
                    }
                }
            }

            // Hedefe ulaşılamadıysa hata fırlat
            if (!shortestPath.ContainsKey(hedef.Id))
            {
                throw new Exception($"Hedefe ({hedef.Name}) ulaşılamadı.");
            }

            var (finalRota, finalUcret, finalSure) = shortestPath[hedef.Id];
            if (!finalRota.Last().Contains(hedef.Name))
            {
                finalRota.Add($"{hedef.Name} ({hedef.Type})");
            }

            // Öğrenci indirimi uygula
            if (isStudent)
            {
                finalUcret *= 0.5m; // %50 indirim
            }

            return (finalRota, finalSure, finalUcret);
        }
    }
}