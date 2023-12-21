using TMPro;
using UnityEngine;

namespace UI.GameplayUI
{
    public class BrokenCombosDisplay : MonoBehaviour, IBrokenCombosDisplay
    {
        [SerializeField] private TMP_Text text;

        public void DisplayBrokenCombos(int statisticsNumber)
        {
            text.text = statisticsNumber.ToString();
        }
    }
}