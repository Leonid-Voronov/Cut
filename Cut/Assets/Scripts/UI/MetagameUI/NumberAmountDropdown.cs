using ComboGenerationFeature;
using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using Zenject;

namespace UI.MetagameUI
{
    public class NumberAmountDropdown : MonoBehaviour
    {
        [SerializeField] private TMP_Dropdown _dropdown;
        private IMetagameMediatorToLogic _metagameMediatorToLogic;
        private IStartGameButton _startGameButton;
        private int _previousValue;

        private Dictionary<int, CombosTemplatesName> _combosTemplates =
            new Dictionary<int, CombosTemplatesName>
            {
                {0, CombosTemplatesName.Default },
                {1, CombosTemplatesName.ThreeSymbols },
                {2, CombosTemplatesName.FiveSymbols },
                {3, CombosTemplatesName.SevenSymbols }
            };

        [Inject]
        public void Construct(IMetagameMediatorToLogic metagameMediatorToLogic, IStartGameButton startGameButton)
        {
            _metagameMediatorToLogic = metagameMediatorToLogic;
            _startGameButton = startGameButton;
        }

        private void OnEnable()
        {
            _dropdown.onValueChanged.AddListener(delegate { SetCombosTemplates(_dropdown); });
            _startGameButton.StartButtonPressed += SetCombosTemplates;
        }

        private void SetCombosTemplates(TMP_Dropdown change)
        {
            if (change.value != _previousValue) //OnValueChanged event invokes twice, this will prevent subscribers to be called twice too 
            {
                _metagameMediatorToLogic.SetNewCombosTemplates(_combosTemplates[change.value]);
            }

            _previousValue = change.value;
        }

        private void SetCombosTemplates(object sender, EventArgs e)
        {
            _metagameMediatorToLogic.SetNewCombosTemplates(_combosTemplates[_dropdown.value]);
        }

        private void OnDisable()
        {
            _dropdown.onValueChanged.RemoveListener(delegate { SetCombosTemplates(_dropdown); });
            _startGameButton.StartButtonPressed -= SetCombosTemplates;
        }
    }
}