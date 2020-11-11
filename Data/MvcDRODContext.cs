using DROD.Models;
using Microsoft.EntityFrameworkCore;

namespace DROD.Data
{
    public class MvcDRODContext : DbContext
    {
        public MvcDRODContext(DbContextOptions<MvcDRODContext> options) : base(options)
        {
        }

        public DbSet<Users> Users { get; set; }

        public DbSet<Orders> Orders { get; set; }

        public DbSet<ShoppingCart> OrderDetails { get; set; }

        public DbSet<Items> Items { get; set; }

        //public object ShoppingCartItems { get; internal set; }

        public DbSet<ShoppingCartItem> ShoppingCartItem { get; set; }

        public DbSet<ShoppingCart> ShoppingCart { get; set; }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        //    modelBuilder.Entity<Users>().HasData(new Users
        //    {
        //        Id = 1,
        //        Email = "Danishagan@gmail.com",
        //        Password = "Aa123456",
        //        Type = UserType.Admin
        //    }, new Users

        //    {
        //        Id = 2,
        //        Email = "Ofrimor@gmail.com",
        //        Password = "Aa123456",
        //        Type = UserType.Admin
        //    });
        //}
    }
}