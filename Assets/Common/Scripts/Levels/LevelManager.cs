using SickLab.Events;
using SickLab.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SickLab.Levels
{
    public class LevelManager : AMonoSingleton<LevelManager>, ILevelManager
    {
        int _loadingSceneIndex = 5;

        public void LoadLevel(int p_sceneIndex)
        {
            SceneManager.LoadScene(p_sceneIndex);
        }

        public void LoadNextLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        public void QuitApplication()
        {
            Application.Quit();
        }

        IEnumerator LoadLevelAsyncTask(int p_sceneIndex, MonoBehaviour p_levelLoader)
        {
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(p_sceneIndex);

            while (!loadSceneAsync.isDone)
            {
                float progressValue = Mathf.Clamp01(loadSceneAsync.progress / 0.9f);
                yield return null;
            }
        }

        public void TransitionToLevel(int p_sceneIndex, LevelTransition p_loadingScreenPrefab)
        {
            LevelTransitionEvent levelTransitionEvent = new LevelTransitionEvent(SceneManager.GetActiveScene().buildIndex, p_sceneIndex, p_loadingScreenPrefab);
            StartCoroutine(nameof(IETransitionToLevelSequence), levelTransitionEvent);
        }

        private IEnumerator IETransitionToLevelSequence(LevelTransitionEvent levelTransitionEvent)
        {
            EventTerminal eventTerminal = ServiceManager.Instance.GetService<EventTerminal>();
            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(_loadingSceneIndex, LoadSceneMode.Additive);

            while (!loadSceneAsync.isDone)
            {
                yield return null;
            }

            eventTerminal.RaiseEvent<LevelTransitionEvent>(levelTransitionEvent);
        }
    }

}
