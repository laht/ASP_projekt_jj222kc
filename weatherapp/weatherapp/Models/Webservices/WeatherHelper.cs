using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;

namespace weatherapp.Models.Webservices
{
    //helper class to match symbols with forecasts
    public class WeatherHelper
    {
        //value representing numerical Temperature or Symbol
        public double Value { get; set; }
        //DateTime for the forecast date the tempereature or symbol represents
        public DateTime Time { get; set; }

        //take string values and convert them to their respective datatype
        public WeatherHelper(string value, string time)
        {
            Time = DateTime.Parse(time);
            Value = double.Parse(value, CultureInfo.InvariantCulture);
        }
    }
}