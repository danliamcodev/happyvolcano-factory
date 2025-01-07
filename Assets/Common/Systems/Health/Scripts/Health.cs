using SickLab.Systems.Damage;
using SickLab.Systems.Heal;
using SickLab.Variables;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Systems.Health
{
    public class Health : MonoBehaviour, IDamageable, IHealable
    {
        [Header("Properties")]
        [SerializeField] FloatReference _maxHealth;
        [SerializeField] FloatReference _currentHealth;
        [Header("Events")]
        [SerializeField] UnityEvent<float, float> _healthUpdatedWithMaxHealth;
        [SerializeField] UnityEvent<float> _damageReceived;
        [SerializeField] UnityEvent<float> _healingReceived;

        public FloatReference maxHealth => _maxHealth;
        public FloatReference currentHealth => _currentHealth;
        public UnityEvent<float> DamageReceived => _damageReceived;
        public UnityEvent<float> HealingReceived => _healingReceived;

        private void Start()
        {
            SetHealth(_maxHealth);
        }

        public void SetHealth(float health)
        {
            float clampedHealth = Mathf.Clamp(health, 0f, _maxHealth);
            _currentHealth.SetValue(clampedHealth);
            _healthUpdatedWithMaxHealth?.Invoke(_currentHealth, _maxHealth);
        }

        public void Damage(float p_damage)
        {
            float damage = Mathf.Max(0f, p_damage);
            float health = _currentHealth - damage;
            SetHealth(health);
            _damageReceived?.Invoke(p_damage);
        }

        public void Heal(float p_healing)
        {
            float healing = Mathf.Max(0f, p_healing);
            float health = _currentHealth + healing;
            SetHealth(health);
            _healingReceived?.Invoke(p_healing);
        }
    }
}