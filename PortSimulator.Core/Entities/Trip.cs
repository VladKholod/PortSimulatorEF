using System;
using System.Collections.Generic;

namespace PortSimulator.Core.Entities
{
    public class Trip : BaseEntity
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public int? ShipId { get; set; }
        public virtual Ship Ship { get; set; }

        public int? CaptainId { get; set; }
        public virtual Captain Captain { get; set; }

        public int? PortFromId { get; set; }
        public virtual Port PortFrom { get; set; }

        public int? PortToId { get; set; }
        public virtual Port PortTo { get; set; }

        public Trip()
        {
            Cargos = new List<Cargo>();
        }

        public virtual ICollection<Cargo> Cargos { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}/{2}/{3}\t{4}/{5}/{6}\t{7}\t{8}\t{9}\t{10}",
                Id,
                StartDate.Month, StartDate.Day, StartDate.Year,
                EndDate.Month, EndDate.Day, EndDate.Year,
                ShipId, CaptainId, PortFromId, PortToId);
        }
    }
}
