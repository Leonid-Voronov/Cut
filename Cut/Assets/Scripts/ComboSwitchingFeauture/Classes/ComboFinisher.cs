using System;
using Zenject;
using Assets.Scripts.StatisticsFeature;

namespace Cut
{
    public class ComboFinisherPrototype : IComboFinisher
    {
        private IComboSwitcher _comboSwitcher;
        private SessionStatistics _sessionStatistics;

        public event EventHandler ComboFinished;

        [Inject]
        public ComboFinisherPrototype(IComboSwitcher comboSwitcher, SessionStatistics sessionStatistics)
        {
            _comboSwitcher = comboSwitcher;
            _sessionStatistics = sessionStatistics;
        }

        public void FinishCombo()
        {
            _sessionStatistics.IncrementFinishedCombosNumber();
            OnComboFinished();
            _comboSwitcher.SwitchCombo(); //should be after OnComboFinished
        }

        private void OnComboFinished()
        {
            ComboFinished?.Invoke(this, EventArgs.Empty);
        }
    }
}