using System;
using System.Collections.Generic;
using System.Threading;
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

        private const int maxComboSize = 10; //for testing purposes only
        public event EventHandler ComboStarted;

        [Inject]
        public ComboHolder(ButtonsHolderSO buttonsHolder, IListDisplayer listDisplayer, IComboInspector comboInspector, IComboFinisher comboFinisher, IComboBreaker comboBreaker)
        {
            _buttonsHolder = buttonsHolder;
            _listDisplayer = listDisplayer;
            _comboInspector = comboInspector;
            _comboFinisher = comboFinisher;
            _comboBreaker = comboBreaker;

            InputButton.ButtonPressed += AddButtonToCombo;
            Application.quitting += Dispose;
        }

        public void AddButtonToCombo(object sender, InputButtonPressedEventArgs e)
        {
            if (_buttonsHolder.Buttons.Contains(e.PressedButton))
            {
                if (_currentCombo.Count == 0)
                    OnComboStarted();

                _currentCombo.Add(e.PressedButton);
                _listDisplayer.ShowList(_currentCombo);

                InspectCombo();

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

        public void PerformCombo()
        {
            if (_comboInspector.IsComboFinished(_currentCombo) && !_comboInspector.IsComboWrong(_currentCombo))
                _comboFinisher.FinishCombo();
            else
                _comboBreaker.BreakCombo();

            ResetCombo();
        }

        private void InspectCombo()
        {
            if (_comboInspector.IsExpectedComboAvailable() )
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
        }

        private void OnComboStarted()
        {
            ComboStarted?.Invoke(this, EventArgs.Empty);
        }

        public void Dispose()
        {
            InputButton.ButtonPressed -= AddButtonToCombo;
            Application.quitting -= Dispose;
        }
    }
}

