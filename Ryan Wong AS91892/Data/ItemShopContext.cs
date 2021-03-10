using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Ryan_Wong_AS91892.Models;

namespace Ryan_Wong_AS91892.Data
{
    public class ItemShopContext : DbContext
    {
        public ItemShopContext (DbContextOptions<ItemShopContext> options)
            : base(options)
        {
        }

        public DbSet<Item> Items { get; set; }
        public DbSet<Staff> Staffs { get; set; }
        public DbSet<Store> Stores { get; set; }
        public DbSet<ItemAssignment> ItemAssignments { get; set; }
        public DbSet<StaffAssignment> StaffAssignments { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().ToTable("Item");
            modelBuilder.Entity<Staff>().ToTable("Staff");
            modelBuilder.Entity<Store>().ToTable("Store");
            modelBuilder.Entity<ItemAssignment>().ToTable("ItemAssignment");
            modelBuilder.Entity<StaffAssignment>().ToTable("StaffAssignment");

        }
    }
}
