using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Models.ViewModels.Scooter
{
    public class ScooterAddViewModel : BaseViewModel
    {
        public string ModelNumber { get; set; }
        [DisplayName("GPS Position")]
        public string GpsPosition { get; set; }
        public decimal Rate { get; set; }
    }
}
