using ScooterRentSystem.Web.Models.ViewModels.City;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Models.ViewModels.Person
{
    public class PersonAddViewModel : BaseViewModel
    {
        public PersonAddViewModel()
        {
            Cities = new List<CityPairViewModel>();
        }

        [MinLength(3)]
        [Required]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public decimal Balance { get; set; }
        [DisplayName("City")]
        public int CityId { get; set; }
        public List<CityPairViewModel> Cities { get; set; }
    }
}
