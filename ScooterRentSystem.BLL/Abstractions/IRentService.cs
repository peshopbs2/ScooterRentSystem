using ScooterRentSystem.DAL.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentSystem.BLL.Abstractions
{
    public interface IRentService
    {
        bool StartRent(int personId, int scooterId);
        bool EndRent(int rentId);
        List<Rent> GetRents();
        Rent GetRentById(int rentId);
        bool Remove(int rentId);
    }
}
