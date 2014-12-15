using System.Collections.Generic;

namespace PortSimulator.Core.Entities
{
    public class Captain : BaseEntity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public Captain()
        {
            Trips = new List<Trip>();
        }

        public virtual ICollection<Trip> Trips { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}",
                Id, FirstName, LastName);
        }
    }
}
