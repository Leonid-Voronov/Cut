using UnityEngine;
using Zenject;

namespace Cut
{
    public class GameStarter
    {
        private IComboSwitcher _comboSwitcher;
        private ITimerHolder _timerHolder;
        private GameMediator _gameMediator;

        [Inject]
        public GameStarter(IComboSwitcher comboSwitcher, ITimerHolder timerHolder, GameMediator gameMediator)
        {
            _comboSwitcher = comboSwitcher;
            _timerHolder = timerHolder;
            _gameMediator = gameMediator;
        }

        public void StartGameWithButton()
        {
            _gameMediator.SwitchToGameplayUI();
            StartGame();
        }

        public void StartGame()
        {
            _timerHolder.SubscribeToStartCondition();
            _comboSwitcher.SwitchCombo();
        }
    }
}