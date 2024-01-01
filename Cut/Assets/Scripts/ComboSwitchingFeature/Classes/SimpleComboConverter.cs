using System.Collections.Generic;

namespace ComboSwitchingFeature
{
    public class SimpleComboConverter : IComboConverter
    {
        public List<string> ConvertCombo(List<int> combo)
        {
            List<string> result = new List<string>();
            foreach(int item in combo)
                result.Add(item.ToString());

            return result;
        }
    }
}