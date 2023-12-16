using UnityEngine;
using Zenject;
using UnityEngine.UI;

namespace Assets.Scripts.UI.MetagameUI
{
    public class StartGameButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        private MetagameMediatorToLogic _metagameMediatorToLogic;
        [Inject]
        public void Construct(MetagameMediatorToLogic metagameMediatorToLogic)
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

