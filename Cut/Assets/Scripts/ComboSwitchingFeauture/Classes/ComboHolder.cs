using System;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
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
        private IPrepTimer _currentPrepTimer;
        private IFactory<IPrepTimer> _customPrepTimerFactory;

        private const int maxComboSize = 10; //for testing purposes only
        public static event EventHandler<ComboStartedEventArgs> ComboStarted;

        [Inject]
        public ComboHolder(ButtonsHolderSO buttonsHolder, IListDisplayer listDisplayer, IComboInspector comboInspector, IComboFinisher comboFinisher, IComboBreaker comboBreaker, IFactory<IPrepTimer> customPrepTimerFactory)
        {
            _buttonsHolder = buttonsHolder;
            _listDisplayer = listDisplayer;
            _comboInspector = comboInspector;
            _comboFinisher = comboFinisher;
            _comboBreaker = comboBreaker;
            _customPrepTimerFactory = customPrepTimerFactory;
            _currentPrepTimer = _customPrepTimerFactory.Create();

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
            _currentPrepTimer.Dispose();
            _currentPrepTimer = _customPrepTimerFactory.Create();
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
            ComboStarted?.Invoke(this, new ComboStartedEventArgs(this));
        }

        public void Dispose()
        {
            InputButton.ButtonPressed -= AddButtonToCombo;
            Application.quitting -= Dispose;
        }
    }
}

