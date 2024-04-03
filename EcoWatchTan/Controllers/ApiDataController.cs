using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Collections.Generic;

using Microsoft.AspNetCore.Identity;
using EcoWatchTan.Areas.Identity.Data;
using Microsoft.EntityFrameworkCore;
using EcoWatchTan.Models;
using EcoWatch.Models.ApiData;
using Microsoft.AspNetCore.Authorization;


namespace sechresse.Controllers
{
    public class ApiDataController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _dbContext;
        private const string AppId = "dd1518ddd550b0d1418a53f5d09a2d6c"; // Clé de l'API OpenWeatherMap

        public ApiDataController(UserManager<User> userManager, ApplicationDbContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }
        [Authorize]
        public async Task<IActionResult> Index()
        {
            var weatherDataList = new List<WeatherData>();

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                var userCity = user.Neighborhood; 

                if (!string.IsNullOrEmpty(userCity))
                {
                   
                    var city = await _dbContext.Cities.FirstOrDefaultAsync(c => c.Name == userCity);
                    if (city != null)
                    {
                        using (var client = new HttpClient())
                        {
                            string apiUrl = $"http://api.openweathermap.org/data/2.5/weather?lat={city.Lat}&lon={city.Lon}&appid={AppId}";

                           
                            var response = await client.GetAsync(apiUrl);
                            if (response.IsSuccessStatusCode)
                            {
                             
                                var content = await response.Content.ReadAsStringAsync();
                                Console.WriteLine(content);

                               
                                var weatherData = JsonConvert.DeserializeObject<WeatherData>(content);
                                Console.WriteLine(weatherData);
                                if (weatherData != null)
                                {
                                    double tempKelvin = weatherData.Main.Temp;
                                    double tempCelsius = tempKelvin - 273.15;

                                    weatherData.Main.Temp = Math.Round(tempCelsius, 2);
                                    if (long.TryParse(weatherData.Sys.Sunrise, out long sunriseUnix) && long.TryParse(weatherData.Sys.Sunset, out long sunsetUnix))
                                    {
                                        weatherData.Sys.Sunrise = DateTimeOffset.FromUnixTimeSeconds(sunriseUnix).ToLocalTime().ToString("h:mm tt");
                                        weatherData.Sys.Sunset = DateTimeOffset.FromUnixTimeSeconds(sunsetUnix).ToLocalTime().ToString("h:mm tt");
                                     

                                    }
                                    if (long.TryParse(weatherData.Dt, out long dtUnix))
                                    {
                                        weatherData.Dt = DateTimeOffset.FromUnixTimeSeconds(dtUnix).ToLocalTime().ToString("dd/MM/yyyy HH:mm:ss");
                                    }
                                    weatherDataList.Add(weatherData);
                                }
                            }
                        }
                    }
                }
            }

            return View(weatherDataList);
        }
    }
}