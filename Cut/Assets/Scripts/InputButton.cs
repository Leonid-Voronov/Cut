using System;
using UnityEngine;

namespace Cut
{
    public class InputButton : MonoBehaviour
    {
        public class InputButtonPressedEventArgs : EventArgs
        {
            public InputButtonPressedEventArgs(int buttonNumber) { _pressedButton = buttonNumber; }
            private int _pressedButton;
        }

        [SerializeField] private int _buttonNumber;

        public event EventHandler<InputButtonPressedEventArgs> ButtonPressed;

        protected virtual void OnButtonPressed(InputButtonPressedEventArgs e)
        {
            EventHandler<InputButtonPressedEventArgs> eventHandler = ButtonPressed;
            if (eventHandler != null) 
            {
                eventHandler(this, e);
            }
        }

        public void PressButton()
        {
            InputButtonPressedEventArgs args = new InputButtonPressedEventArgs(_buttonNumber);
            OnButtonPressed(args);
        }
    }
}

