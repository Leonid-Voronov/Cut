using UnityEngine;
using System.Collections.Generic;

namespace Cut
{
    public class ComboInspector : IComboInspector
    {
        private List<int> _expectedCombo = new List<int>();

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

            return false;
        }

        public bool IsComboFinished(List<int> currentCombo)
        {
            return _expectedCombo.Count == currentCombo.Count;
        }

        public bool IsExpectedComboAvailable() { return _expectedCombo.Count > 0; }
    }
}

