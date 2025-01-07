using SickLab.Levels;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct LevelTransitionEvent
{
    int _sceneIndex;
    int _sceneToTransitionToIndex;
    LevelTransition _loadingScreenPrefab;

    public int sceneIndex => _sceneIndex;
    public int sceneToTransitionToIndex => _sceneToTransitionToIndex;
    public LevelTransition loadingScreenPrefab => _loadingScreenPrefab;

    public LevelTransitionEvent(int p_sceneIndex, int p_sceneToTransitionToIndex, LevelTransition p_loadingScreenPrefab)
    {
        _sceneIndex = p_sceneIndex;
        _sceneToTransitionToIndex = p_sceneToTransitionToIndex;
        _loadingScreenPrefab = p_loadingScreenPrefab;
    }
}
