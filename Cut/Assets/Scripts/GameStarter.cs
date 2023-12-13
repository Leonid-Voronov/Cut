using UnityEngine;
using Zenject;

namespace Cut
{
    public class GameStarter
    {
        private IComboSwitcher _comboSwitcher;
        private ITimerHolder _timerHolder;

        [Inject]
        public GameStarter(IComboSwitcher comboSwitcher, ITimerHolder timerHolder)
        {
            _comboSwitcher = comboSwitcher;
            _timerHolder = timerHolder;
        }

        public void StartGame()
        {
            _timerHolder.SubscribeToStartCondition();
            _comboSwitcher.SwitchCombo();
        }
    }
}