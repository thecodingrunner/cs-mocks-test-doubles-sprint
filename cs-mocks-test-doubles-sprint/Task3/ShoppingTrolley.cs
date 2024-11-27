namespace cs_mocks_test_doubles_sprint.Task3
{
    public class ShoppingTrolley
    {
        private CheckoutUtils _checkoutUtils;
        public ShoppingTrolley(CheckoutUtils cu)
        {
            _checkoutUtils = cu;
        }

        public decimal CalculateTotalPrice(List<TrolleyItem> trolleyItems)
        {
            decimal totalPrice = 0.0m;
            for (int i = 0; i < trolleyItems.Count; i++)
            {
                decimal price = (decimal)_checkoutUtils.CalculateIndividualItem(trolleyItems[i]);
                if (price >= 50)
                {
                    price = _checkoutUtils.DiscountPurchase(trolleyItems[i]);
                }
                totalPrice += (decimal)price;
            }
            return totalPrice;
        }
    }
}
