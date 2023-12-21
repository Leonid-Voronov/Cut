using UI.GameplayUI;
using Zenject;

namespace StatisticsFeature
{
    public class SessionStatistics
    {
        private IGameplayMediatorToUI _gameplayMediator;
        private int _finishedCombosNumber = 0;
        private int _brokenCombosNumber = 0;
        [Inject]
        public void Construct(IGameplayMediatorToUI gameplayMediator)
        {
            _gameplayMediator = gameplayMediator;
        }
        public void IncrementFinishedCombosNumber()
        {
            _finishedCombosNumber++;
            _gameplayMediator.UpdateFinishedCombosNumber(_finishedCombosNumber);
        }

        public void IncrementBrokenCombosNumber() 
        {
            _brokenCombosNumber++;
            _gameplayMediator.UpdateBrokenCombosNumber(_brokenCombosNumber);
        }
        public void ResetSessionStatistics()
        {
            _finishedCombosNumber = 0;
            _brokenCombosNumber = 0;
            _gameplayMediator.UpdateFinishedCombosNumber(_finishedCombosNumber);
            _gameplayMediator.UpdateBrokenCombosNumber(_brokenCombosNumber);
        }
    }
}