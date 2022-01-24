using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScooterRentSystem.DAL.Entities
{
    public class Rent : BaseEntity
    {
        public Rent()
        {
            EndTime = null;
            Person = new Person();
            Scooter = new Scooter();
        }
        public int PersonId { get; set; }
        public virtual Person Person { get; set; }
        public int ScooterId { get; set; }
        public virtual Scooter Scooter { get; set; }
        public DateTime BeginTime { get; set; }
        public DateTime? EndTime { get; set; }
        public decimal Price
        {
            get
            {
                if (EndTime.HasValue)
                {
                    return (EndTime.Value - BeginTime).Hours * Scooter.Rate;
                }
                else
                {
                    return (DateTime.Now - BeginTime).Hours * Scooter.Rate;
                }
            }
        }
    }
}
