using System;

namespace TimerFeature
{
    public interface IPrepTimer : IDisposable
    {
        void UpdateTimer();
    }
}