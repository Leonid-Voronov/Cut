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
        private IComboFinisher _comboFinisher;
        private IComboBreaker _comboBreaker;
        private IPrepTimer _prepTimer;

        private const int maxComboSize = 10; //for testing purposes only

        [Inject]
        public ComboHolder(ButtonsHolderSO buttonsHolder, IListDisplayer listDisplayer, IComboInspector comboInspector, IComboFinisher comboFinisher, IComboBreaker comboBreaker, IPrepTimer prepTimer)
        {
            _buttonsHolder = buttonsHolder;
            _listDisplayer = listDisplayer;
            _comboInspector = comboInspector;
            _comboFinisher = comboFinisher;
            _comboBreaker = comboBreaker;
            _prepTimer = prepTimer;

            InputButton.ButtonPressed += AddButtonToCombo;
            Application.quitting += Dispose;
        }

        public void AddButtonToCombo(object sender, InputButtonPressedEventArgs e)
        {
            if (_buttonsHolder.Buttons.Contains(e.PressedButton) && _prepTimer.IsTimerUnfinished())
            {
                _currentCombo.Add(e.PressedButton);
                _listDisplayer.ShowList(_currentCombo);

                if (_comboInspector.IsExpectedComboAvailable()) 
                {
                    if (_comboInspector.IsComboWrong(_currentCombo))
                    {
                        _comboBreaker.BreakCombo();
                        ResetCombo();
                    }
                    else if (_comboInspector.IsComboFinished(_currentCombo))
                    {
                        _comboFinisher.FinishCombo();
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

