using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace weatherapp.Models.Repository
{
    public class WeatherRepository : IRepository
    {
        private bool _disposed = false;
        //mssql database with EF
        private WP12_jj222kc_weatherAppEntities _entities = new WP12_jj222kc_weatherAppEntities();

        #region IDisposable
        public void Dispose()
        {
            Dispose(true);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _entities.Dispose();
                }
            }
            _disposed = true;
        }
        #endregion

        //add position object to database
        public int AddPos(Position Position)
        {
            var newId = _entities.uspAddPosition(Position.Name, Position.Lat, Position.Lng);
            return Convert.ToInt32(newId.FirstOrDefault().Value);
        }
        //add weather object to database
        public void AddWeather(Weather weather)
        {
            _entities.uspAddWeather(weather.Temperature, 
                                    weather.ValidTime, 
                                    weather.City, 
                                    weather.Symbol, 
                                    weather.PositionId, 
                                    weather.NextUpdate);
        }
        //delete weather from database
        public void Delete(Weather weather)
        {
            _entities.uspRemoveWeather(weather.PositionId);
        }
        //get all weathers from database
        public IQueryable<Weather> GetWeather()
        {
            return _entities.Weathers.AsQueryable();
        }
        //get all positions from database
        public IQueryable<Position> GetPosition()
        {
            return _entities.Positions.AsQueryable();
        }
        //save changes to database
        public void Save()
        {
            _entities.SaveChanges();
        }
        //update weather in database
        public void Update(Weather Weather)
        {
            _entities.uspUpdateWeather(Weather.Id, 
                                       Weather.Temperature,
                                       Weather.City, 
                                       Weather.Symbol, 
                                       Weather.PositionId, 
                                       Weather.ValidTime, 
                                       Weather.NextUpdate);
        }
    }
}