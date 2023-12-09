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
        private GameConfigSO _gameConfigSO;


        [Inject]
        public CustomPrepTimerFactory(GameConfigSO gameConfigSO, UnlimitedPrepTimer.Factory unlimitedTimerFactory, FirstTapPrepTimer.Factory firstTapTimerFactory, InstantPrepTimer.Factory instantTimerFactory)
        {
            _unlimitedTimerFactory = unlimitedTimerFactory;
            _firstTapTimerFactory = firstTapTimerFactory;
            _instantPrepTimerFactory = instantTimerFactory;
            _gameConfigSO = gameConfigSO;
        }

        public IPrepTimer Create()
        {
            switch( _gameConfigSO.StartTimerCondition ) 
            {
                case StartTimerCondition.Never:
                    return _unlimitedTimerFactory.Create();

                case StartTimerCondition.ComboStarted:
                    return _firstTapTimerFactory.Create();

                case StartTimerCondition.ComboSeen:
                    return _instantPrepTimerFactory.Create();
                default:
                    return _unlimitedTimerFactory.Create();
            }
        }
    }
}

