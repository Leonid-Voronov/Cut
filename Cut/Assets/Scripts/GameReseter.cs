using System;
using Assets.Scripts.StatisticsFeature;
using Cut;
using Zenject;

namespace Assets.Scripts
{
    public class GameReseter : IGameReseter
    {
        private SessionStatistics _sessionStatistics;
        private GameMediator _gameMediator;
        private IComboHolder _comboHolder;
        public event EventHandler GameReset;
        [Inject]
        public GameReseter(SessionStatistics sessionStatistics, GameMediator gameMediator, IComboHolder comboHolder) 
        {
            _sessionStatistics = sessionStatistics;
            _gameMediator = gameMediator;
            _comboHolder = comboHolder;
        }

        public void ResetGame()
        {
            _sessionStatistics.ResetSessionStatistics();
            _gameMediator.SwitchToMetagameUI();
            _comboHolder.ResetCombo();
            OnGameReset();
        }

        private void OnGameReset()
        {
            GameReset?.Invoke(this, EventArgs.Empty);
        }

    }
}

