using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentSystem.DAL.Entities
{
    public class Scooter : BaseEntity
    {
        public Scooter()
        {
            Rents = new HashSet<Rent>();
        }

        public string Model { get; set; }
        public string GpsPosition { get; set; }
        public decimal Rate { get; set; }
        public bool IsTaken
        {
            get
            {
                return Rents
                    .Where(item => item.EndTime.HasValue == false)
                    .Any();
            }
        }
        public virtual ICollection<Rent> Rents { get; set; }
    }
}
