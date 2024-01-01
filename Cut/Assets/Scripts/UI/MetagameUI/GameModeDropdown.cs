using UnityEngine;
using TMPro;
using Zenject;
using System.Collections.Generic;
using GameModeFeature;
using System;

namespace UI.MetagameUI
{
    public class GameModeDropdown : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        private IMetagameMediatorToLogic _metagameMediatorToLogic;
        private IStartGameButton _startGameButton;
        private int _previousValue;

        private Dictionary<int, GameMode> _gameModes =
            new Dictionary<int, GameMode>
            {
                {0, GameMode.FirstTap },
                {1, GameMode.Instant },
                {2, GameMode.MathInstant },
            };

        [Inject]
        public void Construct(IMetagameMediatorToLogic metagameMediatorToLogic, IStartGameButton startGameButton)
        {
            _metagameMediatorToLogic = metagameMediatorToLogic;
            _startGameButton = startGameButton;
        }

        private void OnEnable() 
        {
            _dropdown.onValueChanged.AddListener( delegate { SetGameMode(_dropdown); } );
            _startGameButton.StartButtonPressed += SetGameMode;
        }

        private void SetGameMode(TMP_Dropdown change)
        {
            if (change.value != _previousValue) //OnValueChanged event invokes twice, this will prevent subscribers to be called twice too 
            {
                _metagameMediatorToLogic.SetNewGameMode(_gameModes[change.value]);
            }
            
            _previousValue = change.value;
        }

        private void SetGameMode(object sender, EventArgs e)
        {
            _metagameMediatorToLogic.SetNewGameMode(_gameModes[_dropdown.value]);
        }

        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(delegate { SetGameMode(_dropdown); });
            _startGameButton.StartButtonPressed -= SetGameMode;
        }
    }
}

