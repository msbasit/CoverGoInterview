using Microsoft.VisualStudio.TestTools.UnitTesting;
using CoverGo.PairProgramming.Domain;

namespace CoverGo.PairProgramming.Tests
{
    [TestClass]
    public class ShoppingCartTests
    {        
        ShoppingCart _cart;

        public ShoppingCartTests()
        {
            _cart = new ShoppingCart();
        }

        [TestMethod]
        public void AddProductToShoppingCart()
        {            
            var productAAdded = _cart.AddProduct(new Product { Name = "A"});
            var productBAdded = _cart.AddProduct(new Product {Name = "B"});

            Assert.AreEqual(productAAdded, true);
            Assert.AreEqual(productBAdded, true);
        }

        [TestMethod]
        public void CalculateCartTotal()
        {
            var prod_tShirt = new Product { Name = "T-Shirt"};
            prod_tShirt.Price = 10;

            var prod_Jeans = new Product {Name = "Jeans"};
            prod_Jeans.Price = 20;

            _cart.AddProduct(prod_tShirt);
            _cart.AddProduct(prod_Jeans);

            var cartTotal = _cart.CalculateTotal();

            Assert.AreEqual(cartTotal, 30);
        }

        [TestMethod]
        public void CalculateProductTotal()
        {
            var product = new Product {Name = "Jeans", Price = 20};
            _cart.AddProduct(product, 3);

            Assert.AreEqual(_cart.CalculateTotal("Jeans"), 3 * product.Price);
        }

        [TestMethod]
        public void ApplyQuantityDiscountOnJeans()
        {
            var product_Jeans = new Product {Name = "Jeans", Price = 20};            

            _cart.AddProduct(product_Jeans, 3);
            var quantityDiscount = _cart.ApplyQuantityDiscount("Jeans", 3, 2);            

            Assert.AreEqual(40m, quantityDiscount);
        }

        [TestMethod]
        public void ApplyQuantityDiscountOnJeans_5()
        {
            var product_Jeans = new Product {Name = "Jeans", Price = 20};            

            _cart.AddProduct(product_Jeans, 5);
            var quantityDiscount = _cart.ApplyQuantityDiscount("Jeans", 5, 2);           

            Assert.AreEqual(40m, quantityDiscount);
        }

        [TestMethod]
        public void ApplyQuantityDiscountOnJeans_6()
        {
            var product_Jeans = new Product {Name = "Jeans", Price = 20};

            _cart.AddProduct(product_Jeans, 6);
            var quantityDiscount = _cart.ApplyQuantityDiscount("Jeans", 6, 2);            

            Assert.AreEqual(40m, quantityDiscount);
        }
    }
}