using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;

namespace BallsShop.UnitTests
{
    [TestFixture]
    public class BallsControllerTests
    {
        private BallsController _controller;
        private Mock<BallsShopDbContext> _contextMock;

        [SetUp]
        public void SetUp()
        {
            _contextMock = new Mock<BallsShopDbContext>();
            _controller = new BallsController(_contextMock.Object);

            var user = new ClaimsPrincipal(new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.NameIdentifier, Guid.NewGuid().ToString())
            }, "mock"));

            _controller.ControllerContext = new ControllerContext()
            {
                HttpContext = new DefaultHttpContext() { User = user }
            };
        }

        [Test]
        public void All_ShouldReturnViewWithAllBalls()
        {
            // Arrange
            var balls = new List<Ball>
            {
                new Ball { BallId = 1, Category = new Category { Name = "Football" }, Perimeter = 70, Shop = "Shop1", ImageUrl = "image1.jpg", Price = 20 },
                new Ball { BallId = 2, Category = new Category { Name = "Basketball" }, Perimeter = 75, Shop = "Shop2", ImageUrl = "image2.jpg", Price = 25 }
            }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Ball>>();
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.Provider).Returns(balls.Provider);
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.Expression).Returns(balls.Expression);
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.ElementType).Returns(balls.ElementType);
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.GetEnumerator()).Returns(balls.GetEnumerator());

            _contextMock.Setup(c => c.Balls).Returns(dbSetMock.Object);

            // Act
            var result = _controller.All();

            // Assert
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);

            var model = viewResult.Model as AllBallsViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual(2, model.Balls.Count);
        }

        [Test]
        public void Details_ShouldReturnViewWithBallDetails()
        {
            // Arrange
            var ball = new Ball { BallId = 1, Category = new Category { Name = "Football" }, Perimeter = 70, Shop = "Shop1", ImageUrl = "image1.jpg", Price = 20 };
            var balls = new List<Ball> { ball }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Ball>>();
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.Provider).Returns(balls.Provider);
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.Expression).Returns(balls.Expression);
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.ElementType).Returns(balls.ElementType);
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.GetEnumerator()).Returns(balls.GetEnumerator());

            _contextMock.Setup(c => c.Balls).Returns(dbSetMock.Object);

            // Act
            var result = _controller.Details(1);

            // Assert
            var viewResult = result as ViewResult;
            Assert.IsNotNull(viewResult);

            var model = viewResult.Model as BallsDetailsViewModel;
            Assert.IsNotNull(model);
            Assert.AreEqual("Football", model.Category);
        }

        [Test]
        public void AddToCart_Post_ShouldRedirectToDetails()
        {
            // Arrange
            var ball = new Ball { BallId = 1, Category = new Category { Name = "Football" }, Perimeter = 70, Shop = "Shop1", ImageUrl = "image1.jpg", Price = 20 };
            var balls = new List<Ball> { ball }.AsQueryable();

            var dbSetMock = new Mock<DbSet<Ball>>();
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.Provider).Returns(balls.Provider);
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.Expression).Returns(balls.Expression);
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.ElementType).Returns(balls.ElementType);
            dbSetMock.As<IQueryable<Ball>>().Setup(m => m.GetEnumerator()).Returns(balls.GetEnumerator());

            _contextMock.Setup(c => c.Balls).Returns(dbSetMock.Object);

            var model = new AddToCartViewModel { BallId = 1, Quantity = 1 };

            // Act
            var result = _controller.AddToCart(model);

            // Assert
            var redirectToActionResult = result as RedirectToActionResult;
            Assert.IsNotNull(redirectToActionResult);
            Assert.AreEqual("Details", redirectToActionResult.ActionName);
            Assert.AreEqual("Balls", redirectToActionResult.ControllerName);
            Assert.AreEqual(1, redirectToActionResult.RouteValues["id"]);
        }
    }
}