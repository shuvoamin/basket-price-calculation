using System.Collections.Generic;
using System.Linq;

namespace PriceCalculation
{
    public class MilkOffer : IOffer
    {
        public MilkOffer(int minMilkForDiscount)
        {
            MinMilkForDiscount = minMilkForDiscount;
        }

        public int MinMilkForDiscount { get; set; }

        public decimal GetOfferTotal(IEnumerable<Product> products)
        {
            decimal totalDiscount = 0.00m;

            if (products.Count(p => p.Type == ProductType.Milk) >= MinMilkForDiscount)
            {
                IEnumerable<IGrouping<int, (Product Item, int Grouping)>> productsByIndex =
                    products.Select((p, i) => (Item: p, Grouping: (i / MinMilkForDiscount))).GroupBy(p => p.Grouping);
                decimal milkPrice = products.FirstOrDefault(p => p.Type == ProductType.Milk).Price;

                foreach (var item in productsByIndex)
                {
                    if (item.Count() >= MinMilkForDiscount)
                    {
                        totalDiscount += milkPrice;
                    }
                }
            }

            return totalDiscount;
        }
    }
}
