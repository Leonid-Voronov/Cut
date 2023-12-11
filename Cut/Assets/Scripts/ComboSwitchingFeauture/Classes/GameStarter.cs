using UnityEngine;
using Zenject;

namespace Cut
{
    public class GameStarter : MonoBehaviour
    {
        private IComboSwitcher _comboSwitcher;
        private ITimerHolder _timerHolder;

        [Inject]
        public void Construct(IComboSwitcher comboSwitcher, ITimerHolder timerHolder)
        {
            _comboSwitcher = comboSwitcher;
            _timerHolder = timerHolder;
        }

        private void Start()
        {
            _timerHolder.SubscribeToStartCondition();
            _comboSwitcher.SwitchCombo();
        }
    }
}