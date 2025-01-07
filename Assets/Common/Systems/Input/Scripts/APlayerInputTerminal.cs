using SickLab.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace SickLab.Systems.Input
{
    public abstract class APlayerInputTerminal<TInput, TValue> : MonoBehaviour
        where TInput : APlayerInput<TValue>, new()
        where TValue : struct
    {
        [Header("Properties")]
        [SerializeField] int _id;
        [Header("Events")]
        [SerializeField] UnityEvent<TValue> _inputStarted;
        [SerializeField] UnityEvent<TValue> _inputPerformed;
        [SerializeField] UnityEvent<TValue> _inputCanceled;
        TInput _input;

        private void Awake()
        {
            _input = ServiceManager.Instance.GetService<TInput>(_id.ToString());
        }

        private void OnEnable()
        {
            _input.InputStarted += OnInputStarted;
            _input.InputPerformed += OnInputPerformed;
            _input.InputCanceled += OnInputCanceled;
        }

        private void OnDisable()
        {
            _input.InputStarted -= OnInputStarted;
            _input.InputPerformed -= OnInputPerformed;
            _input.InputCanceled -= OnInputCanceled;
        }

        public void SendInput(InputAction.CallbackContext p_context)
        {
                switch (p_context.phase)
                {
                    case InputActionPhase.Started:
                        _input.SignalInputStarted(p_context.ReadValue<TValue>());
                        break;
                    case InputActionPhase.Performed:
                        _input.SignalInputPerformed(p_context.ReadValue<TValue>());
                        break;
                    case InputActionPhase.Canceled:
                        _input.SignalInputCanceled(p_context.ReadValue<TValue>());
                        break;
                }
        }

        public void SendInput(TValue p_value)
        {
            _input.SignalInputStarted(p_value);
        }

        public void OnInputStarted(TValue p_value)
        {
            _inputStarted?.Invoke(p_value);
        }

        public void OnInputPerformed(TValue p_value)
        { 
            _inputPerformed?.Invoke(p_value);
        }

        public void OnInputCanceled(TValue p_value)
        {  
            _inputCanceled?.Invoke(p_value);
        }
    }
}

