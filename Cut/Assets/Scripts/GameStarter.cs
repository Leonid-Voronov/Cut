using Zenject;
using GameplayVisualsFeature;
using ComboSwitchingFeature;
using UI;
using TimerFeature;

namespace Core
{
    public class GameStarter
    {
        private IComboSwitcher _comboSwitcher;
        private ITimerHolder _timerHolder;
        private GameMediator _gameMediator;
        private GameplayVisualsSetter _gameplayVisualsSetter;

        [Inject]
        public GameStarter(IComboSwitcher comboSwitcher, ITimerHolder timerHolder, GameMediator gameMediator, GameplayVisualsSetter gameplayVisualsSetter)
        {
            _comboSwitcher = comboSwitcher;
            _timerHolder = timerHolder;
            _gameMediator = gameMediator;
            _gameplayVisualsSetter = gameplayVisualsSetter;
        }

        public void StartGameWithButton()
        {
            _gameMediator.SwitchToGameplayUI();
            StartGame();
        }

        public void StartGame()
        {
            _timerHolder.SubscribeToStartCondition();
            _gameplayVisualsSetter.SwitchGameplayVisualsOnScene();
            _comboSwitcher.SwitchCombo();
        }
    }
}