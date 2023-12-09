using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Cut
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