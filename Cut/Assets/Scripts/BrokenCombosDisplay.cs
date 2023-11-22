using TMPro;
using UnityEngine;

namespace Cut
{
    public class BrokenCombosDisplay : MonoBehaviour, IBrokenCombosDisplay
    {
        [SerializeField] private TMP_Text text;

        private void OnEnable()
        {
            SessionStatistics.ComboBroken += DisplayBrokenCombos;
        }

        public void DisplayBrokenCombos(object sender, StatisticsViewEventArgs e)
        {
            text.text = e.StatisticsNumber.ToString();
        }

        private void OnDisable()
        {
            SessionStatistics.ComboBroken -= DisplayBrokenCombos;
        }
    }
}