using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Xml.Linq;
using System.Xml;
using System.Globalization;

namespace weatherapp.Models.Webservices
{
    public class Geonamesservicecs
    {
        public Position GetGeoName(string city)
        {
            //requeststring to get info about the input city
            var requestString = String.Format("http://api.geonames.org/search?name_equals={0}&country=Se&maxRows=1&username=laht", city);            
            try
            {
                //xDocument to hold the XML provided by geoname API
                var xdoc = XDocument.Load(requestString);
                //create list containing a Position with the geoname result
                var location = (from l in xdoc.Descendants("geoname")
                                select new Position
                                {
                                    id = int.Parse(l.Element("geonameId").Value),
                                    Name = l.Element("name").Value,
                                    Lat = double.Parse(l.Element("lat").Value, CultureInfo.InvariantCulture),
                                    Lng = double.Parse(l.Element("lng").Value, CultureInfo.InvariantCulture)
                                }).ToList();
                //list with position object
                var geoLoc = location[0];
                //return the geoLoc object
                return geoLoc;
            }
            catch (Exception)
            {
                throw new ApplicationException("Det gick inte att hämta en plats med det namnet");
            }
            

            
        }
    }
}