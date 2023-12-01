using Zenject;

namespace Cut
{
    public class UnlimitedPrepTimer : IPrepTimer
    {
        public void Dispose()
        {

        }

        public void UpdateTimer()
        { 
        }

        public class Factory : PlaceholderFactory<UnlimitedPrepTimer>
        {

        }
    }
}