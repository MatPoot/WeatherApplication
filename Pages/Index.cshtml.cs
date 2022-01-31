using JamboApplication.Classes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;
        [BindProperty(SupportsGet = true)]
        public List<City> OutputCities { get; set; }
        [BindProperty(SupportsGet = true)]
        public string CityHTML { get; set; }
        [BindProperty(SupportsGet = true)]
        public string ButtonHTML { get; set; }

        



        public List<string> CityList = new List<string>();
        public List<string> DescList = new List<string>();



        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // on page load create an object to load the city data into and fetch from CityClass using a CityClass object
            CityClass Aoperation = new CityClass();
            List<City> OutputCities = Aoperation.FetchCities();
            if (OutputCities == null)
            {
                
                throw new Exception("No Cities Found");
            }
            else
            {
                

                // create elements and inject values to create labels and buttons on the view
                foreach (var city in OutputCities)
                {

                    CityHTML = "<p>" + city.Name + "</p>" + CityHTML;
                    ButtonHTML = "<button id=" + city.Name + " onclick=GetWeatherNow(\"" + city.Name + "\",\'" + city.Label + "\')" + " type=\"button\">" + city.Name + "</button></br> " + ButtonHTML;
                }

                // should be making <button id="London" onclick=GetWeatherNow("London","Test City Label.")+ type="button">London</button></br>
                // this CityHTML and ButtonHTML gets passed over to the view theough the [BindProperty(SupportsGet = true)] parameter in their decleration above


            }

        }
        
    }
}
