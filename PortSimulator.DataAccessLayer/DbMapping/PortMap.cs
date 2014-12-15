using System.Data.Entity.ModelConfiguration;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.DbMapping
{
    public class PortMap : EntityTypeConfiguration<Port>
    {
        public PortMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.Name)
                .IsRequired()
                .HasMaxLength(30);

            this.HasOptional<City>(p => p.City)
                .WithMany(c => c.Ports)
                .HasForeignKey(p => p.CityId)
                .WillCascadeOnDelete(false);

            this.ToTable("Port");
        }
    }
}
