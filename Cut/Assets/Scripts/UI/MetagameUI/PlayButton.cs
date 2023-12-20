using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace UI.MetagameUI
{
    public class PlayButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private IMetagameMediatorToUI _metagameMediatorToUI;

        [Inject]
        public void Construct(IMetagameMediatorToUI metagameMediatorToUI)
        {
            _metagameMediatorToUI = metagameMediatorToUI;
        }

        private void OnEnable()
        {
            _button.onClick.AddListener(PressStartButton);
        }

        private void PressStartButton()
        {
            _metagameMediatorToUI.ShowSettingsWindow();
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PressStartButton);
        }
    }
}

