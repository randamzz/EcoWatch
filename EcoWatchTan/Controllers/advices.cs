﻿using EcoWatchTan.Areas.Identity.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace EcoWatchTan.Controllers
{
    public class AdvicesController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly ApplicationDbContext _context;

        public AdvicesController(UserManager<User> userManager, ApplicationDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [Authorize]

        public async Task<IActionResult> Index()
        {
            string userCity = "";

            if (User.Identity.IsAuthenticated)
            {
                var user = await _userManager.GetUserAsync(User);
                userCity = user.Neighborhood;
            }

            var result = await _context.WeatherDataAnalysisResults.FirstOrDefaultAsync(r => r.Name == userCity);

            // Access the score from the result
            double score = result != null ? result.Score : 0.0;

            // Use the score to determine the advice text
            string adviceText = GetAdviceText(score); // Implement GetAdviceText method to return advice based on the score

            ViewBag.AdviceText = adviceText; // Pass the advice text to the view using ViewBag

            return View();
        }

        private string GetAdviceText(double score)
        {
            if (score < 0.3)
                return "<strong>Current Situation:</strong><br/><br/> At present, the prevailing meteorological and hydrological assessments indicate a significantly low risk of drought in our region. Factors such as recent precipitation levels, groundwater recharge rates, and reservoir capacities all point towards a stable water supply situation for the foreseeable future. This favorable outlook alleviates immediate concerns regarding water scarcity and drought-related impacts.<br/><br/><strong>Advice for Individuals to Deal with the Situation:</strong><br/><br/>Water Conservation: While the risk of drought is low, it's always beneficial to practice water conservation habits. Simple actions such as fixing leaky faucets, using water-saving appliances, and reducing unnecessary water usage can contribute to long-term water sustainability.<br/>Smart Irrigation: For those with gardens or lawns, consider implementing smart irrigation systems that adjust watering schedules based on real-time weather data. This ensures efficient water usage and minimizes runoff.<br/>Rainwater Harvesting: Take advantage of rainy days by setting up rain barrels or cisterns to collect rainwater for outdoor tasks like watering plants or washing vehicles. This reduces reliance on treated water for non-potable purposes.<br/>Native Plants: Opt for native plants in landscaping projects, as they are better adapted to local climatic conditions and require less water compared to exotic species. This promotes biodiversity while conserving water resources.<br/>Mulching: Apply mulch around plants and garden beds to retain soil moisture, suppress weed growth, and reduce the need for frequent watering. Organic mulches also improve soil health over time.<br/>Education and Awareness: Stay informed about water conservation practices through local government initiatives, environmental organizations, or online resources. Share knowledge and encourage others in your community to adopt sustainable water habits.<br/>Efficient Appliances: Upgrade to energy-efficient appliances, such as low-flow showerheads, toilets, and washing machines, which not only save water but also reduce energy consumption and utility costs.<br/>Report Leaks: Promptly report any water leaks or infrastructure issues to relevant authorities for swift repairs. Timely maintenance helps prevent water wastage and ensures efficient water distribution.<br/>Community Involvement: Engage in community efforts focused on water conservation, such as participating in river clean-up events, supporting water-saving initiatives, or joining neighborhood conservation groups.<br/>Long-term Planning: Consider long-term planning for water sustainability, such as installing greywater recycling systems, exploring xeriscaping options, or advocating for sustainable water policies at the local level.";
            else if (score >= 0.3 && score < 0.6)
                return "<strong>Current Situation:</strong><br/> <br/>The latest assessments indicate a moderate risk of drought in our region in the foreseeable future. While this doesn't signify an imminent crisis, it does necessitate a heightened level of awareness and preparedness regarding water usage and conservation. Factors such as below-average precipitation, increased water demand, and potential fluctuations in reservoir levels contribute to this moderate risk assessment.<br/><br/><strong>Advice for Individuals to Deal with the Situation:</strong><br/><br/>Water Audit: Conduct a water audit at home to identify areas where water is being used inefficiently. This can include checking for leaks, optimizing irrigation systems, and assessing water consumption habits.<br/>Efficient Appliances: Upgrade to water-efficient appliances and fixtures, such as low-flow toilets, faucets, and showerheads. These upgrades can significantly reduce water usage without compromising functionality.<br/>Outdoor Watering Practices: Adjust outdoor watering schedules to align with local watering guidelines and weather conditions. Consider using drip irrigation or soaker hoses for targeted watering and mulching to retain soil moisture.<br/>Rainwater Harvesting: Install rain barrels or cisterns to capture rainwater for outdoor use, such as watering plants or washing vehicles. This reduces reliance on treated water for non-potable purposes.<br/>Greywater Recycling: Explore options for greywater recycling systems to reuse water from activities like laundry or dishwashing for irrigation purposes. Ensure compliance with local regulations and safety guidelines.<br/>Native Landscaping: Opt for native plants in landscaping projects, as they require less water and are better adapted to local climatic conditions. Incorporate drought-tolerant species to reduce water demand.<br/>Education and Outreach: Educate yourself and others in your community about water conservation practices, local water resources, and the importance of sustainable water management. Engage in outreach activities to promote awareness.<br/>Community Collaboration: Collaborate with neighbors, community groups, and local authorities to implement water-saving initiatives, share resources, and collectively address water conservation challenges.<br/>Monitoring and Adjustments: Regularly monitor water usage, check for leaks, and make necessary adjustments to irrigation schedules based on seasonal changes and weather forecasts. Stay proactive in conserving water resources.";
            else if (score >= 0.6 && score < 0.8)
                return "<strong>Current Situation:</strong><br/> <br/>The latest assessments indicate a high risk of drought in our region, necessitating urgent action and heightened vigilance regarding water management. Factors such as prolonged dry spells, reduced precipitation levels, and stressed water sources contribute to this heightened risk, highlighting the critical need for implementing water-saving practices at all levels.<br/><br/><strong>Advice for Individuals to Deal with the Situation:</strong><br/><br/>Immediate Water Audit: Conduct a thorough water audit at home, identifying and addressing any sources of water wastage or inefficiency. This includes checking for leaks, optimizing appliance usage, and minimizing unnecessary water consumption.<br/>Conservation-Minded Appliances: Upgrade to water-efficient appliances and fixtures, prioritizing models with high Energy Star ratings and water-saving features. This includes toilets, faucets, showerheads, dishwashers, and washing machines.<br/>Outdoor Water Management: Implement strict water management practices for outdoor areas, such as reducing lawn irrigation, using drought-resistant plants, mulching garden beds, and capturing rainwater for gardening purposes.<br/>Greywater Recycling: Consider installing a greywater recycling system to reuse water from activities like laundry and bathing for non-potable uses such as toilet flushing or outdoor irrigation.<br/>Educational Outreach: Educate yourself and others in your community about the severity of the drought risk, the importance of water conservation, and practical steps individuals can take to reduce water usage.<br/>Behavioral Changes: Adopt water-saving habits in daily routines, such as taking shorter showers, turning off taps when not in use, using a broom instead of a hose for outdoor cleaning, and fixing leaks promptly.<br/>Community Collaboration: Collaborate with neighbors, community organizations, and local authorities to implement community-wide water-saving initiatives, share resources, and support drought response efforts.<br/>Monitoring and Reporting: Regularly monitor water usage, conduct periodic checks for leaks, and report any water-related issues to relevant authorities for swift action and resolution.<br/>Emergency Preparedness: Develop and review emergency water conservation plans for your household, including water storage options, alternative water sources, and contingency measures in case of severe water shortages.<br/>Advocacy and Policy Support: Advocate for immediate and decisive action on water conservation at the community and regional levels. Support and engage with policymakers to implement sustainable water management policies and prioritize drought resilience efforts.";
            else
                return "<strong>Current Situation:</strong><br/><br/> The current assessment indicates an extremely high risk of drought in our region, requiring immediate and decisive action to conserve water resources. Factors such as prolonged dry conditions, critically low reservoir levels, and increased water demand underscore the urgency of implementing robust water-saving measures across all sectors.<br/><br/><strong>Advice for Individuals to Deal with the Situation:</strong><br/><br/>Emergency Water Audit: Conduct an emergency water audit at your property, identifying and addressing any sources of water wastage or inefficiency. Actively seek and fix leaks, optimize appliance usage, and minimize all non-essential water consumption immediately.<br/>Retrofit with Water-Efficient Appliances: Upgrade to high-efficiency appliances and fixtures, prioritizing those with WaterSense or similar certifications. This includes toilets, faucets, showerheads, dishwashers, and washing machines.<br/>Drastic Outdoor Water Conservation: Cease all non-essential outdoor water use, including lawn irrigation and washing vehicles. Implement strict water management practices such as mulching, using drought-resistant plants, and capturing rainwater for essential outdoor tasks.<br/>Greywater Recycling and Reuse: Install or activate greywater recycling systems to reuse water from activities like laundry, bathing, and dishwashing for non-potable purposes such as toilet flushing or outdoor irrigation.<br/>Educational Outreach and Community Mobilization: Educate yourself and others in your community about the severity of the drought risk and the urgent need for water conservation. Mobilize community efforts to implement water-saving initiatives, share resources, and support drought response measures.<br/>Behavioral Changes: Adopt stringent water-saving habits immediately, including taking shorter showers, turning off taps when not in use, using a broom instead of a hose for outdoor cleaning, and fixing leaks urgently.<br/>Emergency Water Storage: Consider emergency water storage options such as large containers or tanks for storing potable water. Ensure these containers are properly maintained and filled in anticipation of potential water supply disruptions.<br/>Report and Address Water Issues: Report any water-related issues, including leaks, burst pipes, or unauthorized water use, to relevant authorities promptly. Encourage others to do the same for swift action and resolution.<br/>Emergency Response Planning: Develop and review emergency water conservation and response plans for your household, including prioritized water usage, alternative water sources, and contingency measures for severe water shortages.<br/>Advocacy and Policy Support: Advocate for immediate and decisive action on water conservation at the community and regional levels. Support and engage with policymakers to implement sustainable water management policies and prioritize drought resilience efforts.";
        }

    }
}