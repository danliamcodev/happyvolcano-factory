using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Behaviours
{
    public class OnAwakeAction : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent _onAwake;

        // Start is called before the first frame update
        void Awake()
        {
            _onAwake?.Invoke();
        }
    }
}
