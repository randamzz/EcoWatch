
namespace EcoWatch.Models.ApiData
{
    public class WeatherData
    {
        public Coord Coord { get; set; }
        public List<Weather> Weather { get; set; }
        public string Base { get; set; }
        public Main Main { get; set; }
        public int Visibility { get; set; }
        public Wind Wind { get; set; }
        public Clouds Clouds { get; set; }
        public string Dt { get; set; }
        public Sys Sys { get; set; }
        public string Timezone { get; set; }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Cod { get; set; }

        public WeatherData (Coord coord, List<Weather> weather, string @base, Main main, int visibility, Wind wind, Clouds clouds, string dt, Sys sys, string timezone, int id, string name, int cod)
        {
            Coord = coord;
            Weather = weather;
            Base = @base;
            Main = main;
            Visibility = visibility;
            Wind = wind;
            Clouds = clouds;
            Dt = dt;
            Sys = sys;
            Timezone = timezone;
            Id = id;
            Name = name;
            Cod = cod;
        }
    }
}
