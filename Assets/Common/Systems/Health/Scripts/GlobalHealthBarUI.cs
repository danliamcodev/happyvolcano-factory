using SickLab.Variables;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Systems.Health
{
    public class GlobalHealthBarUI : HealthBarUI
    {
        [Header("Health References")]
        [SerializeField] FloatReference _currentHealth;
        [SerializeField] FloatReference _maxHealth;

        private void OnEnable()
        {
            _currentHealth.ListenToVariables();
            _currentHealth.ValueUpdated.AddListener(OnCurrentHealthUpdated);
        }

        private void OnDisable()
        {
            _currentHealth.ValueUpdated.RemoveListener(OnCurrentHealthUpdated);
        }

        private void OnCurrentHealthUpdated(float currentHealth)
        {
            UpdateHealth(currentHealth, _maxHealth);
        }
    }
}

