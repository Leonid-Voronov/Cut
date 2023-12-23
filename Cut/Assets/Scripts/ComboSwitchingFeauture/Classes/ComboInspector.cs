using UnityEngine;
using System.Collections.Generic;
using System;
using UI.GameplayUI;

namespace ComboSwitchingFeature
{
    public class ComboInspector : IComboInspector
    {
        private IGameplayMediatorToUI _gameplayMediatorToUI;
        private IComboConverter _comboConverter;
        private List<int> _expectedCombo = new List<int>();

        public ComboInspector(IGameplayMediatorToUI gameplayMediatorToUI, IComboConverter comboConverter)
        {
            _gameplayMediatorToUI = gameplayMediatorToUI;
            _comboConverter = comboConverter;
        }

        public bool IsComboWrong(List<int> currentCombo)
        {
            if (_expectedCombo.Count == 0)
            {
                Debug.LogWarning("ExpectedCombo is empty");
                return true;
            }

            if (currentCombo.Count > _expectedCombo.Count)
            {
                return true;
            }

            for (int i = 0; i < currentCombo.Count; i++)
            {
                if (_expectedCombo[i] != currentCombo[i])
                {
                    return true;
                }
            }

            List<string> stringCombo = _comboConverter.ConvertCombo(_expectedCombo);
            _gameplayMediatorToUI.UpdateComboDisplay(stringCombo, currentCombo.Count);
            return false;
        }

        public bool IsComboFinished(List<int> currentCombo)
        {
            return _expectedCombo.Count == currentCombo.Count;
        }

        public bool IsExpectedComboAvailable() { return _expectedCombo.Count > 0; }

        public void SetExpectedCombo(List<int> newCombo)
        {
            List<string> stringCombo = _comboConverter.ConvertCombo(newCombo);
            _gameplayMediatorToUI.UpdateComboDisplay(stringCombo, 0);
            _expectedCombo = newCombo;
        }
    }
}

