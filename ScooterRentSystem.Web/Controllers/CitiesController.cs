using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScooterRentSystem.BLL.Abstractions;
using ScooterRentSystem.Web.Models.ViewModels.City;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Controllers
{
    public class CitiesController : Controller
    {
        private readonly ICityService _cityService;
        public CitiesController(ICityService cityService)
        {
            _cityService = cityService;
        }

        // GET: CitiesController
        public ActionResult Index()
        {
            //TODO: research on Automapper
            List<CityViewModel> cities = _cityService.GetCities()
                .Select(item => new CityViewModel()
                {
                    Id = item.Id,
                    Name = item.Name,
                    GpsPosition = item.GpsPosition,
                    PeopleCount = item.People.Count,
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                })
                .ToList();
            return View(cities);
        }

        // GET: CitiesController/Details/5
        public ActionResult Details(int id)
        {
            var item = _cityService.GetCityById(id);

            CityDetailsViewModel model = new CityDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                GpsPosition = item.GpsPosition,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };

            return View(model);
        }

        // GET: CitiesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CitiesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] CityAddViewModel model)
        {
            var created = _cityService.CreateCity(model.Name, model.GpsPosition);

            if (created)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CitiesController/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _cityService.GetCityById(id);
            if (entity == null)
            {
                return NotFound();
            }

            CityEditViewModel model = new CityEditViewModel()
            {
                Id = entity.Id,
                Name = entity.Name,
                GpsPosition = entity.GpsPosition
            };

            return View(model);
        }

        // POST: CitiesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] CityEditViewModel model)
        {
            var updated = _cityService.UpdateCity(id, model.Name, model.GpsPosition);

            if (updated)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: CitiesController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _cityService.GetCityById(id);

            CityDetailsViewModel model = new CityDetailsViewModel()
            {
                Id = item.Id,
                Name = item.Name,
                GpsPosition = item.GpsPosition,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };

            return View(model);
        }

        // POST: CitiesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _cityService.Remove(id);
            if (deleted)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }
    }
}
