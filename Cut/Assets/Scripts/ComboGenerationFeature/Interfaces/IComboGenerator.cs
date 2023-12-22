using System.Collections.Generic;

namespace ComboGenerationFeature
{
    public interface IComboGenerator
    {
        List<int> GenerateCombo(List<int> template);
    }
}