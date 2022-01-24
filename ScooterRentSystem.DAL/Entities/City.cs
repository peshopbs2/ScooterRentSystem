using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentSystem.DAL.Entities
{
    public class City : BaseEntity
    {
        public City()
        {
            People = new HashSet<Person>();
        }

        public string Name { get; set; }
        public string GpsPosition { get; set; }
        public virtual ICollection<Person> People { get; set; }
    }
}
