using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cs_mocks_test_doubles_sprint.Task3
{
    public class CheckoutUtils
    {
        public virtual double CalculateIndividualItem(TrolleyItem trolleyItem)
        {
            return (double)trolleyItem.Price * trolleyItem.Quantity;
        }

        public virtual decimal DiscountPurchase(TrolleyItem trolleyItem)
        {
            decimal price = trolleyItem.Price * trolleyItem.Quantity;
            price *= trolleyItem.Quantity > 3 ? 0.8m : 0.9m;
            return price;
        }
    }
}
