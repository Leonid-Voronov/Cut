using System.Collections.Generic;

namespace ComboSwitchingFeauture
{
    public interface IComboConverter 
    {
        List<string> ConvertCombo(List<int> combo);
    }
}