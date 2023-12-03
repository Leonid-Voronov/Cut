using System;
using UnityEngine;
using Zenject;

namespace Cut
{
    public class TimerHolder : ITimerHolder
    {
        private IPrepTimer _currentPrepTimer;

        private IComboBreaker _comboBreaker;
        private IComboFinisher _comboFinisher;
        private GameConfigSO _gameConfigSO;
        private IComboHolder _comboHolder;
        private IComboDisplay _comboDisplay;
        private IFactory<IPrepTimer> _timerFactory;

        [Inject]
        public TimerHolder(GameConfigSO gameConfigSO, IComboFinisher comboFinisher, IComboBreaker comboBreaker, IComboHolder comboHolder, IComboDisplay comboDisplay, IFactory<IPrepTimer> timerFactory)
        {
            _gameConfigSO = gameConfigSO;
            _comboFinisher = comboFinisher;
            _comboBreaker = comboBreaker;
            _comboHolder = comboHolder;
            _comboDisplay = comboDisplay;
            _timerFactory = timerFactory;

            _comboFinisher.ComboFinished += DeleteCurrentTimer;
            _comboBreaker.ComboBroken += DeleteCurrentTimer;
            Application.quitting += Dispose;

            switch (_gameConfigSO.StartTimerCondition)
            {
                case StartTimerCondition.ComboStarted:
                    _comboHolder.ComboStarted += CreateTimer;
                    break;

                case StartTimerCondition.ComboSeen:
                    _comboDisplay.ComboSeen += CreateTimer;
                    break;
            }
        }

        private void CreateTimer(object sender, EventArgs e)
        {
            _currentPrepTimer = _timerFactory.Create();
        }

        private void DeleteCurrentTimer(object sender, EventArgs e)
        {
            if (_currentPrepTimer != null)
            {
                _currentPrepTimer.Dispose();
                _currentPrepTimer = null;
            }
        }

        private void Dispose()
        {
            switch (_gameConfigSO.StartTimerCondition)
            {
                case StartTimerCondition.ComboStarted:
                    _comboHolder.ComboStarted -= CreateTimer;
                    break;

                case StartTimerCondition.ComboSeen:
                    _comboDisplay.ComboSeen -= CreateTimer;
                    break;
            }

            _comboFinisher.ComboFinished -= DeleteCurrentTimer;
            _comboBreaker.ComboBroken -= DeleteCurrentTimer;
            Application.quitting -= Dispose;
        }
    }
}