using System.Collections.Generic;

namespace PortSimulator.Core.Entities
{
    public class Port : BaseEntity
    {
        public string Name { get; set; }
        public int? CityId { get; set; }
        public virtual City City { get; set; }

        public Port()
        {
            Ships = new List<Ship>();
            PortFromTrips = new List<Trip>();
            PortToTrips = new List<Trip>();
        }

        public virtual ICollection<Ship> Ships { get; set; }
        public virtual ICollection<Trip> PortFromTrips { get; set; }
        public virtual ICollection<Trip> PortToTrips { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}",
                Id, Name, CityId);
        }
    }
}
