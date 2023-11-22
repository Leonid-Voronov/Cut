using Zenject;

namespace Cut
{
    public class ComboBreakerPrototype : IComboBreaker
    {
        private SessionStatistics _sessionStatistics;

        [Inject]
        public ComboBreakerPrototype(SessionStatistics sessionStatistics)
        {
            _sessionStatistics = sessionStatistics;
        }

        public void BreakCombo()
        {
            _sessionStatistics.IncrementBrokenCombosNumber();
        }
    }
}