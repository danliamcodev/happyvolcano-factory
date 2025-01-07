using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DelayedAction : MonoBehaviour
{
    [Header("Preferences")]
    [SerializeField] float _delay;
    [Header("Action")]
    [SerializeField] UnityEvent _delayFinished;

    void Start()
    {
        StartCoroutine(nameof(IETriggerAction));
    }

    private IEnumerator IETriggerAction()
    {
        yield return new WaitForSeconds(_delay);
        _delayFinished?.Invoke();
    }
}
