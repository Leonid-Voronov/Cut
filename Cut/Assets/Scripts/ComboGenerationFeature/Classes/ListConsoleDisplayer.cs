using System.Collections.Generic;
using UnityEngine;

namespace ComboGenerationFeature
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