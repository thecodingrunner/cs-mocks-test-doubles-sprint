using cs_mocks_test_doubles_sprint.Task1;

namespace cs_mocks_test_doubles_sprint.Task2
{
    public class AdvancedMaths
    {
        private IBasicMaths _basicMaths;
        public AdvancedMaths(IBasicMaths basicMaths)
        {
            _basicMaths = basicMaths;
        }

        public int MultiplyIntsAndAddFive(int num1, int num2)
        {
            int multiplied = _basicMaths.Multiply(num1, num2);
            int fiveAdded = _basicMaths.Add(multiplied, 5);
            return fiveAdded;
        }

        public double AddIntsAndDivideTotalBy2(int num1, int num2)
        {
            int addedInts = _basicMaths.Add(num1, num2);
            double dividedInts = _basicMaths.Divide(addedInts, 2);
            return dividedInts;
        }

        public double QuarterAndSubtractOne(int num1)
        {
            int quarteredInt = (int)Math.Round(_basicMaths.Divide(num1, 4));
            int oneSubtracted = _basicMaths.Subtract(quarteredInt, 1);
            return oneSubtracted;
        }

        public double MultiplyAndDivide(int num1, int num2, int num3)
        {
            int multiplied = _basicMaths.Multiply(num1, num2);
            double divided = _basicMaths.Divide(multiplied, num3);
            return divided;
        }
    }
}
