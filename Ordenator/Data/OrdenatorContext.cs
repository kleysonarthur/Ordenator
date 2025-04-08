using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Ordenator.Models
{
    public class OrdenatorContext : DbContext
    {
        public OrdenatorContext (DbContextOptions<OrdenatorContext> options)
            : base(options)
        {
        }

        public DbSet<Department> Department { get; set; }
        public DbSet<Seller> Seller { get; set; }
        public DbSet<SalesRecord> SalesRecord { get; set; }
        public DbSet<Profile> Profile { get; set; }
    }
}
