using System.Collections.Generic;
using UnityEngine;

namespace Cut
{
    [CreateAssetMenu(fileName = "Buttons", menuName = "ScriptableObjects/Buttons", order = 2)]
    public class ButtonsHolderSO : ScriptableObject
    {
        [SerializeField] private List<int> _buttons;
        [SerializeField] private List<int> _leftButtons;
        [SerializeField] private List<int> _rightButtons;

        public List<int> LeftButtons => _leftButtons;
        public List<int> RightButtons => _rightButtons;
        public List<int> Buttons => _buttons;
    }
}

