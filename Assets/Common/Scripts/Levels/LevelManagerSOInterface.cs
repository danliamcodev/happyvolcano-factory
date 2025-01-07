using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using SickLab.Events;
using SickLab.Services;

namespace SickLab.Levels
{
    [CreateAssetMenu(fileName = "LevelManagerSOInterface", menuName = "Sick Lab/Managers/Level Manager SO Interface")]
    public class LevelManagerSOInterface : ScriptableObject, ILevelManager
    {
        [Header("Events")]
        [SerializeField] FloatEvent _levelLoading;

        public void LoadLevel(int p_sceneIndex)
        {
            LevelManager levelManager = ServiceManager.Instance.GetService<LevelManager>();
            levelManager.LoadLevel(p_sceneIndex);
        }

        public void LoadNextLevel()
        {
            LevelManager levelManager = ServiceManager.Instance.GetService<LevelManager>();
            levelManager.LoadNextLevel();
        }

        public void RestartLevel()
        {
            LevelManager levelManager = ServiceManager.Instance.GetService<LevelManager>();
            levelManager.RestartLevel();
        }

        public void QuitApplication()
        {
            LevelManager levelManager = ServiceManager.Instance.GetService<LevelManager>();
            levelManager.QuitApplication();
        }
    }
}