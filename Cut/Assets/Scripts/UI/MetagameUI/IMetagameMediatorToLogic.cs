using Assets.Scripts.GameModeFeature;
using UnityEngine;

namespace UI.MetagameUI
{
    public interface IMetagameMediatorToLogic
    {
        void SetNewGameMode(GameMode gameMode);
        void StartGame();

    }
}