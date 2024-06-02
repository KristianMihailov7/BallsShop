using BallsShop.Data;
using BallsShop.Data.Models.Cart;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BallsShop.Controllers
{
    public class CartController : Controller
    {
        private readonly BallsShopDbContext _context;

        public CartController(BallsShopDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Guid userId = Guid.Parse(userIdString);

            var cart = _context.Carts
                .Include(c => c.CartItems)
                .ThenInclude(ci => ci.Ball)
                .FirstOrDefault(c => c.UserId == userId);

            var cartItems = cart?.CartItems.Select(ci => new CartItemViewModel
            {
                CartItemId = ci.CartItemId,
                Ball = ci.Ball,
                Quantity = ci.Quantity
            }).ToList() ?? new List<CartItemViewModel>();

            return View(cartItems);
        }

        [HttpPost]
        public IActionResult RemoveFromCart(int cartItemId)
        {
            var userIdString = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            Guid userId = Guid.Parse(userIdString);

            var cart = _context.Carts
                .Include(c => c.CartItems)
                .FirstOrDefault(c => c.UserId == userId);
            if (cart != null)
            {
                var cartItem = cart.CartItems.FirstOrDefault(ci => ci.CartItemId == cartItemId);
                if (cartItem != null)
                {
                    if (cartItem.Quantity > 1)
                    {
                        cartItem.Quantity--;
                    }
                    else
                    {
                        _context.CartItems.Remove(cartItem);
                    }
                    _context.SaveChanges();
                }
            }

            return RedirectToAction("Index");
        }
    }
}
