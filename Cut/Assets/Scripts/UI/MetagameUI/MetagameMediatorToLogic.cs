using Assets.Scripts.GameModeFeature;
using UnityEngine;
using Zenject;

namespace Assets.Scripts.UI.MetagameUI
{
    public class MetagameMediatorToLogic : MonoBehaviour
    {
        private GameModeHolder _gameModeHolder;
        [Inject]
        public void Construct(GameModeHolder gameModeHolder)
        {
            _gameModeHolder = gameModeHolder;
        }

        public void SetNewGameMode(GameMode gameMode) => _gameModeHolder.SetCurrentGameMode(gameMode);
    }
}