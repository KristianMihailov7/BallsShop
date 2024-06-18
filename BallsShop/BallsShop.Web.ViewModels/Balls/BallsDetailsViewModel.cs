using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsShop.Web.ViewModels.Balls
{
    public class BallsDetailsViewModel
    {
        public int BallId { get; set; }
        public string Category { get; set; } = null!;

        public double Perimeter { get; set; }

        public string Shop { get; set; } = null!;

        public string ImageUrl { get; set; }

        public double Price { get; set; }
    }
}
