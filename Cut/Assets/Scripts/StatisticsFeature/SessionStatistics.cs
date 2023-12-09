using System;
using Zenject;

namespace Cut
{
    public class SessionStatistics
    {
        [Inject]
        public void Construct(IGameplayMediatorToUI gameplayMediator)
        {
            _gameplayMediator = gameplayMediator;
        }

        private IGameplayMediatorToUI _gameplayMediator;
        private int _finishedCombosNumber = 0;
        private int _brokenCombosNumber = 0;

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
    }
}