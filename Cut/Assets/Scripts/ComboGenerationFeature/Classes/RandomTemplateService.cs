using System.Collections.Generic;
using UnityEngine;

namespace ComboGenerationFeature
{
    public class RandomTemplateService : IRandomTemplateService
    {
        private CombosTemplatesHolder _templatesHolder;

        public RandomTemplateService(CombosTemplatesHolder combosTemplatesHolder) 
        {
            _templatesHolder = combosTemplatesHolder;
        }

        public List<int> GetRandomTemplate()
        {
            CombosTemplatesSO combosTemplates = _templatesHolder.CurrentCombosTemplates;
            int randomIndex = Random.Range(0, combosTemplates.Combos.Count);
            return combosTemplates.GetCombo(randomIndex);
        }
    }
}