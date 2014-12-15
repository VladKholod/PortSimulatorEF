using System.Data.Entity.ModelConfiguration;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.DbMapping
{
    public class ShipMap : EntityTypeConfiguration<Ship>
    {
        public ShipMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.MaxDistance)
                .IsRequired();
            this.Property(x => x.Number)
                .IsRequired();
            this.Property(x => x.Capacity)
                .IsRequired();
            this.Property(x => x.CreateDate)
                .IsRequired();
            this.Property(x => x.TeamCount)
                .IsRequired();

            this.HasOptional<Port>(s => s.Port)
                .WithMany(p => p.Ships)
                .HasForeignKey(s => s.PortId)
                .WillCascadeOnDelete(false);

            this.ToTable("Ship");
        }
    }
}
