using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SickLab.Levels
{
    public interface ILevelManager
    {
        public void LoadLevel(int p_sceneIndex);

        public void LoadNextLevel();

        public void RestartLevel();

        public void QuitApplication();
    }
}
