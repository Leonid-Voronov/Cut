using Cysharp.Threading.Tasks;
using System;
using System.Threading;
using Zenject;
using UnityEngine;

namespace Cut
{
    public class FirstTapPrepTimer : IPrepTimer
    {
        private CancellationTokenSource _cancellationTokenSource;
        private CancellationToken _cancellationToken;
        private IComboHolder _comboHolder;
        private float _time = 4f;

        [Inject]
        public FirstTapPrepTimer(CancellationTokenSource cancellationTokenSource)
        {
            _cancellationTokenSource = cancellationTokenSource;
            _cancellationToken = _cancellationTokenSource.Token;

            ComboHolder.ComboStarted += StartTimer;
            Application.quitting += Dispose;
        }

        private async void StartTimer(object sender, ComboStartedEventArgs e)
        {
            _comboHolder = e.ComboHolder;
            await RunScenatio();
        }

        private async UniTask RunScenatio()
        {
            await UniTask.Delay(TimeSpan.FromSeconds(_time));

            if (_cancellationToken.IsCancellationRequested)
            {
                return;
            }

            _comboHolder.PerformCombo();
        }

        public void Dispose()
        {
            _cancellationTokenSource.Cancel();
            ComboHolder.ComboStarted -= StartTimer;
            Application.quitting -= Dispose;
        }

        public class Factory  : PlaceholderFactory<FirstTapPrepTimer>
        {
        }
    }
}

