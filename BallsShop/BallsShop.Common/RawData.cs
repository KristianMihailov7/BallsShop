using BallsShop.Web.ViewModels.Balls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BallsShop.Common
{
    public class RawData
    {
        public static IEnumerable<BallsDetailsViewModel> GetBalls()
            => new List<BallsDetailsViewModel>()
            {
                new BallsDetailsViewModel
                {
                    Category = "Football Ball",
                    Perimeter = 68.8,
                    Shop = "Sofia",
                    ImageUrl = "https://m.media-amazon.com/images/I/51Xvsr0a4OL.jpg",
                    Price = 106.99
                },

                new BallsDetailsViewModel
                {
                    Category = "Volleyball Ball",
                    Perimeter = 66,
                    Shop = "Plovdiv",
                    ImageUrl = "https://i.ebayimg.com/images/g/WLAAAOSw-4BkfsOn/s-l1600.webp",
                    Price = 107.40
                },

                new BallsDetailsViewModel
                {
                    Category = "Basketball Ball",
                    Perimeter = 75,
                    Shop = "Varna",
                    ImageUrl = "https://www.spalding.com/dw/image/v2/ABAH_PRD/on/demandware.static/-/Sites-masterCatalog_SPALDING/default/dw892da85b/images/hi-res/7da243491bc2dc450b860880e0ceea4837a698eb.jpg?sw=1598&sh=1982&sm=cut&sfrm=png",
                    Price = 149.99
                }
            };
    }
}
