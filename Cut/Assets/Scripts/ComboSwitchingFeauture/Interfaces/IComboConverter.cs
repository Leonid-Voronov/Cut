using System.Collections.Generic;

namespace ComboSwitchingFeature
{
    public interface IComboConverter 
    {
        List<string> ConvertCombo(List<int> combo);
    }
}