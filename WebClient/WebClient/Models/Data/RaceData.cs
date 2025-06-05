using System.Text.Json.Serialization;

namespace WebClient.Models.Data
{
    public class RaceData
    {
        public string name { get; set; }
        public string image { get; set; }
        public string description { get; set; }
        public AbilityScoreIncrease abilityScoreIncrease { get; set; }
        public List<Traits> commonTraits { get; set; }
        public int speed = 30;
        public string size = "medium";
        [JsonIgnore]
        public string unwanted_extra_data { get; set; }

    }

    public class AbilityScoreIncrease
    {
        public int str { get; set; }
        public int dex { get; set; }
        public int con { get; set; }
        public int @int { get; set; }
        public int wis { get; set; }
        public int cha { get; set; }
    }
    
    public class Traits
    {
        public string name { get; set; }
        public string text { get; set; }
    }

}