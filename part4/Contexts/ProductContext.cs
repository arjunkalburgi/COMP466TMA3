using System;
using Microsoft.EntityFrameworkCore;
using part4.Models;

namespace part4.Contexts
{
    public class ProductContext : DbContext
    {
        public ProductContext(DbContextOptions<ProductContext> options) : base(options) { 
            Database.SetCommandTimeout(360);
        }

        public DbSet<ProductItem> Products { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class CartItemsContext : DbContext
    {
        public CartItemsContext(DbContextOptions<CartItemsContext> options) : base(options)
        {
            Database.SetCommandTimeout(360);
        }

        public DbSet<CartItem> CartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class ComputerContext : DbContext
    {
        public ComputerContext(DbContextOptions<ComputerContext> options) : base(options) 
        {
            Database.SetCommandTimeout(360);
        }

        public DbSet<ComputerItem> Computers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

    }

    public class ComputerCartItemsContext : DbContext
    {
        public ComputerCartItemsContext(DbContextOptions<ComputerCartItemsContext> options) : base(options)
        {
            Database.SetCommandTimeout(360);
        }

        public DbSet<CartComputer> ComputerCartItems { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.SetCommandTimeout(360);
        }

        public DbSet<user> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }


}