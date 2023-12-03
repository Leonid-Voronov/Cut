
using System;

namespace Cut
{
    public interface IComboHolder 
    {
        void AddButtonToCombo(object sender, InputButtonPressedEventArgs e);
        void ResetCombo();
        void PerformCombo();

        event EventHandler ComboStarted;
    }
}