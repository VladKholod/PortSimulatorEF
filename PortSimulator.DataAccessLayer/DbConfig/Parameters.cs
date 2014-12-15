using System.Configuration;

namespace PortSimulator.DataAccessLayer.DbConfig
{
    public static class Parameters
    {
        public static readonly string ConnectionString =
            ConfigurationManager.ConnectionStrings["PortDB"].ConnectionString;
    }
}
