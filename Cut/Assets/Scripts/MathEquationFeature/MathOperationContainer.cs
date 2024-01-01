using System.Collections.Generic;
using UnityEngine;

namespace MathEquationFeature
{
    public class MathOperationContainer : IMathOperationContainer
    {

        private List<MathOperation> _mathOperations = new List<MathOperation>
        {
            { MathOperation.Addition },
            { MathOperation.Subtraction },
            { MathOperation.Multiply },
            { MathOperation.Divide }
        };
        public MathOperation GetRandomMathOperation()
        {
            return _mathOperations[Random.Range(0, _mathOperations.Count)];
        }
    }
}