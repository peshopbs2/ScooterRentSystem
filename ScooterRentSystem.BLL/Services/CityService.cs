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
    public class CityService : ICityService
    {
        private readonly IRepository<City> _cityRepository;
        private readonly IRepository<Person> _peopleRepository;
        public CityService(IRepository<City> cityRepository,
            IRepository<Person> peopleRepository)
        {
            _cityRepository = cityRepository;
            _peopleRepository = peopleRepository;
        }
        public bool CreateCity(string name, string gpsPosition)
        {
            var city = new City()
            {
                Name = name,
                GpsPosition = gpsPosition
            };
            return _cityRepository.Create(city);
        }

        public List<City> GetCities()
        {
            return _cityRepository.GetAll();
        }

        public City GetCityById(int cityId)
        {
            return _cityRepository.GetById(cityId);
        }

        public List<Person> GetPeopleByCity(int cityId)
        {
            return _peopleRepository.Find(item => item.CityId == cityId);
        }

        public bool Remove(int cityId)
        {
            return _cityRepository.RemoveById(cityId);
        }

        public bool UpdateCity(int cityId, string name, string gpsPosition)
        {
            var city = _cityRepository.GetById(cityId);
            if(city==default(City))
            {
                return false;
            }

            city.Name = name;
            city.GpsPosition = gpsPosition;
            return _cityRepository.Update(city);
        }
    }
}
