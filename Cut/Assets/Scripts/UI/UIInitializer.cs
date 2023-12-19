using UI.MetagameUI;
using Zenject;
using Cut;

namespace UI
{
    public class UIInitializer : IUIInitializer
    {
        private GameConfigSO _gameConfigSO;
        private GameMediator _gameMediator;
        private IMetagameMediatorToUI _metagameMediatorToUI;

        [Inject]
        public UIInitializer(GameConfigSO gameConfigSO, GameMediator gameMediator, IMetagameMediatorToUI metagameMediatorToUI) 
        {
            _gameConfigSO = gameConfigSO;
            _gameMediator = gameMediator;
            _metagameMediatorToUI = metagameMediatorToUI;
        }

        public void InitializeUI()
        {
            switch (_gameConfigSO.StartMode)
            {
                case StartMode.GameSettingsWindow:
                    _gameMediator.SwitchToMetagameUI();
                    _metagameMediatorToUI.ClearView();
                    _metagameMediatorToUI.ShowSettingsWindow();
                    break;
                case StartMode.Gameplay:
                    _gameMediator.SwitchToGameplayUI();
                    break;
                case StartMode.MainMenu:
                    _gameMediator.SwitchToMetagameUI();
                    _metagameMediatorToUI.ClearView();
                    _metagameMediatorToUI.ShowMenuWindow();
                    break;
                default :
                    _gameMediator.SwitchToGameplayUI();
                    break;
            }
        }
    }
}

