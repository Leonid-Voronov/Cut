using System.Collections.Generic;

namespace ComboGenerationFeature
{
    public interface IListUniqueService
    {
        List<int> GetUniqueElements(List<int> template);
    }
}