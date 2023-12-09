using UnityEngine;
using Zenject;

namespace Cut
{
    public class GameplayMediatorToLogic : MonoBehaviour, IGameplayMediatorToLogic
    {
        [Inject]
        public void Construct(IComboHolder comboHolder)
        {
            _comboHolder = comboHolder;
        }

        private IComboHolder _comboHolder;
        public void PassButtonToCombo(int buttonNumber) => _comboHolder.AddButtonToCombo(buttonNumber);
    }
}