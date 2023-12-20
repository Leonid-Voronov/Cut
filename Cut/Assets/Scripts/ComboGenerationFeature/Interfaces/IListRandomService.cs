using System.Collections.Generic;

namespace ComboGenerationFeature
{
    public interface IListRandomService
    {
        int GetRandomAvailableButton(ref List<int> availableButtons);
    }
}