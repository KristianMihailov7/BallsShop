using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsShop.Data.Models.Balls
{
    public class AllBallsViewModel
    {
        public IEnumerable<BallsDetailsViewModel> Balls { get; set; }
            = new List<BallsDetailsViewModel>();
    }
}
