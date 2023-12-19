using Assets.Scripts;
using UnityEngine;
using Zenject;
using Cut;

namespace UI.GameplayUI
{
    public class GameplayMediatorToLogic : MonoBehaviour, IGameplayMediatorToLogic
    {
        private IComboHolder _comboHolder;
        private IGameReseter _gameReseter;

        [Inject]
        public void Construct(IComboHolder comboHolder, IGameReseter gameReseter)
        {
            _comboHolder = comboHolder;
            _gameReseter = gameReseter;
        }

        public void PassButtonToCombo(int buttonNumber) => _comboHolder.AddButtonToCombo(buttonNumber);
        public void ExitToMenu() => _gameReseter.ResetGame();
    }
}