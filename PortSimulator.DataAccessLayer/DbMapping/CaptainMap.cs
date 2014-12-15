using System.Data.Entity.ModelConfiguration;
using PortSimulator.Core.Entities;

namespace PortSimulator.DataAccessLayer.DbMapping
{
    public class CaptainMap : EntityTypeConfiguration<Captain>
    {
        public CaptainMap()
        {
            this.HasKey(x => x.Id);

            this.Property(x => x.FirstName)
                .IsRequired()
                .HasMaxLength(30);

            this.Property(x => x.LastName)
                .IsRequired()
                .HasMaxLength(30);

            this.ToTable("Captain");
        }
    }
}
