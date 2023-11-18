using System;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

namespace Cut
{
    public class ComboHolder : IDisposable, IComboHolder
    {
        private ButtonsHolderSO _buttonsHolder;
        private List<int> _currentCombo = new List<int>();
        private IListDisplayer _listDisplayer;
        private IComboInspector _comboInspector;

        private const int maxComboSize = 10; //for testing purposes only

        [Inject]
        public ComboHolder(ButtonsHolderSO buttonsHolder, IListDisplayer listDisplayer, IComboInspector comboInspector)
        {
            _buttonsHolder = buttonsHolder;
            _listDisplayer = listDisplayer;
            _comboInspector = comboInspector;

            InputButton.ButtonPressed += AddButtonToCombo;
            Application.quitting += Dispose;
        }

        public void AddButtonToCombo(object sender, InputButtonPressedEventArgs e)
        {
            if (_buttonsHolder.Buttons.Contains(e.PressedButton))
            {
                _currentCombo.Add(e.PressedButton);
                _listDisplayer.ShowList(_currentCombo);

                if (_comboInspector.IsExpectedComboAvailable()) 
                {
                    if (_comboInspector.IsComboWrong(_currentCombo))
                    {
                        //lose
                        ResetCombo();
                    }
                    else if (_comboInspector.IsComboFinished(_currentCombo))
                    {
                        //win
                        ResetCombo();
                    }
                }
                

                if (_currentCombo.Count > maxComboSize)
                    ResetCombo();
            }
            else
            {
                Debug.LogWarning( e.PressedButton + " number isn't supported, change button's number to appropriate");
                return;
            }
        }

        public void ResetCombo()
        {
            _currentCombo.Clear();
        }

        public void Dispose()
        {
            InputButton.ButtonPressed -= AddButtonToCombo;
            Application.quitting -= Dispose;
        }
    }
}

