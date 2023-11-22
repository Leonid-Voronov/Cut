using System;

namespace Cut
{
    public class InputButtonPressedEventArgs : EventArgs
    {
        public InputButtonPressedEventArgs(int buttonNumber) { _pressedButton = buttonNumber; }
        private int _pressedButton;
        public int PressedButton => _pressedButton;
    }
}
