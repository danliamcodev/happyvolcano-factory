using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Systems.Stats
{
    public enum StatModifierType
    {
        Additive = 0,
        Percentage = 1,
        Multiplicative = 2,
        Flat = 3,
        Override = 4,
        Exponential = 5
    }
}
