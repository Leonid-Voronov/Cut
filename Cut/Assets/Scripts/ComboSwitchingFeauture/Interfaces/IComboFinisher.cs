using System;

namespace Cut
{
    public interface IComboFinisher
    {
        void FinishCombo();
        event EventHandler ComboFinished;
    }
}