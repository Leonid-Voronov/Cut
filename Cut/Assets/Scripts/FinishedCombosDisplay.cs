using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Cut
{
    public class FinishedCombosDisplay : MonoBehaviour, IFinishedCombosDisplay
    {
        [SerializeField] private TMP_Text text;

        private void OnEnable()
        {
            SessionStatistics.ComboFinished += DisplayFinishedCombos;
        }

        public void DisplayFinishedCombos(object sender, StatisticsViewEventArgs e)
        {
            text.text = e.StatisticsNumber.ToString();
        }

        private void OnDisable()
        {
            SessionStatistics.ComboFinished -= DisplayFinishedCombos;
        }
    }
}