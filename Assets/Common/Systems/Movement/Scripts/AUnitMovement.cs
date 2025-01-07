using SickLab.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Systems.Movement
{
    public abstract class AUnitMovement : MonoBehaviour
    {
        [Header("Target Body")]
        [SerializeField] protected Rigidbody2D _targetBody;
        [Header("Properties")]
        [SerializeField] protected FloatReference _movementSped;

        public abstract void OnInputStarted(Vector2 p_direction);
        public abstract void OnInputPerformed(Vector2 p_direction);
        public abstract void OnInputCancelled(Vector2 p_direction);
        public abstract void Move(Vector2 p_direction);
    }
}