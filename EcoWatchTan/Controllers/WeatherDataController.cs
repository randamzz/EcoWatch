using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EcoWatchTan.Models;
using EcoWatch.Models.ApiData;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using EcoWatchTan.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;

namespace EcoWatchTan.Controllers
{
    public class WeatherDataController : Controller
    {
        private const string AppId = "dd1518ddd550b0d1418a53f5d09a2d6c"; // Clé de l'API OpenWeatherMap
    
        private readonly ApplicationDbContext _context;

        public WeatherDataController(ApplicationDbContext context)
        {
            _context = context;
        }

        // Get Data from Api 
        public async Task<List<WeatherData>> GetApiData()
        {
            List<WeatherData> weatherDataList = new List<WeatherData>();

            List<City> cityCoordinates = await _context.Cities.ToListAsync();

            using (var client = new HttpClient())
            {
                foreach (var city in cityCoordinates)
                {
                    // Construction de l'URL de l'API pour chaque ville (quartier)
                    string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?lat={city.Lat}&lon={city.Lon}&appid={AppId}";

                    // Appel de l'API pour obtenir les données météorologiques
                    var response = await client.GetAsync(apiUrl);
                    if (response.IsSuccessStatusCode)
                    {
                        var content = await response.Content.ReadAsStringAsync();  // Lecture du contenu de la réponse

                        Console.WriteLine(content);

                        // Désérialisation des données JSON en objet WeatherData
                        var weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                        Console.WriteLine(weatherData);
                        if (weatherData != null)
                        {
                            // Ajout des données météorologiques de la ville à la liste
                            weatherDataList.Add(weatherData);
                        }
                    }
                }
            }

            return weatherDataList;
        }

        // Traitement des données 
        public async Task<List<WeatherDataAnalysisResult>> AnalyzeWeatherData()
        {
            List<WeatherData> weatherDataList = await this.GetApiData();
            List<WeatherDataAnalysisResult> results = new List<WeatherDataAnalysisResult>();

            foreach (var weatherData in weatherDataList)
            {
                double normalizedHumidity = NormalizeHumidity(weatherData.Main.Humidity);
                double normalizedPrecipitation = NormalizePrecipitation(weatherData.Main.Pressure);
                double normalizedTemperature = NormalizeTemperature(weatherData.Main.Temp);
                double normalizedWindSpeed = NormalizeWindSpeed(weatherData.Wind.Speed);

                double globalScore = Math.Round((normalizedHumidity * 0.30) +
                                                (normalizedPrecipitation * 0.25) +
                                                (normalizedTemperature * 0.20) +
                                                (normalizedWindSpeed * 0.25), 2);


                string state;
                if (globalScore < 4)
                    state = "Normale";
                else if (globalScore >= 4 && globalScore < 6)
                    state = "MEDIUM";
                else if (globalScore >= 6 && globalScore < 8)
                    state = "HIGH";
                else
                    state = "SO HIGH";

                WeatherDataAnalysisResult result = new WeatherDataAnalysisResult
                {
                    Lon = weatherData.Coord.Lon,
                    Lat = weatherData.Coord.Lat,
                    Name = weatherData.Name,
                    Score = globalScore,
                    State = state
                };
                _context.WeatherDataAnalysisResults.Add(result);
                await _context.SaveChangesAsync();

                results.Add(result);
            }

            return results;
        }

        // Normaliser l'humidité
        private double NormalizeHumidity(int humidity)
        {
            return humidity / 100.0;
        }

        // Normaliser la pression
        private double NormalizePrecipitation(int pressure)
        {
            // Assumption: Pressure is in hPa
            return pressure / 1013.25; // Normalize relative to standard pressure at sea level (1013.25 hPa)
        }

        // Normaliser la température
        private double NormalizeTemperature(double temperature)
        {
            // Assumption: Temperature is in Kelvin
            return temperature - 273.15; // Convert Kelvin to Celsius
        }

        // Normaliser la vitesse du vent
        private double NormalizeWindSpeed(double windSpeed)
        {
            // Assumption: Wind speed is in meter/sec
            return windSpeed;
        }

        public async Task<IActionResult> Index()
        {
            List<WeatherDataAnalysisResult> results = await this.AnalyzeWeatherData();
            return View(results);
        }
    }
}
