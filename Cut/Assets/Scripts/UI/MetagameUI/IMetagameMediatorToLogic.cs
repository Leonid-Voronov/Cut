using Assets.Scripts.GameModeFeature;
using ComboGenerationFeature;
using UnityEngine;

namespace UI.MetagameUI
{
    public interface IMetagameMediatorToLogic
    {
        void SetNewGameMode(GameMode gameMode);
        void StartGame();
        void SetNewCombosTemplates(CombosTemplatesName combosTemplatesName);

    }
}