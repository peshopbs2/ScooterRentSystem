using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Models.ViewModels.City
{
    public class CityDetailsViewModel : BaseViewModel
    {
        public string Name { get; set; }
        public string GpsPosition { get; set; }
    }
}
