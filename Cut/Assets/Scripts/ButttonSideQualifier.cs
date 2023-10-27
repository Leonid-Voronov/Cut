using System.Collections.Generic;
using System.Linq;

namespace Cut
{
    public class ButtonSideQualifier
    {
        private int maxButtonValue;
        public ButtonSideQualifier(List<int> _buttons) { maxButtonValue = _buttons.Last(); }

        public bool IsButtonLeft(int buttonValue) 
        {
            return buttonValue <= maxButtonValue / 2;
        }
    }
}

