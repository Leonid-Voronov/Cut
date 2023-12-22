using UnityEngine;

namespace UI.GameplayUI
{
    public class PrepTimerDisplay : MonoBehaviour, IPrepTimerDisplay
    {
        [SerializeField] private RectTransform _bar;

        public void DisplayTimer(float remainingTime, float fullTime)
        {
            _bar.localScale = new Vector3 (remainingTime / fullTime, _bar.localScale.y, _bar.localScale.z);
        }

        public void DisplayFull()
        {
            _bar.localScale = new Vector3(1f, _bar.localScale.y, _bar.localScale.z);
        }
    }
}

