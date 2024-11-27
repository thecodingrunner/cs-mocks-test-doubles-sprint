using cs_mocks_test_doubles_sprint.Task1;
using FluentAssertions;

namespace Tests
{
    public class TaskOneTests
    {
        [Test, Description("Returns the result when one integer is evenly divided by a factor of itself")]
        public void Divide_Evenly()
        {
            //Arrange
            var testBasicMaths = new BasicMaths();
            //Act
            var result = testBasicMaths.Divide(4, 2);
            //Assert
            Assert.That(result, Is.EqualTo(2));
        }
        [Test, Description("Returns the result when the divisor is not a factor of the dividend")]
        public void Divide_Unevenly()
        {
            //Arrange
            var testBasicMaths = new BasicMaths();
            //Act
            var result = testBasicMaths.Divide(5, 2);
            //Assert
            Assert.That(result, Is.EqualTo(2.5));
        }
        [Test, Description("Throws an error if an attempt is made to pass 0 as a divisor")]
        public void Divide_ByZero()
        {
            //Arrange
            var testBasicMaths = new BasicMaths();
            //Act
            //Assert
            Assert.That(() => testBasicMaths.Divide(5, 0), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        // Add tests for BasicMaths Class
        [Test, Description("Returns 2 when the Divide method is passed 6 and 3")]
        [TestCase(6, 3, 2)]
        public void DivideTest(int num1, int num2, double expected)
        {
            //Arrange 
            BasicMaths basicMaths = new BasicMaths();

            //Act 
            double result = basicMaths.Divide(num1, num2);

            //Assert 
            result.Should().Be(expected);
        }

        [Test, Description("Returns 6 when the Divide method is passed 3 and 2")]
        [TestCase(3, 2, 6)]
        public void MultiplyTest(int num1, int num2, double expected)
        {
            //Arrange 
            BasicMaths basicMaths = new BasicMaths();

            //Act 
            double result = basicMaths.Multiply(num1, num2);

            //Assert 
            result.Should().Be(expected);
        }

        [Test, Description("Returns 5 when the Add method is passed 2 and 3")]
        [TestCase(2, 3, 5)]
        public void AddTest(int num1, int num2, int expected)
        {
            //Arrange 
            BasicMaths basicMaths = new BasicMaths();

            //Act 
            int result = basicMaths.Add(num1, num2);

            //Assert 
            result.Should().Be(expected);
        }

        [Test, Description("Returns 2 when the Subtract method is passed 5 and 3")]
        [TestCase(5, 3, 2)]
        public void SubtractTest(int num1, int num2, int expected)
        {
            //Arrange 
            BasicMaths basicMaths = new BasicMaths();

            //Act 
            int result = basicMaths.Subtract(num1, num2);

            //Assert
            result.Should().Be(expected);
        }


    }
}