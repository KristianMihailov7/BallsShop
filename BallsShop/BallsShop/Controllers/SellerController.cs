using BallsShop.Data;
using BallsShop.Data.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace BallsShop.Controllers
{
    public class SellerController : Controller
    {
        private readonly BallsShopDbContext _context;

        public SellerController(BallsShopDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var seller = await _context.Sellers.Include(s => s.Balls).FirstOrDefaultAsync(s => s.UserId == userId);

            if (seller == null)
            {
                return NotFound();
            }

            return View(seller);
        }

        public IActionResult CreateBall()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateBall(Ball ball)
        {
            var userId = User.FindFirst(ClaimTypes.NameIdentifier).Value;
            var seller = await _context.Sellers.FirstOrDefaultAsync(s => s.UserId == userId);

            if (seller == null)
            {
                return NotFound();
            }

            ball.SellerId = seller.SellerId;
            _context.Balls.Add(ball);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> EditBall(int id)
        {
            var ball = await _context.Balls.FindAsync(id);
            if (ball == null)
            {
                return NotFound();
            }

            return View(ball);
        }

        [HttpPost]
        public async Task<IActionResult> EditBall(Ball ball)
        {
            if (ModelState.IsValid)
            {
                _context.Update(ball);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            return View(ball);
        }

        public async Task<IActionResult> DeleteBall(int id)
        {
            var ball = await _context.Balls.FindAsync(id);
            if (ball == null)
            {
                return NotFound();
            }

            _context.Balls.Remove(ball);
            await _context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}
