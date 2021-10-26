using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation
{
    public class BreadOffer : IOffer
    {
        public BreadOffer(int minButterForDiscount, decimal discountRate)
        {
            MinButterForDiscount = minButterForDiscount;
            DiscountRate = discountRate;
        }

        public int MinButterForDiscount { get; set; }
        public decimal DiscountRate { get; set; }

        public decimal GetOfferTotal(IEnumerable<Product> products)
        {
            decimal totalDiscount = 0.00m;
            var totalButter = products.Count(p => p.Type == ProductType.Butter);

            if (totalButter >= MinButterForDiscount && products.Count(p => p.Type == ProductType.Bread) > 0)
            {
                int totalButterCombo = (int)decimal.Truncate(totalButter / MinButterForDiscount);

                // assume this rule, bread has a flat rate
                decimal breadPrice = products.FirstOrDefault(p => p.Type == ProductType.Bread).Price;

                var totalBread = products.Count(p => p.Type == ProductType.Bread);

                for (int i = 0; i < totalButterCombo; i++)
                {
                    totalDiscount = breadPrice - (breadPrice * DiscountRate);
                }
            }

            return totalDiscount;
        }
    }
}