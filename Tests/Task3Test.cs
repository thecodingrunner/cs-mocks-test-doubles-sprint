using cs_mocks_test_doubles_sprint.Task1;
using cs_mocks_test_doubles_sprint.Task3;
using Moq;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class Task3Test
    {
        [Test, Description("CalculateTotalPrice invokes CalculateIndividualItem")]
        public void CalculateIndividualItemTest()
        {
            //Arrange
            var item1 = new TrolleyItem("Wonderful painted goose", 10.5m, 1);
            var item2 = new TrolleyItem("Excellent crocheted moorhen", 5.1m, 3);
            var item3 = new TrolleyItem("Tiny glass duck", 0.2m, 1);
            var testTrolleyItems = new List<TrolleyItem> { item1, item2, item3 };

            var mockCheckoutUtils = new Mock<CheckoutUtils>();
            var testShoppingTrolleyWithMock = new ShoppingTrolley(mockCheckoutUtils.Object);

            //Act
            testShoppingTrolleyWithMock.CalculateTotalPrice(testTrolleyItems);

            //Assert
            mockCheckoutUtils.Verify(m => m.CalculateIndividualItem(item1), Times.Once());
            mockCheckoutUtils.Verify(m => m.CalculateIndividualItem(item2), Times.Once());
            mockCheckoutUtils.Verify(m => m.CalculateIndividualItem(item3), Times.Once());
        }

        [Test, Description("Returns 93.4m when passed trolleyItemsA")]
        public void CalculateTotalPriceWithReductionsTests()
        {
            //Arrange
            var itemA1 = new TrolleyItem("Wonderful painted goose", 10m, 5);
            var itemA2 = new TrolleyItem("Excellent crocheted moorhen", 2.5m, 3);
            var itemA3 = new TrolleyItem("Exceptional porcelain sandpiper", 51m, 1);

            var trolleyItemsA = new List<TrolleyItem> { itemA1, itemA2, itemA3 };

            decimal expected = 93.4m;

            var checkoutUtils = new CheckoutUtils();
            var shoppingTrolley = new ShoppingTrolley(checkoutUtils);

            //var mockCheckoutUtils = new Mock<CheckoutUtils>();
            //var testShoppingTrolleyWithMock = new ShoppingTrolley(mockCheckoutUtils.Object);

            //Act
            //decimal result = testShoppingTrolleyWithMock.CalculateTotalPrice(trolleyItemsA);
            decimal result = shoppingTrolley.CalculateTotalPrice(trolleyItemsA);

            //Assert
            Assert.AreEqual(expected, result);
        }

        [Test, Description("CalculateTotalPrice invokes DiscountPurchase")]
        public void DiscountPurchaseInvocationTest()
        {
            //Arrange
            var itemB1 = new TrolleyItem("Wonderful painted goose", 10m, 1);
            var itemB2 = new TrolleyItem("Excellent crocheted moorhen", 30m, 3);
            var itemB3 = new TrolleyItem("Exceptional porcelain sandpiper", 49.99m, 1);

            var trolleyItemsB = new List<TrolleyItem> { itemB1, itemB2, itemB3 };

            decimal expected = 93.4m;

            var mockCheckoutUtils = new Mock<CheckoutUtils>();
            var checkoutUtils = new CheckoutUtils();
            
            var testShoppingTrolleyWithMock = new ShoppingTrolley(mockCheckoutUtils.Object);
            var shoppingTrolley = new ShoppingTrolley(checkoutUtils);

            mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(itemB1)).Returns(checkoutUtils.CalculateIndividualItem(itemB1));
            mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(itemB2)).Returns(checkoutUtils.CalculateIndividualItem(itemB2));
            mockCheckoutUtils.Setup(m => m.CalculateIndividualItem(itemB3)).Returns(checkoutUtils.CalculateIndividualItem(itemB3));

            //Act
            decimal result = testShoppingTrolleyWithMock.CalculateTotalPrice(trolleyItemsB);

            mockCheckoutUtils.Verify(m => m.DiscountPurchase(itemB2), Times.Once());
            mockCheckoutUtils.Verify(m => m.DiscountPurchase(itemB1), Times.Never());
            mockCheckoutUtils.Verify(m => m.DiscountPurchase(itemB3), Times.Never());
        }
    }
}
