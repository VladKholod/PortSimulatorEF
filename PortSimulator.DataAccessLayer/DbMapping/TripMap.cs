using System.Data.Entity.ModelConfiguration;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.DbMapping
{
    public class TripMap : EntityTypeConfiguration<Trip>
    {
        public TripMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.StartDate)
                .IsRequired();
            this.Property(x => x.EndDate)
                .IsRequired();

            this.HasOptional<Ship>(t => t.Ship)
                .WithMany(s => s.Trips)
                .HasForeignKey(t => t.ShipId)
                .WillCascadeOnDelete(false);

            this.HasOptional<Captain>(t => t.Captain)
                .WithMany(c => c.Trips)
                .HasForeignKey(t => t.CaptainId)
                .WillCascadeOnDelete(false);

            this.HasOptional<Port>(t => t.PortFrom)
                .WithMany(p => p.PortFromTrips)
                .HasForeignKey(t => t.PortFromId)
                .WillCascadeOnDelete(false);

            this.HasOptional<Port>(t => t.PortTo)
                .WithMany(p => p.PortToTrips)
                .HasForeignKey(t => t.PortToId)
                .WillCascadeOnDelete(false);

            this.ToTable("Trip");
        }
    }
}
