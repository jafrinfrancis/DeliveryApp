using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace dotnetapiapp.Models
{
    public class OrderDeliveryDbContext : DbContext
    {
        public OrderDeliveryDbContext(DbContextOptions options):base(options)
        {

        }

        public DbSet<User> Users { get; set;}
        public DbSet<Order> Orders { get; set; }
        public DbSet<Delivery> Deliveries { get; set; }
    }
}