using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Models.ViewModels.City
{
    public class CityViewModel : BaseViewModel
    {
        public string Name { get; set; }
        [DisplayName("GPS Position")]
        public string GpsPosition { get; set; }
        [DisplayName("People")]
        public int PeopleCount { get; set; }
    }
}
