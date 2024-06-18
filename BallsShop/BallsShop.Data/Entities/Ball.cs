using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsShop.Data.Entities
{
    public class Ball
    {
        [Key]
        public int BallId { get; set; }

        [Required]
        public int CategoryId { get; set; }

        public double Perimeter { get; set; }

        [Required]
        [MaxLength(100)]
        public string Shop { get; set; } = null!;

        [Required]
        [MaxLength(300)]
        public string ImageUrl { get; set; } = null!;

        [Column(TypeName = "decimal(18, 2)")]
        public double Price { get; set; }

        [ForeignKey(nameof(CategoryId))]
        public Category Category { get; set; } = null!;

        public Guid SellerId { get; set; }
        public Seller Seller { get; set; }
    }
}
