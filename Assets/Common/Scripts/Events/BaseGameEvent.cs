using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

namespace SickLab.Events
{
    public abstract class BaseGameEvent<Type> : ScriptableObject
    {
        [SerializeField] Type _testValue;
        [SerializeField] bool _showDebugStack = false;
        /// <summary>
        /// The list of listeners that this event will notify if it is raised.
        /// </summary>
        private readonly List<IGameEventListener<Type>> _eventListeners = new List<IGameEventListener<Type>>();

        public Type testValue { get { return _testValue; } }

        public void Raise(Type p_parameter)
        {
            if (_showDebugStack)
            {
                DisplayListeners();
                LogStackTrace();
            }

            for (int i = _eventListeners.Count - 1; i >= 0; i--)
            {
                _eventListeners[i].OnEventRaised(p_parameter);
            }
        }

        public void RegisterListener(IGameEventListener<Type> p_listener)
        {
            if (!_eventListeners.Contains(p_listener))
                _eventListeners.Add(p_listener);
        }

        public void UnregisterListener(IGameEventListener<Type> p_listener)
        {
            if (_eventListeners.Contains(p_listener))
                _eventListeners.Remove(p_listener);
        }

        void DisplayListeners()
        {
            for (int i = 0; i < _eventListeners.Count; i++)
            {
                UnityEngine.Debug.Log(string.Format("{0} is listening", _eventListeners[i].ToString()));
            }
        }

        void LogStackTrace()
        {
            StackTrace stackTrace = new StackTrace();
            for (int i = 1; i < stackTrace.FrameCount; i++)
            {
                StackFrame frame = stackTrace.GetFrame(i);
                if (frame != null)
                {
                    string eventName = this.name;
                    string methodName = frame.GetMethod().Name;
                    string className = frame.GetMethod().DeclaringType.Name;
                    string message = $"Event: {eventName}, Method: {methodName}, Class: {className}";
                    UnityEngine.Debug.Log(message);
                }
            }
        }
    }

    public interface IGameEventListener<Type>
    {
        void OnEventRaised(Type p_parameter);
    }
}