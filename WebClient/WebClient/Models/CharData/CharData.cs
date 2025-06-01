namespace WebClient.Models.CharData
{
    public class CharData
    {
        public string avatar { get; set; }
        public string? name { get; set; }
        public string alignment { get; set; }
        public string gender { get; set; }
        public int age { get; set; }
        public string weight { get; set; }
        public string height { get; set; }
        public string appearance { get; set; }
        public string className { get; set; }
        public string equipmentSetChoice { get; set; }
        public string race { get; set; }
        public string subrace { get; set; }
        public string backgroundName { get; set; }
        public List<string> finalSkillProficiencies { get; set; }
        public story story { get; set; }
        public abilityScores abilityScores { get; set; }
    }
}
