using ScooterRentSystem.BLL.Abstractions;
using ScooterRentSystem.DAL.Abstractions;
using ScooterRentSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentSystem.BLL.Services
{
    public class ScooterService : IScooterService
    {
        private readonly IRepository<Scooter> _scooterRepository;
        public ScooterService(IRepository<Scooter> scooterRepository)
        {
            _scooterRepository = scooterRepository;
        }

        public bool CreateScooter(string model, string gpsPosition, decimal rate)
        {
            var scooter = new Scooter()
            {
                Model = model,
                GpsPosition = gpsPosition,
                Rate = rate
            };
            return _scooterRepository.Create(scooter);
        }

        public List<Rent> GetRentsByScooterId(int scooterId)
        {
            return _scooterRepository
                .GetById(scooterId)
                .Rents
                .ToList();
        }

        public Scooter GetScooterById(int scooterId)
        {
            return _scooterRepository
                .GetById(scooterId);
        }

        public List<Scooter> GetScooters()
        {
            return _scooterRepository.GetAll();
        }

        public bool Remove(int scooterId)
        {
            return _scooterRepository.RemoveById(scooterId);
        }

        public bool UpdateScooter(int scooterId, string model, string gpsPosition, decimal rate)
        {
            var scooter = _scooterRepository.GetById(scooterId);
            scooter.Model = model;
            scooter.GpsPosition = gpsPosition;
            scooter.Rate = rate;
            return _scooterRepository.Update(scooter);
        }
    }
}
