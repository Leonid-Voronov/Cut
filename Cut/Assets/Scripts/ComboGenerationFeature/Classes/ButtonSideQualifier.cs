using System.Collections.Generic;
using System.Linq;
using Zenject;

namespace Cut
{
    public class ButtonSideQualifier : IButtonSideQualifier
    {

        private int maxButtonValue;

        [Inject]
        public ButtonSideQualifier(ButtonsHolderSO buttonsHolderSO) 
        {
            maxButtonValue = buttonsHolderSO.Buttons.Last();
        }

        public bool IsButtonLeft(int buttonValue) 
        {
            return buttonValue <= maxButtonValue / 2;
        }
    }
}

