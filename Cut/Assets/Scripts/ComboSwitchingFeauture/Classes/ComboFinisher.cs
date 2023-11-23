using Zenject;

namespace Cut
{
    public class ComboFinisherPrototype : IComboFinisher
    {
        private IComboSwitcher _comboSwitcher;
        private SessionStatistics _sessionStatistics;

        [Inject]
        public ComboFinisherPrototype(IComboSwitcher comboSwitcher, SessionStatistics sessionStatistics)
        {
            _comboSwitcher = comboSwitcher;
            _sessionStatistics = sessionStatistics;
        }

        public void FinishCombo()
        {
            _comboSwitcher.SwitchCombo();
            _sessionStatistics.IncrementFinishedCombosNumber();
        }
    }
}