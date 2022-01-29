using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Models.ViewModels.Person
{
    public class PersonViewModel : BaseViewModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public decimal Balance { get; set; }
        public string CityName { get; set; }
        public int RentsCount { get; set; }
    }
}
