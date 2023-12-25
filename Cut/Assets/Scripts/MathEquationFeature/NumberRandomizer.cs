using UnityEngine;

namespace MathEquationFeature
{
    public class NumberRandomizer : INumberRandomizer
    {
        public int GetRandomNumber(MathOperation mathOperation, int expResult)
        {
            int maxNumber = 10;
            int randomNumber = -1;

            switch (mathOperation)
            {
                case MathOperation.Addition:
                    randomNumber = Random.Range(1, expResult);
                    if (randomNumber == expResult)
                        randomNumber = GetRandomNumber(mathOperation, expResult);
                    return randomNumber;
                case MathOperation.Subtraction:
                    randomNumber = Random.Range(expResult + 1, maxNumber);
                    if (randomNumber == expResult)
                        randomNumber = GetRandomNumber(mathOperation, expResult);
                    return randomNumber;
                case MathOperation.Multiply:
                    randomNumber = Random.Range(1, expResult);
                    if (expResult % randomNumber != 0)
                        randomNumber = GetRandomNumber(mathOperation, expResult);
                    return randomNumber;
                case MathOperation.Divide:
                    randomNumber = Random.Range(expResult, expResult * 2);
                    if (randomNumber % expResult != 0)
                        randomNumber = GetRandomNumber(mathOperation, expResult);
                    return randomNumber;
            }

            return Random.Range(1, 10);
        }
    }
}