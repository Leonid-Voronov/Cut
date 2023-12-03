using System;
using UnityEngine;
using Zenject;

namespace Cut
{
    public class CustomPrepTimerFactory : IFactory<IPrepTimer>
    {
        private UnlimitedPrepTimer.Factory _unlimitedTimerFactory;
        private FirstTapPrepTimer.Factory _firstTapTimerFactory;
        private InstantPrepTimer.Factory _instantPrepTimerFactory;

        private IComboHolder _comboHolder;
        private IComboDisplay _comboDisplay;
        private GameConfigSO _gameConfigSO;
        private IComboFinisher _comboFinisher;
        private IComboBreaker _comboBreaker;

        private IPrepTimer _currentPrepTimer;

        public CustomPrepTimerFactory(GameConfigSO gameConfigSO, UnlimitedPrepTimer.Factory unlimitedTimerFactory, FirstTapPrepTimer.Factory firstTapTimerFactory, InstantPrepTimer.Factory instantTimerFactory, IComboHolder comboHolder, IComboDisplay comboDisplay, IComboFinisher comboFinisher, IComboBreaker comboBreaker)
        {
            _unlimitedTimerFactory = unlimitedTimerFactory;
            _firstTapTimerFactory = firstTapTimerFactory;
            _instantPrepTimerFactory = instantTimerFactory;
            _gameConfigSO = gameConfigSO;
            _comboHolder = comboHolder;
            _comboDisplay = comboDisplay;
            _comboFinisher = comboFinisher;
            _comboBreaker = comboBreaker;

            Application.quitting += Dispose;
            _comboFinisher.ComboFinished += DisposeCurrentTimer;
            _comboBreaker.ComboBroken += DisposeCurrentTimer;


            switch (_gameConfigSO.StartTimerCondition)
            {
                case StartTimerCondition.ComboStarted:
                    _comboHolder.ComboStarted += CreateWithEvent;
                    break;

                case StartTimerCondition.ComboSeen:
                    _comboDisplay.ComboSeen += CreateWithEvent;
                    break;
            }
                
        }

        private void CreateWithEvent(object sender, EventArgs e) 
        {
            Create();
        }

        public IPrepTimer Create()
        {
            switch( _gameConfigSO.StartTimerCondition ) 
            {
                case StartTimerCondition.Never:
                    _currentPrepTimer = _unlimitedTimerFactory.Create();
                    return _currentPrepTimer;

                case StartTimerCondition.ComboStarted:
                    _currentPrepTimer = _firstTapTimerFactory.Create();
                    return _currentPrepTimer;

                case StartTimerCondition.ComboSeen:
                    _currentPrepTimer = _instantPrepTimerFactory.Create();
                    return _currentPrepTimer;
                default:
                    _currentPrepTimer = _unlimitedTimerFactory.Create();
                    return _currentPrepTimer;
            }
        }

        private void DisposeCurrentTimer(object sender, EventArgs e)
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
                    _comboHolder.ComboStarted -= CreateWithEvent;
                    break;

                case StartTimerCondition.ComboSeen:
                    _comboDisplay.ComboSeen -= CreateWithEvent;
                    break;
            }

            _comboFinisher.ComboFinished -= DisposeCurrentTimer;
            _comboBreaker.ComboBroken -= DisposeCurrentTimer;
            Application.quitting -= Dispose;
        }
    }
}

