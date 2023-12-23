using System;
using System.Collections.Generic;

namespace UI.GameplayUI
{
    public interface IComboDisplay
    {
        public void DisplayCombo(List<string> combo);

        event EventHandler ComboSeen;
    }
}