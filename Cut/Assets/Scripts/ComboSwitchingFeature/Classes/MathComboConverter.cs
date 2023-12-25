using MathEquationFeature;
using System.Collections.Generic;

namespace ComboSwitchingFeature
{
    public class MathComboConverter : IComboConverter
    {
        private MathExpressionCreator _mathExpressionCreator;

        public MathComboConverter(MathExpressionCreator mathExpressionCreator)
        {
            _mathExpressionCreator = mathExpressionCreator;
        }

        public List<string> ConvertCombo(List<int> combo)
        {
            List<string> result = new List<string>();
            foreach (int item in combo)
            {
                result.Add(_mathExpressionCreator.CreateExpression(item) + " ");
            }

            return result;
        }
    }
}