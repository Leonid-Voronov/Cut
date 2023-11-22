using System;

namespace Cut
{
    public class SessionStatistics
    {
        private int _finishedCombosNumber = 0;
        private int _brokenCombosNumber = 0;

        public static event EventHandler<StatisticsViewEventArgs> ComboFinished;
        public static event EventHandler<StatisticsViewEventArgs> ComboBroken;

        private void OnComboReset(StatisticsViewEventArgs e, EventHandler<StatisticsViewEventArgs> newEvent)
        {
            EventHandler<StatisticsViewEventArgs> eventHandler = newEvent;
            if (eventHandler != null)
            {
                eventHandler(this, e);
            }
        }

        public void IncrementFinishedCombosNumber()
        {
            _finishedCombosNumber++;
            OnComboReset( new StatisticsViewEventArgs(_finishedCombosNumber), ComboFinished);
        }

        public void IncrementBrokenCombosNumber() 
        {
            _brokenCombosNumber++;
            OnComboReset(new StatisticsViewEventArgs(_brokenCombosNumber), ComboBroken);
        }
    }
}