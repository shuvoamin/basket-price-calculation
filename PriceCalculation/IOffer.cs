using System.Collections.Generic;

namespace PriceCalculation
{
    public interface IOffer
    {
        decimal GetOfferTotal(IEnumerable<Product> products);
    }
}
