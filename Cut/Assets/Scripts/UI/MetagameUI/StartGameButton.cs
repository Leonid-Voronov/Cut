using UnityEngine;
using Zenject;
using UnityEngine.UI;
using System;

namespace UI.MetagameUI
{
    public class StartGameButton : MonoBehaviour, IStartGameButton
    {
        [SerializeField] private Button _button;
        private IMetagameMediatorToLogic _metagameMediatorToLogic;
        public event EventHandler StartButtonPressed;
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
            OnStartButtonPress();
        }

        private void OnStartButtonPress()
        {
            StartButtonPressed?.Invoke(this, EventArgs.Empty);
        }

        private void OnDisable() 
        {
            _button.onClick.RemoveListener(PressStartButton);
        }
    }
}

