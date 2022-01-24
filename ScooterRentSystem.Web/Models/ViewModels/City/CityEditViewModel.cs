using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Models.ViewModels.City
{
    public class CityEditViewModel : BaseViewModel
    {
        [MinLength(3)]
        [Required]
        public string Name { get; set; }
        public string GpsPosition { get; set; }
    }
}
