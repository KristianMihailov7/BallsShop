using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsShop.Data.Models.Cart
{
    public class AddToCartViewModel
    {
        public int BallId { get; set; }
        public string BallName { get; set; }
        [Required(ErrorMessage = "Please enter the quantity.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantity must be at least 1.")]
        public int Quantity { get; set; }
    }
}
