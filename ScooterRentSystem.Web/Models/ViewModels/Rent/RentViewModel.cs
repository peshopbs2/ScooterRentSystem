using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Models.ViewModels.Rent
{
    public class RentViewModel : BaseViewModel
    {
        public string ScooterModel { get; set; }
        public string PersonFullName { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal Price { get; set; }
    }
}
