using System;

namespace ComboSwitchingFeature
{
    public interface IComboFinisher
    {
        void FinishCombo();
        event EventHandler ComboFinished;
    }
}