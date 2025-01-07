using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Behaviours
{
    public class OnStartAction : MonoBehaviour
    {
        [Header("Events")]
        [SerializeField] UnityEvent _onStart;

        // Start is called before the first frame update
        void Start()
        {
            _onStart?.Invoke();
        }
    }

}
