using System;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Reflection;
using PortSimulator.Core.Entities;
using PortSimulator.DataAccessLayer.DbConfig;
using PortSimulator.DataAccessLayer.DbInitializers;

namespace PortSimulator.DataAccessLayer
{
    public class PortSimulatorContext : DbContext
    {
        public PortSimulatorContext()
            : base(Parameters.ConnectionString)
        {
            Database.SetInitializer(new DropCreateAlwaysPortDbInitializer());
        }

        public DbSet<Captain> Captains { get; set; }
        public DbSet<Cargo> Cargos{ get; set; }
        public DbSet<CargoType> CargoTypes { get; set; }
        public DbSet<City> Cities{ get; set; }
        public DbSet<Port> Ports{ get; set; }
        public DbSet<Ship> Ships{ get; set; }
        public DbSet<Trip> Trips{ get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            var mapTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(type => !String.IsNullOrEmpty(type.Namespace))
                .Where(type => type.BaseType != null && type.BaseType.IsGenericType
                               && type.BaseType.GetGenericTypeDefinition()
                               == typeof (EntityTypeConfiguration<>));

            foreach (var type in mapTypes)
            {
                dynamic configurationInstance = Activator.CreateInstance(type);
                modelBuilder.Configurations.Add(configurationInstance);
            }

            base.OnModelCreating(modelBuilder);
        }
    }
}
