namespace EcoWatch.Models.ApiData
{
    public class Sys
    {
        public int Type { get; set; }
        public int Id { get; set; }
        public string Country { get; set; } = "";
        public string Sunrise { get; set; }
        public string Sunset { get; set; }

        public Sys (int type, int id, string country, string sunrise, string sunset)
        {
            Type = type;
            Id = id;
            Country = country;
            Sunrise = sunrise;
            Sunset = sunset;
        }
    }
}
