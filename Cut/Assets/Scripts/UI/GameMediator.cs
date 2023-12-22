using TagComponents;
using UnityEngine;
using Zenject;

namespace UI
{
    public class GameMediator : MonoBehaviour
    {
        private GameplayUITag _gameplayUI;
        private MetagameUITag _metagameUI;

        [Inject]
        public void Construct(GameplayUITag gameplayUI, MetagameUITag metagameUI)
        {
            _gameplayUI = gameplayUI;
            _metagameUI = metagameUI;
        }

        public void DisableAllUI()
        {
            _gameplayUI.gameObject.SetActive(false);
            _metagameUI.gameObject.SetActive(false);
        }

        public void SwitchToGameplayUI()
        {
            DisableAllUI();
            _gameplayUI.gameObject.SetActive(true);
        }

        public void SwitchToMetagameUI()
        {
            DisableAllUI();
            _metagameUI.gameObject.SetActive(true);
        }
    }
}

