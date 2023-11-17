using System;
using UnityEngine;
using UnityEngine.UI;

namespace Cut
{
    public class InputButton : MonoBehaviour
    {
        [SerializeField] private Button _button;
        [SerializeField] private int _buttonNumber;

        public static event EventHandler<InputButtonPressedEventArgs> ButtonPressed;

        private void OnEnable()
        {
            _button.onClick.AddListener(PressButton);
        }

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

        private void OnDisable()
        {
            _button.onClick.RemoveListener(PressButton);
        }
    }
}

