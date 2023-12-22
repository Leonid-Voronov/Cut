using System.Linq;
using Zenject;

namespace ComboGenerationFeature
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

