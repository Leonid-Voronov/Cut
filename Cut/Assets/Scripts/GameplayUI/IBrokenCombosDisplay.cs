using System.Collections;
using UnityEngine;

namespace Cut
{
    public interface IBrokenCombosDisplay
    {
        public void DisplayBrokenCombos(object sender, StatisticsViewEventArgs e);
    }
}