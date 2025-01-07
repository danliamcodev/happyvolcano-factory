using SickLab.Properties;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Systems.Stats
{
    [System.Serializable]
    public class Stat : Property<float>
    {
        [SerializeField] StatType _type;
        public StatType type { get { return _type; } }
    }
}