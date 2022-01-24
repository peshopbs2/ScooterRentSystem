using ScooterRentSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentSystem.BLL.Abstractions
{
    public interface IScooterService
    {
        bool CreateScooter(string model, string gpsPosition, decimal rate);
        bool UpdateScooter(int scooterId, string model, string gpsPosition, decimal rate);
        List<Scooter> GetScooters();
        Scooter GetScooterById(int scooterId);
        bool Remove(int scooterId);
        List<Rent> GetRentsByScooterId(int scooterId);
    }
}
