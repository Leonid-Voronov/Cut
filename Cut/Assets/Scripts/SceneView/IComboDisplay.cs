using System;
using System.Collections.Generic;

namespace Cut
{
    public interface IComboDisplay
    {
        public void DisplayCombo(List<int> combo);

        event EventHandler ComboSeen;
    }
}