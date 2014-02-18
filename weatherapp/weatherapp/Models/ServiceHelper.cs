using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using weatherapp.Models.Repository;
using weatherapp.Models.Webservices;

namespace weatherapp.Models
{
    public class ServiceHelper
    {
        //represents the number of days for the forecast
        private const int NoPosts = 5;
        //EF repository
        private IRepository _repository;
        //Yr.no weather data webservice
        private YynoWebservice YrAPI;
        //Geonames webservice
        private Geonamesservicecs GeoAPI;
        //list containing the 5 day forecast
        private List<Weather> SelectedWeathers;
        //list containing unsorted weather data
        private List<Weather> ApiWeather;

        //get forecasts
        public List<Weather> getForecast(string city)
        {
            //get the position from user input
            var pos = getPosition(city);
            //initiate forecasts
            initiateForecasts(pos);
            //return the selected 5 day forecasts
            return SelectedWeathers;
        }
        //get user input position
        private Position getPosition(string city)
        {
            //get all cities from database
            var pos = _repository.GetPosition().ToList();
            //unassigned Position
            Position enteredCity;

            //if there are one or more city
            if (pos.Count >= 1)
            {
                //get only one city and assign it to enteredCity
                enteredCity = pos.Find(c => c.Name == city);                
            }
            //if there aren't any cities
            else
            {
                //get position from webservice
                var geoPos = getAPIPosition(city);
                //get the id from the new pos in the database
                var newId = _repository.AddPos(geoPos);
                //assign the new id to the current pos
                geoPos.id = newId;
                //return the pos
                return geoPos;
            }
            //make sure enteredCity is not null before returning it
            if (enteredCity != null)
            {
                return enteredCity;
            }
            //if it happends to be null reassign and return it
            else
            {
                //get position from webservice
                var geoPos = getAPIPosition(city);
                //get the id from the new pos in the database
                var newId = _repository.AddPos(geoPos);
                //assign the new id to the current pos
                geoPos.id = newId;
                //return the pos
                return geoPos;
            }
        }
        //get position from webservice
        private Position getAPIPosition(string city)
        {
            //get and return geoposition from webservice
            return GeoAPI.GetGeoName(city);
        }
        //initiate member variables
        private void initiateForecasts(Position pos)
        {            
            //get weather from database
            ApiWeather = getAPIWeather();
            //initiate a list with X number of positions
            SelectedWeathers = new List<Weather>(NoPosts);
            //filter out unwanted weathers
            filterWeathers(pos.Name);
            //if selected list has any weathers
            if (SelectedWeathers.Any())
            {
                //does the weather require an update
                if (SelectedWeathers.First().NextUpdate <= DateTime.Now)
                {
                    //reload the weathers from the webservice
                    reloadWeathers(pos.Name, pos);
                }
            }
            //if there aren't any selected weathers
            else
            {
                //get weather from webservice
                foreach (var item in getAPIWeather(pos))
                {
                    //set the foreign key
                    item.PositionId = pos.id;
                    //save the weather to the database
                    _repository.AddWeather(item);
                    //save EF changes
                    _repository.Save();
                    //add the weather to ApiWeather list
                    ApiWeather.Add(item);
                }
                //make sure we only have the weathers we want
                filterWeathers(pos.Name);
            }                        
        }
        //if cache is out of date..
        private void reloadWeathers(string city, Position pos)
        {
            //delete all weathers that matches user input
            _repository.Delete(SelectedWeathers[0]);
            //save EF changes
            _repository.Save();
            //clear lists containing weathers
            SelectedWeathers.Clear();
            ApiWeather.Clear();
            //get new weather data from YR.no webservice
            ApiWeather = getAPIWeather(pos);
            //filter out wanted 5 day forecast
            filterWeathers(city);
            //for each item in SelectedWeathers...
            foreach (var item in SelectedWeathers)
            {
                //assign FK position id
                item.PositionId = pos.id;
                //then add weather to data entity
                _repository.AddWeather(item);
                //and save changes
                _repository.Save();
            }
        }
        //filter out unwanted weathers
        private void filterWeathers(string city)
        {   
            //for each item in ApiWeather list
            foreach (var item in this.ApiWeather)
            {
                //if posted city matches city in cache and the selectedWeathers list contains less than 5 
                if (item.City == city && SelectedWeathers.Count < NoPosts)
                {
                    //add to selected Weathers
                    SelectedWeathers.Add(item);
                }
            }
        }
        //get weather from YR.no webservice
        private List<Weather> getAPIWeather(Position pos)
        {
            return YrAPI.GetFiveDays(pos);
        }
        //get weather from database
        private List<Weather> getAPIWeather()
        {
            return _repository.GetWeather().ToList();
        }
        //initiate webservices
        public ServiceHelper(IRepository repo)
        {
            _repository = repo;
            YrAPI = new YynoWebservice();
            GeoAPI = new Geonamesservicecs();
        }
    }
}