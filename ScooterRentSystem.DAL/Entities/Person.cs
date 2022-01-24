using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentSystem.DAL.Entities
{
    public class Person : BaseEntity
    {
        public Person()
        {
            City = new City();
            Rents = new HashSet<Rent>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Phone { get; set; }
        public decimal Balance { get; set; }
        public int CityId { get; set; }
        public virtual City City { get; set; }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
