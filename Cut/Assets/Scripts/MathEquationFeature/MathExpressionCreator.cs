using Zenject;

namespace MathEquationFeature
{
    public class MathExpressionCreator
    {
        private INumberRandomizer _numberRandomizer;
        private IMathOperationContainer _mathOperationContainer;

        [Inject]
        public MathExpressionCreator(INumberRandomizer numberRandomizer, IMathOperationContainer mathOperationContainer) 
        {
            _numberRandomizer = numberRandomizer;
            _mathOperationContainer = mathOperationContainer;
        }

        public string CreateExpression(int expResult)
        {
            MathOperation operation = _mathOperationContainer.GetRandomMathOperation();
            while ((operation == MathOperation.Multiply && IsNumberPrime(expResult)) || (operation != MathOperation.Subtraction && expResult == 1))
                operation = _mathOperationContainer.GetRandomMathOperation();

            string expression = "";
            int thirdNumber, randomNumber;

            randomNumber = _numberRandomizer.GetRandomNumber(operation, expResult);
            switch (operation)
            {
                case MathOperation.Addition:
                    thirdNumber = expResult - randomNumber;
                    expression = randomNumber.ToString() + "+" + thirdNumber.ToString();
                    break;
                case MathOperation.Subtraction:
                    thirdNumber = randomNumber - expResult;
                    expression = randomNumber.ToString() + "-" + thirdNumber.ToString();
                    break;
                case MathOperation.Multiply:
                    thirdNumber = expResult / randomNumber;
                    expression = randomNumber.ToString() + "x" + thirdNumber.ToString();
                    break;
                case MathOperation.Divide:
                    thirdNumber = expResult * randomNumber;
                    expression = thirdNumber.ToString() + ":" + randomNumber.ToString();
                    break;
            }

            return expression;
        }

        public bool IsNumberPrime(int number)
        {
            for (int i = 2; i < number; i++)
                if (number % i == 0)
                    return false;

            return true;
        }
    }
}

