using System.Collections.Generic;
using UnityEngine;

namespace Cut
{
    public class RandomTemplateService : IRandomTemplateService
    {
        public List<int> GetRandomTemplate(CombosTemplatesSO templates)
        {
            int randomIndex = Random.Range(0, templates.Combos.Count);
            return templates.GetCombo(randomIndex);
        }
    }
}