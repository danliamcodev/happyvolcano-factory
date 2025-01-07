using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Variables
{
    public abstract class BaseVariable<Type> : ScriptableObject
    {
        [SerializeField] protected Type _value;
        //Events
        [SerializeField] protected UnityEvent<Type> _valueUpdated;
        /// <summary>
        /// <param name="arg1">T arg1 is the previous value.</param>
        /// <param name="arg2">T arg2 is the new value.</param>
        /// </summary>
        [SerializeField] protected UnityEvent<Type, Type> _valueUpdatedWithPrevious;
        public UnityEvent<Type> ValueUpdated => _valueUpdated;
        public UnityEvent<Type, Type> ValueUpdatedWithPrevious => _valueUpdatedWithPrevious;

        public Type value { get { return _value; } }

        private void OnEnable()
        {
            this.hideFlags = HideFlags.DontUnloadUnusedAsset;
        }

        public void SetValue(Type p_value)
        {
            Type previousValue = value;
            _value = p_value;
            _valueUpdated?.Invoke(_value);
            _valueUpdatedWithPrevious?.Invoke(previousValue, _value);

        }

        public void SetValue(BaseVariable<Type> p_value)
        {
            SetValue(p_value.value);
        }
    }

    public class BaseReference<Type, Variable> where Variable : BaseVariable<Type>
    {
        [SerializeField] bool _useConstant = true;
        [SerializeField] Type _constantValue;
        [SerializeField] Variable _variable;
        //Events
        [SerializeField] protected UnityEvent<Type> _valueUpdated;
        /// <summary>
        /// <param name="arg1">T arg1 is the previous value.</param>
        /// <param name="arg2">T arg2 is the new value.</param>
        /// </summary>
        [SerializeField] protected UnityEvent<Type, Type> _valueUpdatedWithPrevious;

        public Type value
        {
            get { return _useConstant ? _constantValue : _variable.value; }
        }
        public UnityEvent<Type> ValueUpdated => _valueUpdated;
        public UnityEvent<Type, Type> ValueUpdatedWithPrevious => _valueUpdatedWithPrevious;

        private void OnVariableValueUpdated(Type p_value)
        {
            _valueUpdated?.Invoke(p_value);
        }

        private void OnVariableValueUpdatedWithPrevious(Type p_previousValue, Type p_value)
        {
            _valueUpdatedWithPrevious?.Invoke(p_previousValue, p_value);
        }

        public void SetValue(Type p_value)
        {
            if (value != null && value.Equals(p_value))
                return;

            Type previousValue = value;

            if (_useConstant)
            {
                _constantValue = p_value;
                _valueUpdatedWithPrevious?.Invoke(previousValue, value);
                _valueUpdated?.Invoke(value);
            }
            else
            {
                _variable.SetValue(p_value);
            }
        }

        public void ListenToVariables()
        {
            if (_variable != null)
            {
                _variable.ValueUpdated.AddListener(OnVariableValueUpdated);
                _variable.ValueUpdatedWithPrevious.AddListener(OnVariableValueUpdatedWithPrevious);
            } else
            {
                Debug.LogError("No Variable Assigned");
            }
        }

        ~BaseReference()
        {
            if (_variable != null)
            {
                _variable.ValueUpdated.RemoveListener(OnVariableValueUpdated);
                _variable.ValueUpdatedWithPrevious.RemoveListener(OnVariableValueUpdatedWithPrevious);
            }
        }

        public BaseReference(Type value)
        {
            _useConstant = true;
            _constantValue = value;
        }

        public static implicit operator Type(BaseReference<Type, Variable> p_reference)
        {
            return p_reference.value;
        }
    }
}