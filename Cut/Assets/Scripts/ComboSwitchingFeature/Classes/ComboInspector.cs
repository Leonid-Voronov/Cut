using UnityEngine;
using System.Collections.Generic;
using System;
using UI.GameplayUI;

namespace ComboSwitchingFeature
{
    public class ComboInspector : IComboInspector
    {
        private IGameplayMediatorToUI _gameplayMediatorToUI;
        private ComboConverterHolder _comboConverterHolder;
        private List<int> _expectedCombo = new List<int>();
        private List<string> _stringCombo = new List<string>();

        public ComboInspector(IGameplayMediatorToUI gameplayMediatorToUI, ComboConverterHolder comboConverterHolder)
        {
            _gameplayMediatorToUI = gameplayMediatorToUI;
            _comboConverterHolder = comboConverterHolder;
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

            _gameplayMediatorToUI.UpdateComboDisplay(_stringCombo, currentCombo.Count);
            return false;
        }

        public bool IsComboFinished(List<int> currentCombo)
        {
            return _expectedCombo.Count == currentCombo.Count;
        }

        public bool IsExpectedComboAvailable() { return _expectedCombo.Count > 0; }

        public void SetExpectedCombo(List<int> newCombo)
        {
            _stringCombo = _comboConverterHolder.CurrentComboConverter.ConvertCombo(newCombo);
            _gameplayMediatorToUI.UpdateComboDisplay(_stringCombo, 0);
            _expectedCombo = newCombo;
        }
    }
}

