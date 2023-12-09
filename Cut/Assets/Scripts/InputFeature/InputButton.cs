using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace Cut
{
    public class InputButton : MonoBehaviour
    {
        [Inject]
        public void Construct(GameplayMediator gameplayMediator)
        {
            _gameplayMediator = gameplayMediator;
        }

        [SerializeField] private Button _button;
        [SerializeField] private int _buttonNumber;

        private GameplayMediator _gameplayMediator;

        private void OnEnable()
        {
            _button.onClick.AddListener(PressButton);
        }

        public void PressButton()
        {
            _gameplayMediator.PassButtonToCombo(_buttonNumber);
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PressButton);
        }
    }
}

