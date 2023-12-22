using UnityEngine;
using TMPro;

namespace UI.GameplayUI
{
    public class FinishedCombosDisplay : MonoBehaviour, IFinishedCombosDisplay
    {
        [SerializeField] private TMP_Text text;

        public void DisplayFinishedCombos(int statisticsNumber)
        {
            text.text = statisticsNumber.ToString();
        }
    }
}