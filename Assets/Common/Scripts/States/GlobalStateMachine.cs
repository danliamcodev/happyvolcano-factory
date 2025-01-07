using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.States
{
    [CreateAssetMenu(fileName = "GlobalStateMachine", menuName = "Sick Lab/States/State Machine")]
    public class GlobalStateMachine : ScriptableObject
    {
        [Header("Parameters")]
        [SerializeField] GlobalState _currentState;
        [SerializeField] GlobalState _testState;

        public GlobalState currentState => _currentState;
        public GlobalState testState => _testState;

        public void SetState(GlobalState p_state)
        {
            if (_currentState == p_state) return;
            if (_currentState != null) _currentState.ExitState();
            _currentState = p_state;
            _currentState.EnterState();
            _currentState.SetState();
            return;
        }

        public void ClearState()
        {
            _currentState = null;
        }
    }
}