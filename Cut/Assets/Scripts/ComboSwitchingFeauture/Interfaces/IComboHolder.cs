
using System;

namespace Cut
{
    public interface IComboHolder 
    {
        void AddButtonToCombo(object sender, InputButtonPressedEventArgs e);
        void ResetCombo();
        void PerformCombo();

        static event EventHandler<ComboStartedEventArgs> ComboStarted;
        public static void Invoke(IComboHolder inv, ComboStartedEventArgs comboStartedEventArgs) => ComboStarted?.Invoke(inv, comboStartedEventArgs);
    }
}