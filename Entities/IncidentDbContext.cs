using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace USTVA.Entities
{
    public class IncidentDbContext : DbContext
    {
        public DbSet<Incident> Incidents { get; set; }
        public DbSet<Vehicle> Vehicle { get; set; }
        public DbSet<Driver> Driver { get; set; }
        public DbSet<Violation> Violation { get; set; }

        public IncidentDbContext(DbContextOptions options) : base(options) {}
    }
}
