using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Scenes = UnityEngine.SceneManagement;

namespace SickLab.SceneManagement
{
    public class AdditiveSceneLoader : MonoBehaviour
    {
        [SerializeField]
        private string[] _scenesToLoad;

        private void Awake()
        {
            for (int i = 0; i < _scenesToLoad.Length; i++)
            {
                string sceneName = _scenesToLoad[i];
                LoadSceneAdditively(sceneName);
            }
        }

        private void LoadSceneAdditively(string sceneName)
        {
            if (!string.IsNullOrEmpty(sceneName))
            {
                SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
            }
        }
    }
    
}
