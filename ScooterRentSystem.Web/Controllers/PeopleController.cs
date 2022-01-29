using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScooterRentSystem.BLL.Abstractions;
using ScooterRentSystem.Web.Models.ViewModels.City;
using ScooterRentSystem.Web.Models.ViewModels.Person;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Controllers
{
    public class PeopleController : Controller
    {
        private readonly IPersonService _personService;
        private readonly ICityService _cityService;
        public PeopleController(IPersonService personService, ICityService cityService)
        {
            _personService = personService;
            _cityService = cityService;
        }
        // GET: PeopleController
        public ActionResult Index()
        {
            List<PersonViewModel> people = _personService.GetPeople()
                .Select(item => new PersonViewModel()
                {
                    Id = item.Id,
                    FirstName = item.FirstName,
                    LastName = item.LastName,
                    Balance = item.Balance,
                    CityName = item.City.Name,
                    Phone = item.Phone,
                    RentsCount = item.Rents.Count,
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                })
                .ToList();
            return View(people);
        }

        // GET: PeopleController/Details/5
        public ActionResult Details(int id)
        {
            var item = _personService.GetPersonById(id);
            if (item == null)
            {
                return NotFound();
            }
            PersonDetailsViewModel model = new PersonDetailsViewModel()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Balance = item.Balance,
                Phone = item.Phone,
                CityName = item.City.Name,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };

            return View(model);
        }

        // GET: PeopleController/Create
        public ActionResult Create()
        {
            var model = new PersonAddViewModel();
            model.Cities = _cityService.GetCities()
                .Select(item => new CityPairViewModel()
                {
                    Id = item.Id,
                    Name = item.Name
                })
                .ToList();
            return View(model);
        }

        // POST: PeopleController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] PersonAddViewModel model)
        {
            var created = _personService.CreatePerson(
                model.FirstName, model.LastName, model.Phone, model.Balance,
                model.CityId
            );

            if (created)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: PeopleController/Edit/5
        public ActionResult Edit(int id)
        {
            var entity = _personService.GetPersonById(id);
            if (entity == null)
            {
                return NotFound();
            }

            PersonEditViewModel model = new PersonEditViewModel()
            {
                Id = entity.Id,
                FirstName = entity.FirstName,
                LastName = entity.LastName,
                Balance = entity.Balance,
                Phone = entity.Phone,
                CityId = entity.CityId,
                CreatedAt = entity.CreatedAt,
                ModifiedAt = entity.ModifiedAt
            };
            model.Cities = _cityService.GetCities()
               .Select(item => new CityPairViewModel()
               {
                   Id = item.Id,
                   Name = item.Name
               })
               .ToList();

            return View(model);
        }

        // POST: PeopleController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] PersonEditViewModel model)
        {
            var updated = _personService.UpdatePerson(
                id, model.FirstName, model.LastName, model.Phone, model.Balance, model.CityId);

            if (updated)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: PeopleController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _personService.GetPersonById(id);
            if (item == null)
            {
                return NotFound();
            }
            PersonDetailsViewModel model = new PersonDetailsViewModel()
            {
                Id = item.Id,
                FirstName = item.FirstName,
                LastName = item.LastName,
                Balance = item.Balance,
                Phone = item.Phone,
                CityName = item.City.Name,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };

            return View(model);
        }

        // POST: PeopleController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _personService.Remove(id);
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
