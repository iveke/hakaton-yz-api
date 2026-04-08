using Microsoft.EntityFrameworkCore;
using hakaton_yz_api.Models;

namespace hakaton_yz_api.Data
{
    public class AppDbContext : DbContext
    {
        public DbSet<Wagon> Wagons { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<Assignment> Assignments { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }
    }
}