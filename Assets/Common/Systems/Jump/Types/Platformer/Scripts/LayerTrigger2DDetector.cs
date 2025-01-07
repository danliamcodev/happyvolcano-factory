using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Jump
{
    public class LayerTrigger2DDetector : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] LayerMask _layer;
        [Header("Events")]
        [SerializeField] UnityEvent<Collider2D> _colliderEntered;
        [SerializeField] UnityEvent<Collider2D> _colliderExited;

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & _layer) != 0)
            {
                _colliderEntered?.Invoke(collision);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (((1 << collision.gameObject.layer) & _layer) != 0)
            {
                _colliderExited?.Invoke(collision);
            }
        }
    }
}
