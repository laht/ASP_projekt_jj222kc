using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using weatherapp.Models.Repository;

namespace weatherapp.Controllers
{
    public class GeoNamesController : ApiController
    {

        private IRepository _repository;

        //Dependency injected constructors
        public GeoNamesController()
            : this(new WeatherRepository())
        {
            //empty
        }
        public GeoNamesController(IRepository repository)
        {
            _repository = repository;
        }

        // GET api/geonames
        public IEnumerable<string> Get(string term)
        {
            var test = _repository.GetPosition();
            var weathers = test
                .Where(t => t.Name.Contains(term))
                .Select(t => t.Name)
                .Distinct()
                .ToList();

            return weathers;
        }
    }
}
