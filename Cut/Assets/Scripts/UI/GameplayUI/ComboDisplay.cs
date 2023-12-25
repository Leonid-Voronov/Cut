using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace UI.GameplayUI
{
    public class ComboDisplay : MonoBehaviour, IComboDisplay
    {
        [SerializeField] private TMP_Text text;

        public event EventHandler ComboSeen;

        private const string finishedColorStart = "<color=green>";
        private const string finishedColorEnd = "</color>";

        public void DisplayCombo(List<string> combo, int lastFinishedNumber)
        {
            string result = "";

            if (lastFinishedNumber > 0)
                result += finishedColorStart;
            else
                OnComboSeen();

            for (int i = 0; i < combo.Count; i++) 
            {
                if (lastFinishedNumber > 0 && i == lastFinishedNumber)
                {
                    result += finishedColorEnd;
                }

                string item = combo[i];
                result += item; 
            }
            text.text = result;
        }

        private void OnComboSeen()
        {
            ComboSeen?.Invoke(this, EventArgs.Empty);
        }
    }
}