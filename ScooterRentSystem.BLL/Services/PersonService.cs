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
    public class PersonService : IPersonService
    {
        private readonly IRepository<Person> _personRepository;
        private readonly IRepository<City> _cityRepository;
        public PersonService(IRepository<Person> personRepository,
            IRepository<City> cityRepository)
        {
            _personRepository = personRepository;
            _cityRepository = cityRepository;
        }

        public bool CreatePerson(string firstName, string lastName, string phone, decimal balance, int cityId)
        {
            var person = new Person()
            {
                FirstName = firstName,
                LastName = lastName,
                Phone = phone,
                Balance = balance,
                City = _cityRepository.GetById(cityId)
            };

            return _personRepository.Create(person);
        }

        public List<Person> GetPeople()
        {
            return _personRepository.GetAll();
        }

        public Person GetPersonById(int personId)
        {
            return _personRepository.GetById(personId);
        }

        public List<Rent> GetRentsByPerson(int personId)
        {
            //don't create another repository, use navigational properties
            return _personRepository
                .GetById(personId)
                .Rents
                .ToList();
        }

        public bool Remove(int personId)
        {
            return _personRepository.RemoveById(personId);
        }

        public bool UpdatePerson(int personId, string firstName, string lastName, string phone, decimal balance, int cityId)
        {
            var person = _personRepository.GetById(personId);
            person.FirstName = firstName;
            person.LastName = lastName;
            person.Phone = phone;
            person.Balance = balance;
            person.City = _cityRepository.GetById(cityId);

            return _personRepository.Update(person);
        }
    }
}
