using System.Collections.Generic;

namespace PortSimulator.Core.Entities
{
    public class City : BaseEntity
    {
        public string Name { get; set; }

        public City()
        {
            Ports = new List<Port>();
        }

        public virtual List<Port> Ports { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}",
                Id, Name);
        }
    }
}
