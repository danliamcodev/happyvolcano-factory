using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Systems.Stats
{
    [System.Serializable]
    public class StatModifier
    {
        [SerializeField] StatModifierType _type;
        public StatModifierType type => _type;
    }
}
