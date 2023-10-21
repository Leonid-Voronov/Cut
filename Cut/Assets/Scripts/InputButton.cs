using System;
using UnityEngine;

namespace Cut
{
    public class InputButton : MonoBehaviour
    {
        [SerializeField] private int _buttonNumber;

        public static event EventHandler<InputButtonPressedEventArgs> ButtonPressed;

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

