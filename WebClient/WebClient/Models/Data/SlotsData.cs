namespace WebClient.Models.Data
{
    public class SlotsData
    {
        public List<SlotData> slots {  get; set; }
    }

    public class SlotData
    {
        public string name { get; set; }
        public string mapImage { get; set; }
        public List<MarkerData> markerks { get; set; }
    }

    public class MarkerData
    {
        public string name { get; set; }
        public string description { get; set; }
        public string image { get; set; }
        public string type { get; set; }
        public long x { get; set; }
        public long y { get; set; }
    }
}
