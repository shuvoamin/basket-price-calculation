using System;
using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation
{
    public class Basket
    {
        public IEnumerable<Product> Products { get; set; }

        public IEnumerable<IOffer> Offers { get; set; }

        public decimal GetTotal()
        {
            decimal total = Products?.Sum(p => p.Price) ?? 0.00m;
            decimal totalDiscount = 0.00m;

            Offers?.ToList().ForEach(o => totalDiscount += o.GetOfferTotal(Products));

            return total - totalDiscount;
        }
    }
}
