using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ScooterRentSystem.BLL.Abstractions;
using ScooterRentSystem.DAL.Entities;
using ScooterRentSystem.Web.Models.ViewModels.Rent;
using ScooterRentSystem.Web.Models.ViewModels.Scooter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Controllers
{
    public class ScootersController : Controller
    {
        private readonly IScooterService _scooterService;
        public ScootersController(IScooterService scooterService)
        {
            _scooterService = scooterService;
        }

        // GET: ScootersController
        public ActionResult Index()
        {
            List<ScooterViewModel> scooters = _scooterService.GetScooters()
                           .Select(item => new ScooterViewModel()
                           {
                               Id = item.Id,
                               ModelNumber = item.Model,
                               GpsPosition = item.GpsPosition,
                               IsTaken = item.IsTaken,
                               Rate = item.Rate,
                               RentCount = item.Rents.Count,
                               CreatedAt = item.CreatedAt,
                               ModifiedAt = item.ModifiedAt
                           })
                           .ToList();
            return View(scooters);
        }

        // GET: ScootersController/Details/5
        public ActionResult Details(int id)
        {
            var item = _scooterService.GetScooterById(id);
            if(item==null)
            {
                return NotFound();
            }
            ScooterDetailsViewModel model = new ScooterDetailsViewModel()
            {
                Id = item.Id,
                ModelNumber = item.Model,
                GpsPosition = item.GpsPosition,
                IsTaken = item.IsTaken,
                Rate = item.Rate,
                RentCount = item.Rents.Count,
                Rents = item.Rents
                .Select(rent => new RentViewModel()
                {
                    Id = rent.Id,
                    ScooterModel = rent.Scooter.Model,
                    PersonFullName = rent.Person.FirstName + " " + rent.Person.LastName,
                    Price = rent.Price,
                    BeginTime = rent.BeginTime,
                    EndTime = rent.EndTime,
                    CreatedAt = rent.CreatedAt,
                    ModifiedAt = rent.ModifiedAt
                }).ToList(),
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };

            return View(model);
        }

        // GET: ScootersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ScootersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([FromForm] ScooterAddViewModel model)
        {
            var created = _scooterService.CreateScooter(
                model.ModelNumber, model.GpsPosition, model.Rate
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

        // GET: ScootersController/Edit/5
        public ActionResult Edit(int id)
        {
            var item = _scooterService.GetScooterById(id);
            if (item == null)
            {
                return NotFound();
            }
            ScooterEditViewModel model = new ScooterEditViewModel()
            {
                Id = item.Id,
                ModelNumber = item.Model,
                GpsPosition = item.GpsPosition,
                Rate = item.Rate,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };

            return View(model);
        }

        // POST: ScootersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, [FromForm] ScooterEditViewModel model)
        {
            var updated = _scooterService.UpdateScooter(id, model.ModelNumber, model.GpsPosition, model.Rate);

            if(updated)
            {
                return RedirectToAction(nameof(Index));
            }
            else
            {
                return View();
            }
        }

        // GET: ScootersController/Delete/5
        public ActionResult Delete(int id)
        {
            var item = _scooterService.GetScooterById(id);
            if (item == null)
            {
                return NotFound();
            }
            ScooterDetailsViewModel model = new ScooterDetailsViewModel()
            {
                Id = item.Id,
                ModelNumber = item.Model,
                GpsPosition = item.GpsPosition,
                IsTaken = item.IsTaken,
                Rate = item.Rate,
                RentCount = item.Rents.Count,
                CreatedAt = item.CreatedAt,
                ModifiedAt = item.ModifiedAt
            };

            return View(model);
        }

        // POST: ScootersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var deleted = _scooterService.Remove(id);
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
