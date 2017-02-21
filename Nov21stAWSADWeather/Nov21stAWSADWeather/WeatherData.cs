using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Nov21stAWSADWeather
{
    public class WeatherData
    {
        public string temp_c { get; set; }
        public string text { get; set; }
        public string icon { get; set; }
        public string wind_kph { get; set; }
        public string wind_dir { get; set; }
        public string humidity { get; set; }
        public string feelslike_c { get; set; }
        public string city { get; set; }
    }
}
