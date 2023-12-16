using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace UI.MetagameUI
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IMetagameMediatorToLogic _metagameMediatorToLogic;
        [Inject]
        public void Construct(IMetagameMediatorToLogic metagameMediatorToLogic)
        {
            _metagameMediatorToLogic = metagameMediatorToLogic;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(PressStartButton);
        }

        private void PressStartButton()
        {
            _metagameMediatorToLogic.StartGame();
        }

        private void OnDisable() 
        {
            _button.onClick.RemoveListener(PressStartButton);
        }
    }
}

