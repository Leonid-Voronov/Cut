using System;

namespace Cut
{
    public class StatisticsViewEventArgs : EventArgs
    {
        public StatisticsViewEventArgs(int statisticsNumber) { _statisticsNumber = statisticsNumber; }
        private int _statisticsNumber;
        public int StatisticsNumber => _statisticsNumber;
    }
}