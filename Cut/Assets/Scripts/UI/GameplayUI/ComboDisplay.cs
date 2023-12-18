﻿using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System;

namespace Cut
{
    public class ComboDisplay : MonoBehaviour, IComboDisplay
    {
        [SerializeField] private TMP_Text text;

        public event EventHandler ComboSeen;

        public void DisplayCombo(List<int> combo) 
        {
            string result = "";
            foreach (int item in combo) { result += item; }
            text.text = result;
            OnComboSeen();
        }

        private void OnComboSeen()
        {
            ComboSeen?.Invoke(this, EventArgs.Empty);
        }
    }
}