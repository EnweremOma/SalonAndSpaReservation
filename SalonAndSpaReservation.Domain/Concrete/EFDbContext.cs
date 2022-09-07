using SalonAndSpaReservation.Domain.Entities;
using System.Data.Entity;

namespace SalonAndSpaReservation.Domain.Concrete
{
    public class EFDbContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<Appointment> Appointments { get; set; }
        public DbSet<Material> Materials { get; set; }
        public DbSet<MaterialToService> MaterialToServices { get; set;}
    }
}