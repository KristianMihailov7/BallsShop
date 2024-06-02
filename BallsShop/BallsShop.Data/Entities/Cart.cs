using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsShop.Data.Entities
{
    public class Cart
    {
        [Key]
        public int CartId { get; set; }

        [Required]
        public Guid UserId { get; set; }

        public ICollection<CartItem> CartItems { get; set; } = new List<CartItem>();
    }
}
