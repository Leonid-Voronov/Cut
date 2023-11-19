﻿using System.Collections.Generic;
using UnityEngine;

namespace Cut
{
    public class ListConsoleDisplayer : IListDisplayer
    {
        public void ShowList(List<int> list)
        {
            string f = "";
            foreach (int item in  list) { f += item; }
            Debug.Log(f);
        }
    }
}