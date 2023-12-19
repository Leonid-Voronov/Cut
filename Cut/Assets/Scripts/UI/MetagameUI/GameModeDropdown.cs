using UnityEngine;
using TMPro;
using Zenject;
using System.Collections.Generic;
using Assets.Scripts.GameModeFeature;
using Cut;

namespace UI.MetagameUI
{
    public class GameModeDropdown : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        private IMetagameMediatorToLogic _metagameMediatorToLogic;
        private GameConfigSO _gameConfigSO;
        private int _previousValue;

        private Dictionary<int, GameMode> _gameModes =
            new Dictionary<int, GameMode>
            {
                {0, GameMode.FirstTap },
                {1, GameMode.Instant }
            };

        [Inject]
        public void Construct(IMetagameMediatorToLogic metagameMediatorToLogic, GameConfigSO gameConfigSO)
        {
            _metagameMediatorToLogic = metagameMediatorToLogic;
            _gameConfigSO = gameConfigSO;
        }

        private void OnEnable() 
        {
            _dropdown.onValueChanged.AddListener( delegate { SetGamemode(_dropdown); } );

            if (_gameConfigSO.StartMode == StartMode.GameSettingsWindow)
                _metagameMediatorToLogic.SetNewGameMode(_gameModes[_dropdown.value]);
        }

        private void SetGamemode(TMP_Dropdown change)
        {
            if (change.value != _previousValue) //OnValueChanged event invokes twice, this will prevent subscribers to be called twice too 
            {
                _metagameMediatorToLogic.SetNewGameMode(_gameModes[change.value]);
            }
            
            _previousValue = change.value;
        }

        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(delegate { SetGamemode(_dropdown); });
        }
    }
}

