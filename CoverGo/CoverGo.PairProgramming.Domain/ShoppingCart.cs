using System;
using System.Collections.Generic;
using System.Linq;

namespace CoverGo.PairProgramming.Domain
{
    public class ShoppingCart
    {
        List<Product> _cartItems = new List<Product>();

        public ShoppingCart()
        {
            _cartItems = new List<Product>();
        }

        public bool AddProduct(Product product)
        {
            _cartItems.Add(product);
            return true;
        }

        public decimal CalculateTotal()
        {
            var result = 0.0m;

            foreach(var product in _cartItems)
            {
                result += product.Price;
            }

            return result;
        }

        public decimal ApplyQuantityDiscount(string productName, int actualQuantity, int discountQuantity)
        {
            var productCount = _cartItems.Where(p => p.Name == productName)?.Count();
            if(productCount.HasValue)
            {
                var discountedQuantity = Convert.ToInt32(productCount.Value / actualQuantity) * discountQuantity;
                var product = _cartItems.FirstOrDefault(p => p.Name == productName);
                return discountedQuantity * product.Price;
            }
            else
            {
                return 0;
            }
        }

        public decimal CalculateTotal(string productName)
        {
            var total = _cartItems.Where(p => p.Name == productName)?.Sum(p => p.Price);
            if (total.HasValue)
            {
                return total.Value;
            }
            else
            {
                return 0.0m;
            }
        }

        public bool AddProduct(Product product, int quantity)
        {
            for(int i =0; i < quantity; i++)
            {
                _cartItems.Add(product);
            }

            return true;
        }
    }
}