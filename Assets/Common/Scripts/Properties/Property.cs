using System;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Properties
{
    [System.Serializable]
    public abstract class Property<T>
    {
        [SerializeField] protected T _value;
        [SerializeField] protected UnityEvent<T> _onChange;
        /// <summary>
        /// <param name="arg1">T arg1 is the previous value.</param>
        /// <param name="arg2">T arg2 is the new value.</param>
        /// </summary>
        [SerializeField] protected UnityEvent<T, T> _onChangeWithPrevious;

        public T value => _value;   
        public UnityEvent<T> OnChange => _onChange;
        public UnityEvent<T, T> OnChangeWithPrevious => _onChangeWithPrevious;

        public virtual void SetValue(T value)
        {
            if (_value != null && _value.Equals(value))
                return;

            T previousValue = _value;
            _value = value;

            _onChangeWithPrevious?.Invoke(previousValue, _value);
            _onChange?.Invoke(_value);
        }


        public static implicit operator T(Property<T> property)
        {
            return property.value;
        }
    }
}