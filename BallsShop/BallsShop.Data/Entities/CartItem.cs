using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsShop.Data.Entities
{
    public class CartItem
    {
        [Key]
        public int CartItemId { get; set; }

        [Required]
        public int CartId { get; set; }

        [Required]
        public int BallId { get; set; }

        [Range(1, int.MaxValue)]
        public int Quantity { get; set; }

        [ForeignKey(nameof(BallId))]
        public Ball Ball { get; set; } = null!;

        [ForeignKey(nameof(CartId))]
        public Cart Cart { get; set; } = null!;
    }
}
