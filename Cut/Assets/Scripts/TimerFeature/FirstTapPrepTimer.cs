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
    public FirstTapPrepTimer(GameConfigSO gameConfig, ITimerUpdater timerUpdater, IPrepTimerDisplay prepTimerDisplay, IComboHolder comboHolder)
    {
        _timerUpdater = timerUpdater;
        _timerDisplay = prepTimerDisplay;
        _comboHolder = comboHolder;

        _prepTime = gameConfig.PrepTime;
        _remainingTime = _prepTime;
        _timerUpdater.Subscribe(this);
        Application.quitting += Dispose;
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
        _timerDisplay.DisplayFull();
        Application.quitting -= Dispose;
    }

    public class Factory : PlaceholderFactory<FirstTapPrepTimer>
    {

    }
}
