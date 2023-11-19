﻿using System.Collections.Generic;
using UnityEngine;
using TMPro;

namespace Cut
{
    public class ComboDisplayer : MonoBehaviour, IComboDisplayer
    {
        [SerializeField] private TMP_Text text;
        
        public void DisplayCombo(List<int> combo) 
        {
            string result = "";
            foreach (int item in combo) { result += item; }
            text.text = result;
        }
    }
}