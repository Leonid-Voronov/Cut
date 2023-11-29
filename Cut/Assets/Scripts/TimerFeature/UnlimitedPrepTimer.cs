using System;
using Zenject;

namespace Cut
{
    public class UnlimitedPrepTimer : IPrepTimer
    {
        public void Dispose()
        {

        }

        public class Factory : PlaceholderFactory<UnlimitedPrepTimer>
        {

        }
    }
}