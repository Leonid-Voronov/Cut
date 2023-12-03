using System.Collections;
using UnityEngine;
using Zenject;

namespace Cut
{
    public class InstantPrepTimer : IPrepTimer
    {
        private ITimerUpdater _timerUpdater;
        private IPrepTimerDisplay _timerDisplay;
        private IComboHolder _comboHolder;

        private float _prepTime;
        private float _remainingTime;

        [Inject]
        public InstantPrepTimer(ITimerUpdater timerUpdater, GameConfigSO gameConfigSO, IPrepTimerDisplay prepTimerDisplay, IComboHolder comboHolder)
        {
            _timerUpdater = timerUpdater;
            _prepTime = gameConfigSO.PrepTime;
            _remainingTime = _prepTime;
            _timerDisplay = prepTimerDisplay;
            _timerDisplay.DisplayTimer(_remainingTime, _prepTime);
            _comboHolder = comboHolder;
            _timerUpdater.Subscribe(this);

            Application.quitting += Dispose;
            
        }

        public void UpdateTimer()
        {
            _remainingTime -= Time.deltaTime;
            _timerDisplay.DisplayTimer(_remainingTime, _prepTime);

            if (_remainingTime <= 0)
            {
                _comboHolder.PerformCombo();
            }
        }

        public void Dispose()
        {
            _timerUpdater.Unsubscribe(this);
            _timerDisplay.DisplayFull();
            Application.quitting -= Dispose;
        }

        public class Factory : PlaceholderFactory<InstantPrepTimer>
        {

        }
    }
}