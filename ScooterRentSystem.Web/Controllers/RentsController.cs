using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScooterRentSystem.BLL.Abstractions;
using ScooterRentSystem.Web.Models.ViewModels.Person;
using ScooterRentSystem.Web.Models.ViewModels.Rent;
using ScooterRentSystem.Web.Models.ViewModels.Scooter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Controllers
{
    public class RentsController : Controller
    {
        private readonly IRentService _rentService;
        private readonly IScooterService _scooterService;
        private readonly IPersonService _personService;

        public RentsController(IRentService rentService, IScooterService scooterService, IPersonService personService)
        {
            _rentService = rentService;
            _scooterService = scooterService;
            _personService = personService;
        }
        // GET: RentsController
        public ActionResult Index()
        {
            List<RentViewModel> rents = _rentService.GetRents()
                .Select(item => new RentViewModel()
                {
                    Id = item.Id,
                    ScooterModel = item.Scooter.Model,
                    PersonFullName = item.Person.FirstName + " " + item.Person.LastName,
                    BeginTime = item.BeginTime,
                    EndTime = item.EndTime,
                    Price = item.Price,
                    CreatedAt = item.CreatedAt,
                    ModifiedAt = item.ModifiedAt
                })
                .ToList();
            return View(rents);
        }

        // GET: RentsController/Details/5
        public ActionResult Details(int id)
        {
            var item = _rentService.GetRentById(id);
            RentDetailsViewModel model = new RentDetailsViewModel()
            {
                Id = item.Id,
                ScooterModel = item.Scooter.Model,
                PersonFullName = item.Person.FirstName + " " + item.Person.LastName,
                BeginTime = item.BeginTime,
                EndTime = item.EndTime,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };
            return View(model);
        }

        // GET: RentsController/Create
        public ActionResult Create()
        {
            RentAddViewModel model = new RentAddViewModel();
            model.People = _personService.GetPeople()
                .Select(item => new PersonPairViewModel()
                {
                    Id = item.Id,
                    FullName = item.FirstName + " " + item.LastName
                })
                .ToList();
            model.Scooters = _scooterService.GetScooters()
                .Select(item => new ScooterPairViewModel()
                {
                    Id = item.Id,
                    ScooterLabel = item.Id + " " + item.Model
                })
                .ToList();

            return View(model);
        }

        // POST: RentsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] RentAddViewModel model)
        {
            var created = _rentService.StartRent(model.PersonId, model.ScooterId);

            if (created)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: RentsController/EndRent/5
        public ActionResult EndRent(int id)
        {
            var rent = _rentService.GetRentById(id);
            if (rent == null || rent.EndTime.HasValue)
            {
                return NotFound();
            }
            else
            {
                var ended = _rentService.EndRent(id);
                if (ended)
                {
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    return NotFound();
                }
            }
        }

        // GET: RentsController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _rentService.GetRentById(id);
            RentDetailsViewModel model = new RentDetailsViewModel()
            {
                Id = item.Id,
                ScooterModel = item.Scooter.Model,
                PersonFullName = item.Person.FirstName + " " + item.Person.LastName,
                BeginTime = item.BeginTime,
                EndTime = (DateTime)item.EndTime,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };
            return View(model);
        }

        // POST: RentsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _rentService.Remove(id);
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
