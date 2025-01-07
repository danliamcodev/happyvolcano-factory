using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.States
{
    [CreateAssetMenu(fileName = "GlobalState", menuName = "Sick Lab/States/Global State")]
    public class GlobalState : ScriptableObject
    {
        [Header("Parametesr")]
        [SerializeField] bool _showDebugStack = false;

        private readonly List<GlobalStateListener> _stateListeners = new List<GlobalStateListener>();

        public void EnterState()
        {
            if (_showDebugStack)
            {
                DisplayListeners("entering");
            }

            for (int i = _stateListeners.Count - 1; i >= 0; i--)
            {
                _stateListeners[i].OnStateEntered();
            }

        }

        public void SetState()
        {
            if (_showDebugStack)
            {
                DisplayListeners("setting");
            }

            for (int i = _stateListeners.Count - 1; i >= 0; i--)
            {
                _stateListeners[i].OnStateSet();
            }
        }

        public void ExitState()
        {
            if (_showDebugStack)
            {
                DisplayListeners("exiting");
            }
            for (int i = _stateListeners.Count - 1; i >= 0; i--)
            {
                _stateListeners[i].OnStateExited();
            }
        }

        public void RegisterListener(GlobalStateListener p_listener)
        {
            if (!_stateListeners.Contains(p_listener))
                _stateListeners.Add(p_listener);
        }

        public void UnregisterListener(GlobalStateListener p_listener)
        {
            if (_stateListeners.Contains(p_listener))
                _stateListeners.Remove(p_listener);
        }

        void DisplayListeners(string p_state)
        {
            for (int i = 0; i < _stateListeners.Count; i++)
            {
                UnityEngine.Debug.Log(string.Format("{0} is listening to {1} {2}", _stateListeners[i].ToString(), this.name, p_state));
            }
        }
    }

    [System.Serializable]
    public class GlobalStateResponses
    {
        [Tooltip("State to register with.")]
        [SerializeField] GlobalState _state;

        [Tooltip("Response to invoke when State is entered.")]
        [SerializeField] UnityEvent _onStateEnteredResponse;

        [Tooltip("Response to invoke when State is set.")]
        [SerializeField] UnityEvent _onStateSetResponse;

        [Tooltip("Response to invoke when State is exited.")]
        [SerializeField] UnityEvent _onStateExitedResponse;

        public GlobalState state => _state;
        public UnityEvent onStateEnteredResponse => _onStateEnteredResponse;
        public UnityEvent onStateSetResponse => _onStateSetResponse;
        public UnityEvent onStateExitedResponse => _onStateExitedResponse;
    }
}
