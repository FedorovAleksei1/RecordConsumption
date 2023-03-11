using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Domain
{
    public class RecordConsumptionDbContext : DbContext 
    {
        public RecordConsumptionDbContext(DbContextOptions<RecordConsumptionDbContext> options) : base(options)
        {

        }

        public DbSet<Doctor> Doctors { get; set; }
        public DbSet<Polyclinic> Polyclinics { get; set; }
        public DbSet<Practice> Practices { get; set; }
        public DbSet<Specialization> Specializations { get; set; }
        public DbSet<Town> Towns { get; set; }
        public DbSet<Photo> Photos { get; set; }
    }
}
