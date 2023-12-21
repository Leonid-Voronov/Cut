using GameModeFeature;
using ComboGenerationFeature;

namespace UI.MetagameUI
{
    public interface IMetagameMediatorToLogic
    {
        void SetNewGameMode(GameMode gameMode);
        void StartGame();
        void SetNewCombosTemplates(CombosTemplatesName combosTemplatesName);

    }
}