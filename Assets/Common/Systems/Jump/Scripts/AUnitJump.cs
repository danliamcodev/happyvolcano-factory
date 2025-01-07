using SickLab.Variables;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Systems.Jump
{
    public abstract class AUnitJump : MonoBehaviour
    {
        [Header("Target Body")]
        [SerializeField] protected Rigidbody2D _targetBody;
        [Header("Properties")]
        [SerializeField] protected FloatReference _jumpForce;
        [SerializeField] IntReference _maxJumps;
        [SerializeField] FloatReference _cooldown;
        [SerializeField] FloatReference _inputAllowance;
        [Header("Events")]
        [SerializeField] UnityEvent _unitJumped;
        [SerializeField] UnityEvent _cooldownStarted;
        [SerializeField] UnityEvent _cooldownFinished;
        int _jumpCount;
        bool _isOnCooldown;

        private bool _hasJumps { get
            {
                if (_jumpCount >= _maxJumps) return false;
                return true;
            }
        }

        private void Start()
        {
            _isOnCooldown = false;
            _jumpCount = 0;
        }

        public abstract void OnInputStarted(float p_value);
        public virtual void OnInputPerformed(float p_value)
        {
            if (_isOnCooldown) return;
            StartCoroutine(nameof(IEJumpInputProcess), p_value);
        }
        public abstract void OnInputCanceled(float p_value);
        public virtual void Jump(float p_value)
        {
            _jumpCount++;
            _unitJumped?.Invoke();
        }

        protected virtual IEnumerator IEJumpInputProcess(float p_value)
        {
            float timer = 0f;
            bool hasJumped = false;
            _isOnCooldown = true;
            _cooldownStarted?.Invoke();
            while (timer < _inputAllowance && !hasJumped)
            {
                if (_hasJumps)
                {
                    Jump(p_value);
                    hasJumped |= true;
                }
                timer += Time.deltaTime;
                yield return null;
            }

            while (timer < _cooldown)
            {
                timer += Time.deltaTime;
                yield return null;
            }
            _isOnCooldown = false;
            _cooldownFinished?.Invoke();
        }

        public void ResetJumps()
        {
            _jumpCount = 0;
        }
    }
}