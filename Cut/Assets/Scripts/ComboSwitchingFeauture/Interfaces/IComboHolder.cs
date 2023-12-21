
using System;

namespace ComboSwitchingFeature
{
    public interface IComboHolder 
    {
        void AddButtonToCombo(int _buttonNumber);
        void ResetCombo();
        void PerformCombo();

        event EventHandler ComboStarted;
    }
}