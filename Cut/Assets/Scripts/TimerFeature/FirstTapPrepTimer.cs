using Cut;
using System;
using System.Threading;
using Zenject;
using UnityEngine;

public class FirstTapPrepTimer : IPrepTimer
{
    private IComboHolder _comboHolder;
    private ITimerUpdater _timerUpdater;
    private IPrepTimerDisplay _timerDisplay;

    private float _prepTime;
    private float _remainingTime;

    [Inject]
    public FirstTapPrepTimer(GameConfigSO gameConfig, ITimerUpdater timerUpdater, IPrepTimerDisplay prepTimerDisplay)
    {
        _prepTime = gameConfig.PrepTime;
        _remainingTime = _prepTime;
        _timerUpdater = timerUpdater;
        _timerDisplay = prepTimerDisplay;

        _timerDisplay.DisplayTimer(_remainingTime, _prepTime);

        ComboHolder.ComboStarted += StartTimer;
        Application.quitting += Dispose;
    }

    private void StartTimer(object sender, ComboStartedEventArgs e)
    {
        _comboHolder = e.ComboHolder;
        _timerUpdater.Subscribe(this);
    }

    public void UpdateTimer()
    {
        _remainingTime -= Time.deltaTime;
        _timerDisplay.DisplayTimer(_remainingTime, _prepTime);

        if (_remainingTime <= 0)
        {
            _comboHolder.PerformCombo();
        }
    }

    public void Dispose()
    {
        _timerUpdater.Unsubscribe(this);
        ComboHolder.ComboStarted -= StartTimer;
        Application.quitting -= Dispose;
    }

    public class Factory : PlaceholderFactory<FirstTapPrepTimer>
    {

    }
}
