using Zenject;
using GameModeFeature;

namespace TimerFeature
{
    public class CustomPrepTimerFactory : IFactory<IPrepTimer>
    {
        private UnlimitedPrepTimer.Factory _unlimitedTimerFactory;
        private FirstTapPrepTimer.Factory _firstTapTimerFactory;
        private InstantPrepTimer.Factory _instantPrepTimerFactory;
        private GameModeHolder _gameModeHolder;

        [Inject]
        public CustomPrepTimerFactory(GameModeHolder gameModeHolder, UnlimitedPrepTimer.Factory unlimitedTimerFactory, FirstTapPrepTimer.Factory firstTapTimerFactory, InstantPrepTimer.Factory instantTimerFactory)
        {
            _unlimitedTimerFactory = unlimitedTimerFactory;
            _firstTapTimerFactory = firstTapTimerFactory;
            _instantPrepTimerFactory = instantTimerFactory;
            _gameModeHolder = gameModeHolder;
        }

        public IPrepTimer Create()
        {
            switch( _gameModeHolder.CurrentGameMode.StartTimerCondition ) 
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

