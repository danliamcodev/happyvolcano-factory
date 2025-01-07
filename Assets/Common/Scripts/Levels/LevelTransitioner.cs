using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SickLab.Levels
{
    public class LevelTransitioner : MonoBehaviour
    {
        [Header("Properties")]
        [SerializeField] int _sceneToTransitionToIndex;
        [SerializeField] LevelTransition _levelScreenPrefab;

        public void Transition()
        {
            LevelManager.Instance.TransitionToLevel(_sceneToTransitionToIndex, _levelScreenPrefab);
        }
    }
}

