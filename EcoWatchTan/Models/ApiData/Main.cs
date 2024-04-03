namespace EcoWatch.Models.ApiData
{
    public class Main
    {
        public double Temp { get; set; }
        public double FeelsLike { get; set; }
        public double TempMin { get; set; }
        public double TempMax { get; set; }
        public int Pressure { get; set; }
        public int Humidity { get; set; }

        public Main (double temp, double feelsLike, double tempMin, double tempMax, int pressure, int humidity)
        {
            Temp = temp;
            FeelsLike = feelsLike;
            TempMin = tempMin;
            TempMax = tempMax;
            Pressure = pressure;
            Humidity = humidity;
        }
    }
}
