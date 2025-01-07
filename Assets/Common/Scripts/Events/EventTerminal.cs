using System;
using System.Collections.Generic;

namespace SickLab.Events
{
    public class EventTerminal
    {
        private readonly Dictionary<Type, List<Delegate>> _eventListeners = new();

        public void RaiseEvent<T>(T eventData)
        {
            Type eventType = typeof(T);

            if (_eventListeners.TryGetValue(eventType, out var listeners))
            {
                foreach (var listener in listeners)
                {
                    if (listener is Action<T> typedListener)
                    {
                        typedListener.Invoke(eventData);
                    }
                }
            }
        }

        public void AddListener<T>(Action<T> listener)
        {
            if (listener == null) throw new ArgumentNullException(nameof(listener));

            Type eventType = typeof(T);

            if (!_eventListeners.TryGetValue(eventType, out var listeners))
            {
                listeners = new List<Delegate>();
                _eventListeners[eventType] = listeners;
            }

            listeners.Add(listener);
        }

        public void RemoveListener<T>(Action<T> listener)
        {
            if (listener == null) throw new ArgumentNullException(nameof(listener));

            Type eventType = typeof(T);

            if (_eventListeners.TryGetValue(eventType, out var listeners))
            {
                listeners.Remove(listener);
                if (listeners.Count == 0)
                {
                    _eventListeners.Remove(eventType);
                }
            }
        }
    }
}
