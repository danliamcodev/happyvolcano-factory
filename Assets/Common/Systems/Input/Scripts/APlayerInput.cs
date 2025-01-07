using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Systems.Input
{
    public abstract class APlayerInput<T>
    {
        public Action<T> InputStarted;
        public Action<T> InputPerformed;
        public Action<T> InputCanceled;

        public void SignalInputStarted(T p_value)
        {
            InputStarted?.Invoke(p_value);
        }

        public void SignalInputPerformed(T p_value)
        {
            InputPerformed?.Invoke(p_value);
        }

        public void SignalInputCanceled(T p_value)
        {
            InputCanceled?.Invoke(p_value);
        }
    }
}

