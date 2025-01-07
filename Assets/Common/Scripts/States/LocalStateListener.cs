using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.States
{
    public class LocalStateListener : MonoBehaviour
    {
        [Header("References")]
        [SerializeField] LocalStateMachine _stateMachine;
        [Header("Parameters")]
        [SerializeField] LocalStateResponses _stateResponses;

        private void OnEnable()
        {
            _stateMachine.RegisterListener(_stateResponses.state, this);
        }

        private void OnDisable()
        {
            _stateMachine.UnregisterListener(_stateResponses.state, this);
        }

        public void OnStateEntered()
        {
            _stateResponses.onStateEnteredResponse.Invoke();
        }

        public void OnStateSet()
        {
            _stateResponses.onStateSetResponse.Invoke();
        }

        public void OnStateExited()
        {
            _stateResponses.onStateExitedResponse.Invoke();
        }
    }
}