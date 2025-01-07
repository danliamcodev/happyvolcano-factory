using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.States
{
    public class GlobalStateListener : MonoBehaviour
    {
        [Header("Parameters")]
        [SerializeField] GlobalStateResponses _stateResponses;

        private void OnEnable()
        {
            _stateResponses.state.RegisterListener(this);
        }

        private void OnDisable()
        {
            _stateResponses.state.UnregisterListener(this);
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