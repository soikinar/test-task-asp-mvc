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
        /// Database table of operations.
        /// </summary>
        public DbSet<Operation> Operations { get; set; }

        /// <summary>
        /// Database table of services provided.
        /// </summary>
        public DbSet<ServiceProvision> ServiceProvisions { get; set; }
    }
}