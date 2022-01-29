using ScooterRentSystem.Web.Models.ViewModels.Rent;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Models.ViewModels.Scooter
{
    public class ScooterDetailsViewModel : BaseViewModel
    {
        public ScooterDetailsViewModel()
        {
            Rents = new List<RentViewModel>();
        }
        public string ModelNumber { get; set; }
        [DisplayName("GPS Position")]
        public string GpsPosition { get; set; }
        public decimal Rate { get; set; }
        public bool IsTaken { get; set; }
        public int RentCount { get; set; }
        public List<RentViewModel> Rents { get; set; }
    }

}
