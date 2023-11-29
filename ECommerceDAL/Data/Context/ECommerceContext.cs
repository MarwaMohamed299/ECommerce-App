using ECommerceDAL.Data.DataTypes;
using ECommerceDAL.Data.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;


namespace ECommerceDAL.Data.Context
{
    public class ECommerceContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {
        public DbSet<Product> Products => Set<Product>();



        public ECommerceContext(DbContextOptions<ECommerceContext> options) : base(options)
        {
        }

     
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
             
            //User

            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<User>().HasKey(x => x.Id);
            modelBuilder.Entity<User>().HasMany(p => p.Products).WithOne(U => U.User)
                .HasForeignKey(x => x.UserId).OnDelete(DeleteBehavior.Cascade);
            modelBuilder.Entity<User>().HasIndex(u => u.UserName).IsUnique();
            modelBuilder.Entity<User>().HasIndex(u => u.Email).IsUnique();






            //Product
            modelBuilder.Entity<Product>().HasKey(x => x.Id);
            modelBuilder.Entity<Product>().HasOne(p => p.User)
                     .WithMany(u => u.Products)
                     .HasForeignKey(p => p.UserId)
                     .OnDelete(DeleteBehavior.Cascade); 

            



            #region Seeding
            var users = new List<User>
{
            new User
            {
                Id = Guid.NewGuid(),
                UserName = "John",
                City = "Newyork",
                Password = "John1234", 
                Email = "John@example.com", 
                LastLogin = DateTime.Now
            },
            new User
            {
                Id = Guid.NewGuid(),
                UserName = "Sara",
                City = "Paris",
                Password = "Sara1234", 
                Email = "Sara@example.com", 
                LastLogin = DateTime.Now
            },
            new User
            {
                Id = Guid.NewGuid(),
                UserName = "Michael",
                
                City = "Paris",
                Password = "Michael1234", 
                Email = "Michael@gmail.com", 
                LastLogin = DateTime.Now
            }
        };
            var products = new List<Product>


            {
                new Product
                {
                Id=Guid.NewGuid(),
                UserId = users[2].Id,
                Category="phones",
                Image="",
                Name="Iphone15",
                Price=1000,
                MinimumQuality="Good",
                DiscountRate = (decimal)(1000 * 0.15)

                },


               new Product
                {
                Id=Guid.NewGuid(),
                UserId =  users[1].Id,
                Category="phones",
                Image="",
                Name="Iphone14",
                Price=900,
                MinimumQuality="Good",
                DiscountRate = (decimal)DiscountRate.TenPercent

                },
               new Product
                {
                Id=Guid.NewGuid(),
                UserId = users[0].Id,
                Category="phones",
                Image="",
                Name="Iphone13",
                Price=800,
                MinimumQuality="VeryGood",
                DiscountRate = (decimal)DiscountRate.TenPercent

                },

            #endregion
        };
            modelBuilder.Entity<User>().HasData(users);

            modelBuilder.Entity<Product>().HasData(products);
        }
    }
}
