using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace SickLab.Systems.Heal
{
    public interface IHealable
    {
        public UnityEvent<float> HealingReceived { get; }

        public void Heal(float p_healing);
    }
}