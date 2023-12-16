using Assets.Scripts.GameModeFeature;
using Cut;
using UnityEngine;
using Zenject;

namespace  UI.MetagameUI
{
    public class MetagameMediatorToLogic : MonoBehaviour, IMetagameMediatorToLogic
    {
        private GameModeHolder _gameModeHolder;
        private GameStarter _gameStarter;
        [Inject]
        public void Construct(GameModeHolder gameModeHolder, GameStarter gameStarter)
        {
            _gameModeHolder = gameModeHolder;
            _gameStarter = gameStarter;
        }

        public void SetNewGameMode(GameMode gameMode) => _gameModeHolder.SetCurrentGameMode(gameMode);
        public void StartGame() => _gameStarter.StartGameWithButton();
    }
}