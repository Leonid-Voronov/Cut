namespace UI.GameplayUI
{
    public interface IPrepTimerDisplay
    {
        void DisplayTimer(float remainingTime, float fullTime);
        void DisplayFull();
    }
}