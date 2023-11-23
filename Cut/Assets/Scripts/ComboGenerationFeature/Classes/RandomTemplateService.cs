using System.Collections.Generic;
using UnityEngine;

namespace Cut
{
    public class RandomTemplateService : IRandomTemplateService
    {
        private CombosTemplatesSO _templates;

        public RandomTemplateService(CombosTemplatesSO combosTemplatesSO) 
        {
            _templates = combosTemplatesSO;
        }

        public List<int> GetRandomTemplate()
        {
            int randomIndex = Random.Range(0, _templates.Combos.Count);
            return _templates.GetCombo(randomIndex);
        }
    }
}