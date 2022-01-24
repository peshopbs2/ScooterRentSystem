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
    public class RentService : IRentService
    {
        private readonly IRepository<Rent> _rentRepository;
        public RentService(IRepository<Rent> rentRepository)
        {
            _rentRepository = rentRepository;
        }

        public bool EndRent(int rentId)
        {
            var rent = _rentRepository.GetById(rentId);
            rent.EndTime = DateTime.Now;
            return _rentRepository.Update(rent);
        }

        public Rent GetRentById(int rentId)
        {
            return _rentRepository.GetById(rentId);
        }

        public List<Rent> GetRents()
        {
            return _rentRepository.GetAll();
        }

        public bool Remove(int rentId)
        {
            return _rentRepository.RemoveById(rentId);
        }

        public bool StartRent(int personId, int scooterId)
        {
            Rent rent = new Rent()
            {
                PersonId = personId,
                ScooterId = scooterId,
                BeginTime = DateTime.Now,
                EndTime = null
            };
            return _rentRepository.Create(rent);
        }
    }
}
