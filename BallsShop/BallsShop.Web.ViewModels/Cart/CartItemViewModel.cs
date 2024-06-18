using BallsShop.Data.Entities;
using BallsShop.Web.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsShop.Web.ViewModels.Cart
{
    public class CartItemViewModel
    {
        public int CartItemId { get; set; }
        public Ball Ball { get; set; }
        public int Quantity { get; set; }
    }

}
