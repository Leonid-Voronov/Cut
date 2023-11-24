using System;

namespace Cut
{
    public class FirstTapPrepTimer : IPrepTimer, IDisposable
    {
        private bool _timerStarted = false;
        private float _time;
        private float _timer;

        public FirstTapPrepTimer()
        {
            InputButton.ButtonPressed += StartTimer;
        }

        public bool IsTimerUnfinished()
        {
            return true;
        }

        private void StartTimer(object sender, InputButtonPressedEventArgs e)
        {
            _timerStarted = true;
            
        }

        

        public void Dispose()
        {

        }
    }
}

