using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Behaviours
{
    public class DontDestroyOnLoad : MonoBehaviour
    {
        private void Awake()
        {
            DontDestroyOnLoad(this);
        }
    }
}

