using Hotdeals.Domain.ECommerceDomain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotdeals.Repository.SQLRepostories
{
    public class EcommerceDbContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            string connectionString = @"Data Source=LAPTOP-HPPFIAI6\SQLEXPRESS; Initial Catalog=HotdealsCommerce; integrated security=true;";
            optionsBuilder.UseSqlServer(connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Products> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.HasDefaultSchema("Catalogue");
            //modelBuilder.HasDefaultSchema("Sales");
        }
    }
}
