using System.Collections.Generic;

namespace Cut
{
    public interface IListRandomService
    {
        int GetRandomAvailableButton(ref List<int> availableButtons);
    }
}