using System;
using Assets.Scripts.StatisticsFeature;
using Cut;
using GameplayVisualsFeature;
using Zenject;

namespace Assets.Scripts
{
    public class GameReseter : IGameReseter
    {
        private SessionStatistics _sessionStatistics;
        private GameMediator _gameMediator;
        private IComboHolder _comboHolder;
        public event EventHandler GameReset;
        private IEnvironmentObjectsDestroyer _environmentObjectsDestroyer;
        [Inject]
        public GameReseter(SessionStatistics sessionStatistics, GameMediator gameMediator, IComboHolder comboHolder, IEnvironmentObjectsDestroyer environmentObjectsDestroyer) 
        {
            _sessionStatistics = sessionStatistics;
            _gameMediator = gameMediator;
            _comboHolder = comboHolder;
            _environmentObjectsDestroyer = environmentObjectsDestroyer;
        }

        public void ResetGame()
        {
            _sessionStatistics.ResetSessionStatistics();
            _gameMediator.SwitchToMetagameUI();
            _comboHolder.ResetCombo();
            _environmentObjectsDestroyer.DestroyEnvironmentObjects();
            OnGameReset();
        }

        private void OnGameReset()
        {
            GameReset?.Invoke(this, EventArgs.Empty);
        }

    }
}

