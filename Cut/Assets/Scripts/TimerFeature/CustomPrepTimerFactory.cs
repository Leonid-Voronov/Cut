using Zenject;

namespace Cut
{
    public class CustomPrepTimerFactory : IFactory<IPrepTimer>
    {
        private UnlimitedPrepTimer.Factory _unlimitedTimerFactory;
        private FirstTapPrepTimer.Factory _firstTapTimerFactory;
        private GameConfigSO _gameConfigSO;

        public CustomPrepTimerFactory(GameConfigSO gameConfigSO, UnlimitedPrepTimer.Factory unlimitedTimerFactory, FirstTapPrepTimer.Factory firstTapTimerFactory)
        {
            _unlimitedTimerFactory = unlimitedTimerFactory;
            _firstTapTimerFactory = firstTapTimerFactory;
            _gameConfigSO = gameConfigSO;
        }

        public IPrepTimer Create()
        {
            if (_gameConfigSO.UnlimitedTime)
            {
                return _unlimitedTimerFactory.Create();
            }
            else
            {
                return _firstTapTimerFactory.Create();
            }
        }
    }
}

