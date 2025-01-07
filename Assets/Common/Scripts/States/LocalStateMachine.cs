using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.States
{
    public class LocalStateMachine : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] LocalState _currentState;

        Dictionary<LocalState, List<LocalStateListener>> _listeners = new Dictionary<LocalState, List<LocalStateListener>>();

        public LocalState currentState => _currentState;

        public void SetState(LocalState p_state)
        {
            if (_currentState == p_state) return;
            if (_currentState != null) TriggerOnStateExited();
            _currentState = p_state;
            TriggerOnStateEntered();
            TriggerOnStateSet();
            return;
        }

        public void ClearState()
        {
            _currentState = null;
        }

        private void TriggerOnStateEntered()
        {
            if (_listeners.TryGetValue(_currentState, out List<LocalStateListener> listeners))
            {
                foreach (LocalStateListener listener in listeners)
                {
                    listener.OnStateEntered();
                }
            }
        }

        private void TriggerOnStateSet()
        {
            if (_listeners.TryGetValue(_currentState, out List<LocalStateListener> listeners))
            {
                foreach (LocalStateListener listener in listeners)
                {
                    listener.OnStateSet();
                }
            }
        }

        private void TriggerOnStateExited()
        {
            if (_listeners.TryGetValue(_currentState, out List<LocalStateListener> listeners))
            {
                foreach (LocalStateListener listener in listeners)
                {
                    listener.OnStateExited();
                }
            }
        }

        public void RegisterListener(LocalState p_state, LocalStateListener p_listener)
        {
            if (_listeners.TryGetValue(p_state, out List<LocalStateListener> listeners))
            {
                if (!listeners.Contains(p_listener))
                    listeners.Add(p_listener);
            }
            else
            {
                listeners = new List<LocalStateListener>();
                _listeners.Add(p_state, listeners);
                listeners.Add(p_listener);
            }
        }

        public void UnregisterListener(LocalState p_state, LocalStateListener p_listener)
        {
            List<LocalStateListener> listeners = _listeners[p_state];
            if (listeners.Contains(p_listener))
                listeners.Remove(p_listener);
        }
    }
}