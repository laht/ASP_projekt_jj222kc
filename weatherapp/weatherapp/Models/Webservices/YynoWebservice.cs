using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Xml;
using System.Xml.Linq;
using weatherapp.Models;


namespace weatherapp.Models.Webservices
{
    public class YynoWebservice
    {
        protected List<Weather> Weather;
             
        //get forecast for the next  five days
        public List<Weather> GetFiveDays(Position pos)
        {
            //list with weather objects representing a five day forecast
            var fiveDays = new List<Weather>(5);
            var weathers = GetWeather(pos);
            var invalidDays = new List<int>();
            
            //foreach post in weathers...
            foreach (var item in weathers)
            {
                //allow 5 posts
                if (fiveDays.Count < 5)
                {
                    //make sure there aren't any duplicate days
                    var validDay = DateTime.Now.AddDays(fiveDays.Count).Day;
                    //if the hour is set to 13 and the day is valid
                    if (item.ValidTime.Hour == 13 && !invalidDays.Contains(item.ValidTime.Day))
                    {
                        //add the item to the 5 days forecast list
                        fiveDays.Add(item);

                        invalidDays.Add(item.ValidTime.Day);
                    }
                    //else if the hour is 19 and the day is valid
                    else if (item.ValidTime.Hour == 19 && !invalidDays.Contains(item.ValidTime.Day))
                    {
                        //add the item to the forecast list
                        fiveDays.Add(item);

                        invalidDays.Add(item.ValidTime.Day);
                    }
                }
            }

            //return the five day forecast list
            return fiveDays;
        }
        //load data from yr.no API
        private List<Weather> GetWeather(Position pos)
        {
            try
            {
                //list representing all weather forecasts from the API
                Weather = new List<Weather>();
                //requeststring to call the API
                var requestString = String.Format("http://api.yr.no/weatherapi/locationforecast/1.8/?lat={0};lon={1}",
                                                     pos.Lat.ToString().Replace(",", "."), pos.Lng.ToString().Replace(",", "."));
                //xDocument to hold the XML provided by yr.no API
                var xdoc = XDocument.Load(requestString);
                //list containing one list with temperatures and one list with symbols, both with matching times
                var helper = extractXML(xdoc);

                //foreach temperature in helper[0]
                foreach (var temps in helper[0])
                {
                    //and foreach symbol in helper[1]
                    foreach (var symbols in helper[1])
                    {
                        //if the temp time and symbol time match...
                        if (temps.Time == symbols.Time)
                        {
                            //convert the symbol to int
                            var symbolInInt = Convert.ToInt32(symbols.Value);
                            //add a weather object to the weather list
                            Weather.Add(new Weather { 
                                City = pos.Name, 
                                Id = pos.id, 
                                NextUpdate = DateTime.Now.AddDays(1),
                                Symbol = short.Parse(symbolInInt.ToString()),
                                Temperature = temps.Value,
                                ValidTime = temps.Time,                                
                            });
                        }
                    }
                }
                //return the list with weather objects
                return Weather;
            }
            catch (Exception)
            {
                throw new ApplicationException("Det gick inte att hämta någon väderdata");
            }

            
        }
        //parse the xml from yr.no
        private List<List<WeatherHelper>> extractXML(XDocument xdoc)
        {
            //from the xDocument select the descendants "product" 
            //which holds the element Time and create a list
            var times = (from t in xdoc.Descendants("product").Elements("time") select t).ToList();

            //list to hold temperatures with datetime
            var temps = new List<WeatherHelper>();
            //list to hold symbols with datetime
            var symbols = new List<WeatherHelper>();
            //foreach
            foreach (var item in times)
            {
                //individual time for a forecast 
                var timeFrom = (string)item.Attribute("from").Value;
                //if there are any elements under location called temperature...
                if (item.Elements("location").Elements("temperature").Any())
                {                    
                    //grab the value of the temperature in location and...
                    var temp = (string)item.Element("location").Element("temperature").Attribute("value").Value;
                    //create helper object with temperature value and time
                    temps.Add(new WeatherHelper(temp, timeFrom));
                }
                //else if there are any symbol elements under location
                else if (item.Elements("location").Elements("symbol").Any())
                {
                    //get the value of the symbol in location and...
                    var symbol = (string)item.Element("location").Element("symbol").Attribute("number").Value;
                    //create helper object with symbol value and time
                    symbols.Add(new WeatherHelper(symbol, timeFrom));
                }
            }
            //list to contain the helper lists
            var container = new List<List<WeatherHelper>>();
            //add the temps helper list
            container.Add(temps);
            //add the symbols helper list
            container.Add(symbols);
            //return the container helper list
            return container;
        }
    }
}