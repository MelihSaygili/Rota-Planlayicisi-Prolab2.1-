using System.Collections.Generic;

public class Durak
{
    public string Id { get; set; }
    public string Name { get; set; }
    public string Type { get; set; }
    public double Lat { get; set; }
    public double Lon { get; set; }
    public bool SonDurak { get; set; }
    public List<NextStop> NextStops { get; set; }
    public Transfer Transfer { get; set; } // Aktarma bilgisi
}

public class Transfer
{
    public string TransferStopId { get; set; }
    public int TransferSure { get; set; }
    public double TransferUcret { get; set; }
}

public class NextStop
{
    public string StopId { get; set; }
    public double Mesafe { get; set; }
    public int Sure { get; set; }
    public double Ucret { get; set; }
}