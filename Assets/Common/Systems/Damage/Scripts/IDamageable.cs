using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Systems.Damage {
    public interface IDamageable
    {
        public UnityEvent<float> DamageReceived { get; }

        public void Damage(float p_damage);
    }
}

