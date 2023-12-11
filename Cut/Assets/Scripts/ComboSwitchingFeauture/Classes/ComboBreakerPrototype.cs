using System;
using Zenject;
using Assets.Scripts.GameModeFeature;

namespace Cut
{
    public class ComboBreakerPrototype : IComboBreaker
    {
        private SessionStatistics _sessionStatistics;
        private GameModeHolder _gameModeHolder;
        private IComboSwitcher _comboSwitcher;

        public event EventHandler ComboBroken;

        [Inject]
        public ComboBreakerPrototype(SessionStatistics sessionStatistics, GameModeHolder gameModeHolder, IComboSwitcher comboSwitcher)
        {
            _sessionStatistics = sessionStatistics;
            _gameModeHolder = gameModeHolder;
            _comboSwitcher = comboSwitcher;
        }

        public void BreakCombo()
        {
            _sessionStatistics.IncrementBrokenCombosNumber();
            OnComboBroken();

            if (_gameModeHolder.CurrentGameMode.FailSwitch)
                _comboSwitcher.SwitchCombo();
        }

        private void OnComboBroken()
        {
            ComboBroken?.Invoke(this, EventArgs.Empty);
        }
    }
}