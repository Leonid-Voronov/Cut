using System.Collections.Generic;
using UnityEngine;

namespace ComboGenerationFeature
{
    [CreateAssetMenu(fileName = "CombosTemplates", menuName = "ScriptableObjects/Combos", order = 1)]
    public class CombosTemplatesSO : ScriptableObject
    {
        [SerializeField] private List<Combo> _combos;

        public List<Combo> Combos => _combos;
        public List<int> GetCombo(int index) 
        {
            return _combos[index].Value; 
        }
    }

    [System.Serializable]
    public class Combo
    {
        [SerializeField] private List<int> _combo;
        public List<int> Value => _combo;
    }
}

