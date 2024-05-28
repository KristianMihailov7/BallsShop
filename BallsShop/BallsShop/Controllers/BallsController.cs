using BallsShop.Common;
using BallsShop.Data.Models.Balls;
using Microsoft.AspNetCore.Mvc;

namespace BallsShop.Controllers
{
    public class BallsController : Controller
    {
        public IActionResult All()
        {
            AllBallsViewModel allBalls = new AllBallsViewModel()
            {
                Balls = RawData.GetBalls()
            };

            return View(allBalls);
        }

        public IActionResult Details()
        {
            var ball = RawData.GetBalls().FirstOrDefault();

            return View(ball);
        }
    }
}
