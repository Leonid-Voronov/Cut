namespace Cut
{
    public class UnlimitedPrepTimer : IPrepTimer
    {
        public bool IsTimerUnfinished()
        {
            return true;
        }
    }
}