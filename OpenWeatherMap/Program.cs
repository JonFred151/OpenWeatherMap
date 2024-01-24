using Newtonsoft.Json.Linq;
using System;
using System.Diagnostics.Metrics;
using System.Net.NetworkInformation;
using System.Runtime.InteropServices.JavaScript;

namespace OpenWeatherMap 
{
   class Program
    {
        static void Main(string[] args)
        {
           var client = new HttpClient();

            var key = "cea7abffefb4efe410397cee401d0834";            
            while (true)
            {
                Console.WriteLine("Enter a city");
                var city = Console.ReadLine();
                Console.WriteLine("---------------");
                var weatherURL = $"https://api.openweathermap.org/data/2.5/weather?q={city}&appid={key}&units=imperial";
                try
                {
                    var response = client.GetStringAsync(weatherURL).Result;
                    var formattedResponseTemp = JObject.Parse(response).GetValue("main").ToString();
                    Console.WriteLine($"The Current Temparture is {JObject.Parse(formattedResponseTemp).GetValue("temp")} degrees");
                }
                catch (Exception ex)
                {
                    Console.Write(ex.Message);
                }
               
                 
               

                Console.WriteLine("");
                Console.WriteLine("Would you like to close the program?");
                var userInput = Console.ReadLine();

                if(userInput.ToLower().Trim() == "yes")
                {
                    break;
                }
                Console.Clear();
            }
          


        }
    } 
}
