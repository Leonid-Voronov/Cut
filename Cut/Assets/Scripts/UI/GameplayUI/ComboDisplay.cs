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

        public void DisplayCombo(List<string> combo) 
        {
            string result = "";
            foreach (string item in combo) { result += item; }
            text.text = result;
            OnComboSeen();
        }

        private void OnComboSeen()
        {
            ComboSeen?.Invoke(this, EventArgs.Empty);
        }
    }
}