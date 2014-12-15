using System;
using System.Collections.Generic;

namespace PortSimulator.Core.Entities
{
    public class Ship : BaseEntity
    {
        public int Number { get; set; }
        public int Capacity { get; set; }
        public DateTime CreateDate { get; set; }
        public int MaxDistance { get; set; }
        public int TeamCount { get; set; }

        public int? PortId { get; set; }
        public virtual Port Port { get; set; }

        public Ship()
        {
            Trips = new List<Trip>();
        }

        public virtual ICollection<Trip> Trips { get; set; }

        public override string ToString()
        {
            return string.Format("{0}\t{1}\t{2}\t{3}/{4}/{5}\t{6}\t{7}\t{8}",
                Id, Number, Capacity,
                CreateDate.Month, CreateDate.Day, CreateDate.Year,
                MaxDistance, TeamCount, PortId);
        }
    }
}
