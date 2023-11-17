using System.Collections.Generic;

namespace Cut
{
    public interface IListUniqueService
    {
        List<int> GetUniqueElements(List<int> template);
    }
}