﻿using System;

namespace Cut
{
    public class TimerEventArgs : EventArgs
    {
        public TimerEventArgs(ComboHolder comboHolder) { _comboHolder = comboHolder; }
        private ComboHolder _comboHolder;
        public ComboHolder ComboHolder => _comboHolder;
    }
}