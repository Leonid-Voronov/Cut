using System;

namespace Cut
{
    public class ComboStartedEventArgs : EventArgs
    {
        public ComboStartedEventArgs(ComboHolder comboHolder) { _comboHolder = comboHolder; }
        private ComboHolder _comboHolder;
        public ComboHolder ComboHolder => _comboHolder;
    }
}