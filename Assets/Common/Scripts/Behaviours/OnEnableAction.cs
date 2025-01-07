using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Behaviours
{
    public class OnEnableAction : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent _onEnable;

        private void OnEnable()
        {
            _onEnable?.Invoke();
        }
    }
}

