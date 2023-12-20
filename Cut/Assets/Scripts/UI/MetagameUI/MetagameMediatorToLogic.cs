using Assets.Scripts.GameModeFeature;
using ComboGenerationFeature;
using Cut;
using UnityEngine;
using Zenject;

namespace  UI.MetagameUI
{
    public class MetagameMediatorToLogic : MonoBehaviour, IMetagameMediatorToLogic
    {
        private GameModeHolder _gameModeHolder;
        private GameStarter _gameStarter;
        private CombosTemplatesHolder _combosTemplatesHolder;

        [Inject]
        public void Construct(GameModeHolder gameModeHolder, GameStarter gameStarter, CombosTemplatesHolder combosTemplatesHolder)
        {
            _gameModeHolder = gameModeHolder;
            _gameStarter = gameStarter;
            _combosTemplatesHolder = combosTemplatesHolder;
        }

        public void SetNewCombosTemplates(CombosTemplatesName combosTemplatesName) => _combosTemplatesHolder.SetCurrentCombosTemplates(combosTemplatesName);
        public void SetNewGameMode(GameMode gameMode) => _gameModeHolder.SetCurrentGameMode(gameMode);
        public void StartGame() => _gameStarter.StartGameWithButton();
    }
}