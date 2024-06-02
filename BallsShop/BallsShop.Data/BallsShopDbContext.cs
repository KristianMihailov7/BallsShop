using BallsShop.Data.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace BallsShop.Data
{
    public class BallsShopDbContext : IdentityDbContext
    {
        public BallsShopDbContext(DbContextOptions<BallsShopDbContext> options)
            : base(options)
        {
        }

        public DbSet<Ball> Balls { get; set; } = null!;
        public DbSet<CartItem> CartItems { get; set; } = null!;
        public DbSet<Cart> Carts { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Category>()
                .HasMany(c => c.Balls)
                .WithOne(b => b.Category)
                .HasForeignKey(b => b.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Ball)
                .WithMany()
                .HasForeignKey(ci => ci.BallId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<CartItem>()
                .HasOne(ci => ci.Cart)
                .WithMany(c => c.CartItems)
                .HasForeignKey(ci => ci.CartId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<Category>().HasData(
             new Category { CategoryId = 1, Name = "Soccer" },
             new Category { CategoryId = 2, Name = "Basketball" },
             new Category { CategoryId = 3, Name = "Tennis" }
            );

            modelBuilder.Entity<Ball>().HasData(
                new Ball
                {
                    BallId = 1,
                    CategoryId = 1,
                    Perimeter = 68.8,
                    Shop = "Sofia",
                    ImageUrl = "https://m.media-amazon.com/images/I/51Xvsr0a4OL.jpg",
                    Price = 106.99
                },
                new Ball
                {
                    BallId = 2,
                    CategoryId = 2,
                    Perimeter = 66,
                    Shop = "Plovdiv",
                    ImageUrl = "https://i.ebayimg.com/images/g/WLAAAOSw-4BkfsOn/s-l1600.webp",
                    Price = 107.40
                },
                new Ball
                {
                    BallId = 3,
                    CategoryId = 3,
                    Perimeter = 75,
                    Shop = "Varna",
                    ImageUrl = "https://shop.basketballengland.co.uk/cdn/shop/products/WilsonBasketballEnglandEVONXTOfficialGameBall1_1024x1024.png?v=1631103919",
                    Price = 149.99
                }
            );
        }
    }
}
