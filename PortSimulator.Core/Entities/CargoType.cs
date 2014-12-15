using System.Collections.Generic;

namespace PortSimulator.Core.Entities
{
    public class CargoType : BaseEntity
    {
        public string Name { get; set; }

        public CargoType()
        {
            Cargos = new List<Cargo>();
        }

        public virtual ICollection<Cargo> Cargos { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}",
                Id, Name);
        }
    }
}
