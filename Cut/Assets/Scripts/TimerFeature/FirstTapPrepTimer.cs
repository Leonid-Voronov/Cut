using Zenject;
using UnityEngine;
using GameModeFeature;
using ComboSwitchingFeature;
using UI.GameplayUI;
using TimerFeature;

public class FirstTapPrepTimer : IPrepTimer
{
    private IComboHolder _comboHolder;
    private ITimerUpdater _timerUpdater;
    private IGameplayMediatorToUI _gameplayMediator;

    private float _prepTime;
    private float _remainingTime;

    [Inject]
    public FirstTapPrepTimer(GameModeHolder gameModeHolder, ITimerUpdater timerUpdater, IComboHolder comboHolder, IGameplayMediatorToUI gameplayMediator)
    {
        _timerUpdater = timerUpdater;
        _comboHolder = comboHolder;
        _gameplayMediator = gameplayMediator;
        _prepTime = gameModeHolder.CurrentGameMode.PrepTime;
        _remainingTime = _prepTime;
        _timerUpdater.Subscribe(this);
        Application.quitting += Dispose;
    }

    public void UpdateTimer()
    {
        _remainingTime -= Time.deltaTime;
        _gameplayMediator.DisplayTimer(_remainingTime, _prepTime);

        if (_remainingTime <= 0)
        {
            _comboHolder.PerformCombo();
        }
    }

    public void Dispose()
    {
        _timerUpdater.Unsubscribe(this);
        _gameplayMediator.DisplayFullTimer();
        Application.quitting -= Dispose;
    }

    public class Factory : PlaceholderFactory<FirstTapPrepTimer>
    {

    }
}
