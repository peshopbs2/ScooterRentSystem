using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ScooterRentSystem.Web.Models.ViewModels
{
    public class BaseViewModel
    {
        [Key]
        [ScaffoldColumn(false)]
        public int Id { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Created")]
        public DateTime CreatedAt { get; set; }
        [ScaffoldColumn(false)]
        [DisplayName("Modified")]
        public DateTime ModifiedAt { get; set; }
    }
}
