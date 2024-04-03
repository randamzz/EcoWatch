namespace EcoWatch.Models.ApiData
{
    public class Coord
    {
        public double Lon { get; set; }
        public double Lat { get; set; }

        public Coord(double lat, double lon)
        {
            Lat = lat;
            Lon = lon;
        }
    }
}
