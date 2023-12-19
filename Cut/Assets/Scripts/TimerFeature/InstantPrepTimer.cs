using Assets.Scripts.GameModeFeature;
using System.Collections;
using UnityEngine;
using Zenject;

namespace Cut
{
    public class InstantPrepTimer : IPrepTimer
    {
        private ITimerUpdater _timerUpdater;
        private IComboHolder _comboHolder;
        private IGameplayMediatorToUI _gameplayMediator;

        private float _prepTime;
        private float _remainingTime;

        [Inject]
        public InstantPrepTimer(ITimerUpdater timerUpdater, GameModeHolder gameModeHolder, IComboHolder comboHolder, IGameplayMediatorToUI gameplayMediator)
        {
            _timerUpdater = timerUpdater;
            _prepTime = gameModeHolder.CurrentGameMode.PrepTime;
            _remainingTime = _prepTime;
            _gameplayMediator = gameplayMediator;
            _gameplayMediator.DisplayTimer(_remainingTime, _prepTime);
            _comboHolder = comboHolder;
            _timerUpdater.Subscribe(this);

            Application.quitting += Dispose;
            
        }

        public void UpdateTimer()
        {
            _remainingTime -= Time.deltaTime;
            _gameplayMediator.DisplayTimer(_remainingTime, _prepTime);

            if (_remainingTime <= 0)
            {
                _comboHolder.PerformCombo();
            }
        }

        public void Dispose()
        {
            _timerUpdater.Unsubscribe(this);
            _gameplayMediator.DisplayFullTimer();
            Application.quitting -= Dispose;
        }

        public class Factory : PlaceholderFactory<InstantPrepTimer>
        {

        }
    }
}