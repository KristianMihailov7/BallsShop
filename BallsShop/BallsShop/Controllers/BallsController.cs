using BallsShop.Common;
using BallsShop.Data;
using BallsShop.Data.Entities;
using BallsShop.Data.Models.Balls;
using BallsShop.Data.Models.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BallsShop.Controllers
{
    public class BallsController : Controller
    {
        private readonly BallsShopDbContext _context;

        public BallsController(BallsShopDbContext context)
        {
            _context = context;
        }

        public IActionResult All()
        {
            var balls = _context.Balls
                .Include(b => b.Category)
                .Select(b => new BallsDetailsViewModel
                {
                    BallId = b.BallId,
                    Category = b.Category.Name,
                    Perimeter = b.Perimeter,
                    Shop = b.Shop,
                    ImageUrl = b.ImageUrl,
                    Price = b.Price
                })
                .ToList();

            var allBalls = new AllBallsViewModel
            {
                Balls = balls
            };

            return View(allBalls);
        }

        public IActionResult Details(int id)
        {
            var ball = _context.Balls
                .Include(b => b.Category)
                .FirstOrDefault(b => b.BallId == id);

            if (ball == null)
            {
                return NotFound();
            }

            var ballDetails = new BallsDetailsViewModel
            {
                BallId= ball.BallId,
                Category = ball.Category.Name,
                Perimeter = ball.Perimeter,
                Shop = ball.Shop,
                ImageUrl = ball.ImageUrl,
                Price = ball.Price
            };

            return View(ballDetails);
        }

        [HttpGet]
        public IActionResult AddToCart(int ballId)
        {
            var ball = _context.Balls.FirstOrDefault(b => b.BallId == ballId);

            if (ball == null)
            {
                return NotFound();
            }

            var model = new AddToCartViewModel
            {
                BallId = ball.BallId,
                Quantity = 1
            };

            return View(model);
        }

        [HttpPost]
        public IActionResult AddToCart([Bind("Quantity")] AddToCartViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model); // Return the view with validation errors
            }

            var ball = _context.Balls.FirstOrDefault(b => b.BallId == model.BallId);

            if (ball == null)
            {
                return NotFound();
            }

            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Guid userId = Guid.Parse(userIdString);

            var cart = _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Ball)
                .FirstOrDefault(c => c.UserId == userId);

            if (cart == null)
            {
                cart = new Cart { UserId = userId };
                _context.Carts.Add(cart);
            }

            var cartItem = cart.CartItems.FirstOrDefault(ci => ci.BallId == model.BallId);
            if (cartItem != null)
            {
                cartItem.Quantity += model.Quantity;
            }
            else
            {
                cartItem = new CartItem { BallId = model.BallId, Quantity = model.Quantity };
                cart.CartItems.Add(cartItem);
            }

            _context.SaveChanges();

            return RedirectToAction("Details", "Balls", new { id = model.BallId });
        }
    }
}
