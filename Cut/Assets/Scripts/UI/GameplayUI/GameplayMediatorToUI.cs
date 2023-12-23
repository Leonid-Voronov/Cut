using UnityEngine;
using Zenject;
using System.Collections.Generic;

namespace UI.GameplayUI
{
    public class GameplayMediatorToUI : MonoBehaviour, IGameplayMediatorToUI
    {
        [Inject]
        public void Construct(IComboDisplay comboDisplay, IBrokenCombosDisplay brokenCombosDisplay, IFinishedCombosDisplay finishedCombosDisplay, IPrepTimerDisplay prepTimerDisplay)
        {
            _comboDisplay = comboDisplay;
            _brokenCombosDisplay = brokenCombosDisplay;
            _finishedCombosDisplay = finishedCombosDisplay;
            _prepTimerDisplay = prepTimerDisplay;
        }

        private IComboDisplay _comboDisplay;
        private IBrokenCombosDisplay _brokenCombosDisplay;
        private IFinishedCombosDisplay _finishedCombosDisplay;
        private IPrepTimerDisplay _prepTimerDisplay;
        public void UpdateComboDisplay(List<string> updatedCombo)     => _comboDisplay.DisplayCombo(updatedCombo);
        public void UpdateBrokenCombosNumber(int statisticsNumber)    => _brokenCombosDisplay.DisplayBrokenCombos(statisticsNumber);
        public void UpdateFinishedCombosNumber(int statisticsNumber)  => _finishedCombosDisplay.DisplayFinishedCombos(statisticsNumber);
        public void DisplayTimer(float remainingTime, float fullTime) => _prepTimerDisplay.DisplayTimer(remainingTime, fullTime);
        public void DisplayFullTimer()                                => _prepTimerDisplay.DisplayFull();
    }
}

