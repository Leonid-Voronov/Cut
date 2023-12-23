using System;
using System.Collections.Generic;

namespace UI.GameplayUI
{
    public interface IComboDisplay
    {
        public void DisplayCombo(List<string> combo, int lastFinishedNumber);

        event EventHandler ComboSeen;
    }
}