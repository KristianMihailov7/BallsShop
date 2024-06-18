using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsShop.Data.Entities
{
    public class Seller
    {
        public Guid SellerId { get; set; }
        public string UserId { get; set; }
        public string Name { get; set; }
        public ICollection<Ball> Balls { get; set; }
    }

}
