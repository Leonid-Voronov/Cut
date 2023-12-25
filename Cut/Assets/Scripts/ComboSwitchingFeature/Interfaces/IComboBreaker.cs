using System;

namespace ComboSwitchingFeature
{
    public interface IComboBreaker
    {
        void BreakCombo();
        event EventHandler ComboBroken;
    }
}