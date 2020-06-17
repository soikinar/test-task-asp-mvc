using System.Data.Entity;

namespace TestCarWash.Models
{
    /// <summary>
    /// Car wash database context.
    /// </summary>
    public class CarWashContext : DbContext
    {
        /// <summary>
        /// Database table of clients.
        /// </summary>
        public DbSet<Client> Clients { get; set; }

        /// <summary>
        /// Database table of services.
        /// </summary>
        public DbSet<Service> Services { get; set; }

        /// <summary>
        /// Database table of services provided.
        /// </summary>
        public DbSet<ProvidedService> ProvidedServices { get; set; }
    }
}