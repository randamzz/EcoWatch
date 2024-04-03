using System.ComponentModel.DataAnnotations;

namespace EcoWatchTan.Models
{
    public class WeatherDataAnalysisResult
    {
        [Key]
        public int Id { get; set; }
        public double Lon { get; set; }
        public double Lat { get; set; }
        public string Name { get; set; } = "";
        public double Score { get; set; }
        public string State { get; set; } = "";
    }
}

