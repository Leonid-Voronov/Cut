using Cut;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace UI.GameplayUI
{
    public class GameplayToMenuButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IGameplayMediatorToLogic _gameplayMediatorToLogic;

        [Inject]
        public void Construct(IGameplayMediatorToLogic gameplayMediatorToLogic)
        {
            _gameplayMediatorToLogic = gameplayMediatorToLogic;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(ExitToMenu);
        }

        private void ExitToMenu()
        {
            _gameplayMediatorToLogic.ExitToMenu();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(ExitToMenu);
        }
    }
}


