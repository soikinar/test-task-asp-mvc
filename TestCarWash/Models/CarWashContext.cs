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

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Service>().Property(p => p.Name).HasColumnName("ServiceName");
            modelBuilder.Entity<Service>().Property(p => p.Description).HasColumnName("ServiceDescription");

            modelBuilder.Entity<ProvidedService>().Property(p => p.NumberOfMinutes).IsOptional();
            modelBuilder.Entity<Service>().Property(p => p.PricePerMinute).IsOptional();

            modelBuilder.Entity<Client>().Property(p => p.Person).HasMaxLength(50);
            modelBuilder.Entity<Client>().Property(p => p.PhoneNumber).HasMaxLength(50);
            modelBuilder.Entity<Service>().Property(p => p.Name).HasMaxLength(120);
            modelBuilder.Entity<Service>().Property(p => p.Description);

            modelBuilder.Entity<Service>().Property(p => p.PricePerMinute).HasPrecision(4, 2);

            modelBuilder.Entity<Client>()
                .HasMany(client => client.ProvidedServices)
                .WithRequired(providedService => providedService.Client)
                .HasForeignKey(providedService => providedService.ClientId);
            
            base.OnModelCreating(modelBuilder);
        }
    }
}