using System.Collections.Generic;

namespace Cut
{
    public interface IComboGenerator
    {
        List<int> GenerateCombo(List<int> template);
    }
}