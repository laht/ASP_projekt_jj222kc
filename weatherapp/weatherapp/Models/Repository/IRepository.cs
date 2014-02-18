using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace weatherapp.Models.Repository
{
    public interface IRepository : IDisposable
    {
        int AddPos(Position Position);

        void AddWeather(Weather weather);

        void Delete(Weather weather);

        IQueryable<Weather> GetWeather();

        IQueryable<Position> GetPosition();

        void Save();

        void Update(Weather Weather);
    }
}
