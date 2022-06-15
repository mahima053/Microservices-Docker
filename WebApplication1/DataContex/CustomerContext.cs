using Microsoft.EntityFrameworkCore;

namespace WebApplication1.DataContex
{
    public class CustomerContext : DbContext

    {
        public CustomerContext(DbContextOptions<CustomerContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
        /// <summary>
        /// This here call all the connfiguration for all the entity in Configurations Table
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CustomerContext).Assembly);
        }

    }
}
