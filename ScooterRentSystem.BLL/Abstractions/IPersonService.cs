using ScooterRentSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentSystem.BLL.Abstractions
{
    public interface IPersonService
    {
        bool CreatePerson(string firstName, string lastName, string phone, decimal balance, int cityId);
        bool UpdatePerson(int personId, string firstName, string lastName, string phone, decimal balance, int cityId);
        List<Person> GetPeople();
        Person GetPersonById(int personId);
        bool Remove(int personId);
        List<Rent> GetRentsByPerson(int personId);
    }
}
