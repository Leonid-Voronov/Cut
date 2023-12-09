using System;

namespace Cut
{
    public interface IComboBreaker
    {
        void BreakCombo();
        event EventHandler ComboBroken;
    }
}