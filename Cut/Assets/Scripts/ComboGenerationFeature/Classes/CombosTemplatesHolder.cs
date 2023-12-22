using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace ComboGenerationFeature
{
    public class CombosTemplatesHolder
    {
        private Dictionary<CombosTemplatesName, CombosTemplatesSO> _combosTemplates;
        private CombosTemplatesSO _currentCombosTemplates;
        public CombosTemplatesSO CurrentCombosTemplates => _currentCombosTemplates;

        [Inject]
        public CombosTemplatesHolder(Dictionary<CombosTemplatesName, CombosTemplatesSO> combosTemplates)
        {
            _combosTemplates = combosTemplates;
            _currentCombosTemplates = _combosTemplates[CombosTemplatesName.Default];
        }

        public void SetCurrentCombosTemplates(CombosTemplatesName newCombosTemplatesName)
        {
            //Debug.Log(newCombosTemplatesName);
            _currentCombosTemplates = _combosTemplates[newCombosTemplatesName];
        }
    }
}

