using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using weatherapp.Models;
using weatherapp.Models.Webservices;
using weatherapp.ViewModels;
using weatherapp.Models.Repository;
using weatherapp.Infrastructure;

namespace weatherapp.Controllers
{
    public class WeatherController : Controller
    {

        private IRepository _repository;

        //Dependency injected constructors
        public WeatherController()
            : this(new WeatherRepository())
        {
            //empty
        }
        public WeatherController(IRepository repository)
        {
            _repository = repository;
        }
        
        //
        // GET: /Weather/
        [HttpGet]
        public ActionResult Index()
        {            
            return View();
        }

        [HttpPost]
        public ActionResult Index(CityPost CityPost)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction("ShowWeather", CityPost);    
            }
            return View();
        }

        public ActionResult ShowWeather(CityPost city)
        {
            //try to...
            try
            {
                //initiate the webservice helper with the _repository entity
                var serviceHelper = new ServiceHelper(_repository);
                //from the service helper get the forecasts by name of city
                var weathers = serviceHelper.getForecast(city.CityName);
                //then return the view ShowWeather with the forecasts as model
                return View("ShowWeather", weathers);
            }
            //catch 
            catch (Exception e)
            {
                //add model error
                ModelState.AddModelError("Det gick inte att hitta någon plats det namnet", e.Message);
                //return index with the search object as model
                return View("Index", city);
            } 
        }
    }
}
