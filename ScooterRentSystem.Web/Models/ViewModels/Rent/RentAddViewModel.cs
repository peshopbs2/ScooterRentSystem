using ScooterRentSystem.Web.Models.ViewModels.Person;
using ScooterRentSystem.Web.Models.ViewModels.Scooter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Models.ViewModels.Rent
{
    public class RentAddViewModel : BaseViewModel
    {
        public int ScooterId { get; set; }
        public List<ScooterPairViewModel> Scooters { get; set; }
        public int PersonId { get; set; }
        public List<PersonPairViewModel> People { get; set; }

    }
}
