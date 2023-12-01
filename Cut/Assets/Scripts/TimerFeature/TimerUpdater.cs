using System.Collections.Generic;
using UnityEngine;

namespace Cut
{
    public class TimerUpdater : MonoBehaviour, ITimerUpdater
    {
        private List<IPrepTimer> _subscribers = new List<IPrepTimer>();

        private void Update()
        {
            for (int i = 0;  i < _subscribers.Count; i++) 
            {
                _subscribers[i].UpdateTimer();
            }
        }

        public void Subscribe(IPrepTimer newSubscriber) { _subscribers.Add(newSubscriber); }
        public void Unsubscribe(IPrepTimer subscriber) { _subscribers.Remove(subscriber); }
    }
}

