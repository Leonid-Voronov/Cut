using System;
using UnityEngine;
using Zenject;
using static UnityEngine.EventSystems.PointerEventData;

namespace Cut
{
    public class InputIntepretation : IDisposable
    {
        private ButtonsHolderSO _buttonsHolder;

        [Inject]
        public InputIntepretation(ButtonsHolderSO buttonsHolder)
        {
            _buttonsHolder = buttonsHolder;

            InputButton.ButtonPressed += AddButtonToCombo;
            Application.quitting += Dispose;
        }

        private void AddButtonToCombo(object sender, InputButtonPressedEventArgs e)
        {
            
            if (_buttonsHolder.Buttons.Contains(e.PressedButton))
            {
                //add to combo

                Debug.Log(e.PressedButton);
            }
            else
            {
                Debug.LogWarning( e.PressedButton + " number isn't supported, change button's number to appropriate");
                return;
            }
        }

        public void Dispose()
        {
            InputButton.ButtonPressed -= AddButtonToCombo;
            Application.quitting -= Dispose;
        }
    }
}

