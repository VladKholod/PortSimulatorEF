using System.Data.Entity.ModelConfiguration;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.DbMapping
{
    public class CargoMap : EntityTypeConfiguration<Cargo>
    {
        public CargoMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.InsurancePrice)
                .IsRequired();
            this.Property(x => x.Number)
                .IsRequired();
            this.Property(x => x.Price)
                .IsRequired();
            this.Property(x => x.Weight)
                .IsRequired();

            this.HasOptional<CargoType>(c => c.CargoType)
                .WithMany(ct => ct.Cargos)
                .HasForeignKey(c => c.CargoTypeId)
                .WillCascadeOnDelete(false);

            this.HasOptional<Trip>(c => c.Trip)
                .WithMany(t => t.Cargos)
                .HasForeignKey(c => c.TripId)
                .WillCascadeOnDelete(false);

            this.ToTable("Cargo");
        }
    }
}
