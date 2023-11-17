using System.Collections.Generic;
using UnityEngine;

namespace Cut
{
    public interface IRandomTemplateService
    {
        public List<int> GetRandomTemplate(CombosTemplatesSO templates);
    }
}