using ScooterRentSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentSystem.BLL.Abstractions
{
    public interface ICityService
    {
        bool CreateCity(string name, string gpsPosition);
        bool UpdateCity(int cityId, string name, string gpsPosition);
        List<City> GetCities();
        City GetCityById(int cityId);
        bool Remove(int cityId);
        List<Person> GetPeopleByCity(int cityId);
    }
}
