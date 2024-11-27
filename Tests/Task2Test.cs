using cs_mocks_test_doubles_sprint.Task1;
using cs_mocks_test_doubles_sprint.Task2;
using FluentAssertions;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    internal class Task2Test
    {
        [Test, Description("MultiplyIntsAndAddFive invokes multiply method and add method from mockBasicMaths, and returns a value of 6")]
        [TestCase(1,1,1,6)]
        public void MultiplyIntsAndAddFiveInvokesMultiplyTest(int input1, int input2, int intermediate, int expected)
        {
            var basicMaths = new BasicMaths();

            var mockBasicMaths = new Mock<IBasicMaths>();

            mockBasicMaths.Setup(m => m.Multiply(input1, input2)).Returns(basicMaths.Multiply(input1, input2));
            mockBasicMaths.Setup(m => m.Add(intermediate, 5)).Returns(basicMaths.Add(intermediate, 5));

            //var AdvancedMath = new AdvancedMaths(basicMaths);
            var testAdvancedMathWithMock = new AdvancedMaths(mockBasicMaths.Object);

            //Act
            var result = testAdvancedMathWithMock.MultiplyIntsAndAddFive(input1, input2);

            //Assert
            mockBasicMaths.Verify(m => m.Multiply(1, 1), Times.Once());
            mockBasicMaths.Verify(m => m.Add(1, 5), Times.Once());
            result.Should().Be(expected);
        }

        [Test, Description("AddIntsAndDivideTotalBy2 invokes Add method and Divide method from mockBasicMaths, and returns a value of 7.5")]
        [TestCase(10,5,15,7.5)]
        public void AddIntsAndDivideTotalBy2InvokesAddTest(int input1, int input2, int intermediate, double expected)
        {
            var BasicMaths = new BasicMaths();

            var mockBasicMaths = new Mock<IBasicMaths>();

            mockBasicMaths.Setup(m => m.Add(input1, input2)).Returns(BasicMaths.Add(input1, input2));
            mockBasicMaths.Setup(m => m.Divide(intermediate, 2)).Returns(BasicMaths.Divide(intermediate, 2));

            var AdvancedMath = new AdvancedMaths(mockBasicMaths.Object);

            //Act
            var result = AdvancedMath.AddIntsAndDivideTotalBy2(input1, input2);

            //Assert
            mockBasicMaths.Verify(m => m.Add(input1, input2), Times.Once());
            mockBasicMaths.Verify(m => m.Divide(intermediate, 2), Times.Once());
            result.Should().Be(expected);
        }

        [Test, Description("QuarterAndSubtractOne invokes Divide method and Subtract method from mockBasicMaths and returns a value of 2")]
        [TestCase(19, 5, 4)]
        public void QuarterAndSubtractOneTest(int input1, int intermediate, double expected)
        {
            // Arrange
            var BasicMaths = new BasicMaths();

            var mockBasicMaths = new Mock<IBasicMaths>();

            mockBasicMaths.Setup(m => m.Divide(input1, 4)).Returns(BasicMaths.Divide(input1, 4));
            mockBasicMaths.Setup(m => m.Subtract(intermediate, 1)).Returns(BasicMaths.Subtract(intermediate, 1));

            var AdvancedMath = new AdvancedMaths(mockBasicMaths.Object);

            //Act
            var result = AdvancedMath.QuarterAndSubtractOne(input1);

            //Assert
            mockBasicMaths.Verify(m => m.Divide(input1, 4), Times.Once());
            mockBasicMaths.Verify(m => m.Subtract(intermediate, 1), Times.Once());
            result.Should().Be(expected);
        }

        [Test, Description("MultiplyAndDivide invokes Multiply method and Divide method from mockBasicMaths and returns a value of 2.4")]
        [TestCase(3, 4, 5, 12, 2.4)]
        public void MultiplyAndDivide(int input1, int input2, int input3, int intermediate, double expected)
        {
            // Arrange
            var BasicMaths = new BasicMaths();

            var mockBasicMaths = new Mock<IBasicMaths>();

            mockBasicMaths.Setup(m => m.Multiply(input1, input2)).Returns(BasicMaths.Multiply(input1, input2));
            mockBasicMaths.Setup(m => m.Divide(intermediate, input3)).Returns(BasicMaths.Divide(intermediate, input3));

            var AdvancedMath = new AdvancedMaths(mockBasicMaths.Object);

            //Act
            var result = AdvancedMath.MultiplyAndDivide(input1, input2, input3);

            //Assert
            mockBasicMaths.Verify(m => m.Multiply(input1, input2), Times.Once());
            mockBasicMaths.Verify(m => m.Divide(intermediate, input3), Times.Once());
            result.Should().Be(expected);
        }
    }
}
