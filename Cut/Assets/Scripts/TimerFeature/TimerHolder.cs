using System;
using UnityEngine;
using Zenject;
using GameModeFeature;
using UI.GameplayUI;
using ComboSwitchingFeature;
using Core;

namespace TimerFeature
{
    public class TimerHolder : ITimerHolder
    {
        private IPrepTimer _currentPrepTimer;

        private IComboBreaker _comboBreaker;
        private IComboFinisher _comboFinisher;
        private GameModeHolder _gameModeHolder;
        private IComboHolder _comboHolder;
        private IComboDisplay _comboDisplay;
        private IFactory<IPrepTimer> _timerFactory;
        private IGameReseter _gameReseter;

        [Inject]
        public TimerHolder(GameModeHolder gameModeHolder, IComboFinisher comboFinisher, IComboBreaker comboBreaker, IComboHolder comboHolder, IComboDisplay comboDisplay, IFactory<IPrepTimer> timerFactory, IGameReseter gameReseter)
        {
            _gameModeHolder = gameModeHolder;
            _comboFinisher = comboFinisher;
            _comboBreaker = comboBreaker;
            _comboHolder = comboHolder;
            _comboDisplay = comboDisplay;
            _timerFactory = timerFactory;
            _gameReseter = gameReseter;

            _comboFinisher.ComboFinished += DeleteCurrentTimer;
            _comboBreaker.ComboBroken += DeleteCurrentTimer;
            _gameReseter.GameReset += DeleteCurrentTimer;
            _gameReseter.GameReset += UnsubscribeEventRecevier;
            Application.quitting += Dispose;
        }

        public void SubscribeToStartCondition()
        {
            switch (_gameModeHolder.CurrentGameMode.StartTimerCondition)
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

        private void UnsubscribeFromStartCondition()
        {
            switch (_gameModeHolder.CurrentGameMode.StartTimerCondition)
            {
                case StartTimerCondition.ComboStarted:
                    _comboHolder.ComboStarted -= CreateTimer;
                    break;

                case StartTimerCondition.ComboSeen:
                    _comboDisplay.ComboSeen -= CreateTimer;
                    break;
            }
        }

        private void UnsubscribeEventRecevier(object sender, EventArgs e)
        {
            UnsubscribeFromStartCondition();
        }

        private void Dispose()
        {
            UnsubscribeFromStartCondition();
            _comboFinisher.ComboFinished -= DeleteCurrentTimer;
            _comboBreaker.ComboBroken -= DeleteCurrentTimer;
            _gameReseter.GameReset -= DeleteCurrentTimer;
            _gameReseter.GameReset -= UnsubscribeEventRecevier;
            Application.quitting -= Dispose;
        }
    }
}

