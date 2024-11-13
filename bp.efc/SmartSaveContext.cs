using Microsoft.EntityFrameworkCore;
using bp.domain.Models;

namespace bp.efc
{
    public class bpContext(DbContextOptions options) : DbContext(options)
    {
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<AssignmentType> AssignmentTypes { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Product> Products { get; set; }
    }
}