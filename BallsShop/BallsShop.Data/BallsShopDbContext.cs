using BallsShop.Data.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Scaffolding;

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
        public DbSet<Seller> Sellers { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            var hasher = new PasswordHasher<IdentityUser>();

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
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, Name = "Football" },
                new Category { CategoryId = 2, Name = "Basketball" },
                new Category { CategoryId = 3, Name = "Volleyball" },
                new Category { CategoryId = 4, Name = "Tennis" },
                new Category { CategoryId = 5, Name = "American Football" }
            );

            modelBuilder.Entity<IdentityUser>().HasData(
                new IdentityUser
                {
                    Id = "c60da481-3bf1-452b-9119-87184184bc87",
                    UserName = "testSeller@mail.com",
                    NormalizedUserName = "TESTSELLER@MAIL.COM",
                    Email = "testSeller@mail.com",
                    NormalizedEmail = "TESTSELLER@MAIL.COM",
                    PasswordHash = hasher.HashPassword(null, "123456")
                }
            );

            modelBuilder.Entity<Seller>().HasData(
                new Seller
                {
                    SellerId = Guid.Parse("c60da481-3bf1-452b-9119-87184184bc87"),
                    Name = "TestSeller",
                    UserId = "c60da481-3bf1-452b-9119-87184184bc87"
                }
            );

            modelBuilder.Entity<Ball>().HasData(
                new Ball
                {
                    BallId = 1,
                    CategoryId = 1,
                    Perimeter = 68.8,
                    Shop = "Sofia",
                    ImageUrl = "https://encrypted-tbn0.gstatic.com/images?q=tbn:ANd9GcQ6W79cKqoFwkReD5n8FwZM_99dvUU4OGAoQQ&s",
                    Price = 106.99,
                    SellerId = Guid.Parse("c60da481-3bf1-452b-9119-87184184bc87")
                },
                new Ball
                {
                    BallId = 2,
                    CategoryId = 3,
                    Perimeter = 75,
                    Shop = "Varna",
                    ImageUrl = "https://shop.basketballengland.co.uk/cdn/shop/products/WilsonBasketballEnglandEVONXTOfficialGameBall1_1024x1024.png?v=1631103919",
                    Price = 149.99,
                    SellerId = Guid.Parse("c60da481-3bf1-452b-9119-87184184bc87")
                },
                new Ball
                {
                    BallId = 3,
                    CategoryId = 2,
                    Perimeter = 66,
                    Shop = "Plovdiv",
                    ImageUrl = "https://i.ebayimg.com/images/g/WLAAAOSw-4BkfsOn/s-l1600.webp",
                    Price = 107.40,
                    SellerId = Guid.Parse("c60da481-3bf1-452b-9119-87184184bc87")
                },
                new Ball
                {
                    BallId = 4,
                    CategoryId = 5,
                    Perimeter = 71,
                    Shop = "Sofia",
                    ImageUrl = "https://m.media-amazon.com/images/I/71jGnieoAZL._AC_SX679_.jpg",
                    Price = 101.99,
                    SellerId = Guid.Parse("c60da481-3bf1-452b-9119-87184184bc87")
                },
                new Ball
                {
                    BallId = 5,
                    CategoryId = 4,
                    Perimeter = 21,
                    Shop = "Sofia",
                    ImageUrl = "https://i0.wp.com/keysports.org/wp-content/uploads/2017/11/product_14.png?fit=1200%2C1200&ssl=1",
                    Price = 20.76,
                    SellerId = Guid.Parse("c60da481-3bf1-452b-9119-87184184bc87")
                },
                new Ball
                {
                    BallId = 6,
                    CategoryId = 1,
                    Perimeter = 68.8,
                    Shop = "Sofia",
                    ImageUrl = "https://m.media-amazon.com/images/I/51Xvsr0a4OL.jpg",
                    Price = 106.99,
                    SellerId = Guid.Parse("c60da481-3bf1-452b-9119-87184184bc87")
                },
                new Ball
                {
                    BallId = 7,
                    CategoryId = 1,
                    Perimeter = 68.8,
                    Shop = "Sofia",
                    ImageUrl = "https://thirdcoastsoccer.net/cdn/shop/files/Picture3-678.jpg?v=1707155573&width=1800",
                    Price = 174.99,
                    SellerId = Guid.Parse("c60da481-3bf1-452b-9119-87184184bc87")
                }
            );
        }
    }
}
