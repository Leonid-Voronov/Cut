using System;
using Zenject;

namespace Cut
{
    public class ComboBreakerPrototype : IComboBreaker
    {
        private SessionStatistics _sessionStatistics;
        private GameConfigSO _gameConfigSO;
        private IComboSwitcher _comboSwitcher;

        public event EventHandler ComboBroken;

        [Inject]
        public ComboBreakerPrototype(SessionStatistics sessionStatistics, GameConfigSO gameConfigSO, IComboSwitcher comboSwitcher)
        {
            _sessionStatistics = sessionStatistics;
            _gameConfigSO = gameConfigSO;
            _comboSwitcher = comboSwitcher;
        }

        public void BreakCombo()
        {
            _sessionStatistics.IncrementBrokenCombosNumber();
            OnComboBroken();

            if (_gameConfigSO.FailSwitch)
                _comboSwitcher.SwitchCombo();
        }

        private void OnComboBroken()
        {
            ComboBroken?.Invoke(this, EventArgs.Empty);
        }
    }
}