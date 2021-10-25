using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace PriceCalculation.UnitTests
{
    /// <summary>
    ///  all below object initialisation could be moqed up by third party libraies or manually,
    ///  using a simple manual init for the brevity of this task
    /// </summary>

    [TestClass]
    public class OfferTests
    {
        [TestMethod]
        public void Single_Butter_And_Bread_Only_Discount_Scenario()
        {
            // Arrange
            IEnumerable<Product> products = new List<Product>
            {
                new Product { Price = 0.80m, Type = ProductType.Butter },
                new Product { Price = 1.00m, Type = ProductType.Bread },
                new Product { Price = 1.15m, Type = ProductType.Milk },
            };
            var basket = new Basket
            {
                Products = products,
                Offers = new List<IOffer> { new BreadOffer(2, 0.50m) }
            };

            // Act
            var result = decimal.Round(basket.GetTotal(), 2, System.MidpointRounding.AwayFromZero);

            // Asserts
            Assert.AreEqual(result, 2.95m);
        }

        [TestMethod]
        public void Butter_And_Bread_Only_Discount_Scenario()
        {
            // Arrange
            IEnumerable<Product> products = new List<Product>
            {
                new Product { Price = 0.80m, Type = ProductType.Butter },
                new Product { Price = 0.80m, Type = ProductType.Butter },
                new Product { Price = 1.00m, Type = ProductType.Bread },
                new Product { Price = 1.00m, Type = ProductType.Bread },
            };
            var basket = new Basket
            {
                Products = products,
                Offers = new List<IOffer> { new BreadOffer(2, 0.50m) }
            };

            // Act
            var result = decimal.Round(basket.GetTotal(), 2, System.MidpointRounding.AwayFromZero);

            // Asserts
            Assert.AreEqual(result, 3.10m);
        }

        [TestMethod]
        public void Milk_Only_Discount_Scenario()
        {
            // Arrange
            IEnumerable<Product> products = new List<Product>
            {
                new Product { Price = 1.15m, Type = ProductType.Milk },
                new Product { Price = 1.15m, Type = ProductType.Milk },
                new Product { Price = 1.15m, Type = ProductType.Milk },
                new Product { Price = 1.15m, Type = ProductType.Milk }
            };
            var basket = new Basket
            {
                Products = products,
                Offers = new List<IOffer>
                {
                    new MilkOffer(4)
                }
            };

            // Act
            var result = decimal.Round(basket.GetTotal(), 2, System.MidpointRounding.AwayFromZero);

            // Asserts
            Assert.AreEqual(result, 3.45m);
        }

        [TestMethod]
        public void Butter_And_Bread_And_Milk_Discount_Scenario()
        {
            // Arrange
            IEnumerable<Product> products = new List<Product>
            {
                new Product { Price = 0.80m, Type = ProductType.Butter },
                new Product { Price = 0.80m, Type = ProductType.Butter },
                new Product { Price = 1.00m, Type = ProductType.Bread },
                new Product { Price = 1.15m, Type = ProductType.Milk },
                new Product { Price = 1.15m, Type = ProductType.Milk },
                new Product { Price = 1.15m, Type = ProductType.Milk },
                new Product { Price = 1.15m, Type = ProductType.Milk },
                new Product { Price = 1.15m, Type = ProductType.Milk },
                new Product { Price = 1.15m, Type = ProductType.Milk },
                new Product { Price = 1.15m, Type = ProductType.Milk },
                new Product { Price = 1.15m, Type = ProductType.Milk }
            };
            var basket = new Basket
            {
                Products = products,
                Offers = new List<IOffer>
                {
                    new BreadOffer(2, 0.50m),
                    new MilkOffer(4),
                }
            };

            // Act
            var result = decimal.Round(basket.GetTotal(), 2, System.MidpointRounding.AwayFromZero);

            // Asserts
            Assert.AreEqual(result, 9.00m);
        }

        [TestMethod]
        public void No_Offer_Basket_Scenario()
        {
            // Arrange
            IEnumerable<Product> products = new List<Product>
            {
                new Product { Price = 0.80m, Type = ProductType.Butter },
                new Product { Price = 1.00m, Type = ProductType.Bread },
                new Product { Price = 1.15m, Type = ProductType.Milk },
            };
            var basket = new Basket
            {
                Products = products,
            };

            // Act
            var result = decimal.Round(basket.GetTotal(), 2, System.MidpointRounding.AwayFromZero);

            // Asserts
            Assert.AreEqual(result, 2.95m);
        }

        [TestMethod]
        public void No_Product_Basket_Scenario()
        {
            // Arrange
            var basket = new Basket();

            // Act
            var result = decimal.Round(basket.GetTotal(), 2, System.MidpointRounding.AwayFromZero);

            // Asserts
            Assert.AreEqual(result, 0.00m);
        }
    }
}
