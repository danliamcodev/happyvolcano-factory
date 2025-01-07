using SickLab.Events;
using SickLab.Services;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace SickLab.Levels
{
    public class LoadingScreen : MonoBehaviour
    {
        [Header("View")]
        [SerializeField] GameObject _view;
        [SerializeField] Transform _levelTransitionParent;
        [Header("Preferences")]
        [SerializeField] float _minimumTransitionDuration;
        EventTerminal _eventTerminal;

        private void Awake()
        {
            _eventTerminal = ServiceManager.Instance.GetService<EventTerminal>();
        }

        private void OnEnable()
        {
            _eventTerminal.AddListener<LevelTransitionEvent>(TransitionLevels);
        }

        private void OnDisable()
        {
            _eventTerminal.RemoveListener<LevelTransitionEvent>(TransitionLevels);
        }

        private void Start()
        {
            Scene currentScene = gameObject.scene;
            SceneManager.SetActiveScene(currentScene);
        }

        private void TransitionLevels(LevelTransitionEvent p_levelTransitionEvent)
        {
            LoadLevelTranstion(p_levelTransitionEvent.loadingScreenPrefab);
            StartCoroutine(nameof(IETransitionLevelsSequence), p_levelTransitionEvent);
        }

        private void LoadLevelTranstion(LevelTransition p_levelTransition)
        {
            Instantiate(p_levelTransition, _levelTransitionParent);
        }

        private IEnumerator IETransitionLevelsSequence(LevelTransitionEvent levelTransitionEvent)
        {
            float elapsedTime = 0f;


            AsyncOperation unloadSceneAsync = SceneManager.UnloadSceneAsync(levelTransitionEvent.sceneIndex);

            while (!unloadSceneAsync.isDone)
            {
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }

            AsyncOperation loadSceneAsync = SceneManager.LoadSceneAsync(levelTransitionEvent.sceneToTransitionToIndex, LoadSceneMode.Additive);

            while (!loadSceneAsync.isDone)
            {
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }

            while (elapsedTime < _minimumTransitionDuration)
            {
                elapsedTime += Time.unscaledDeltaTime;
                yield return null;
            }

            _view.SetActive(false);
            SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(levelTransitionEvent.sceneToTransitionToIndex));
            SceneManager.UnloadSceneAsync(gameObject.scene);
        }
    }
}

