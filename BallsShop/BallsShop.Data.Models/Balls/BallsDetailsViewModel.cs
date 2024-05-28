﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsShop.Data.Models.Balls
{
    public class BallsDetailsViewModel
    {
        public string Category { get; set; } = null!;

        public double Perimeter { get; set; }

        public string Shop { get; set; } = null!;

        public string  ImageUrl { get; set; }

        public double Price { get; set; }
    }
}