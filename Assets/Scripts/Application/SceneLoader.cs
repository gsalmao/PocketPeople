using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using PocketPeople.Coroutines;
using Sirenix.OdinInspector;
using System.Collections.Generic;

namespace PocketPeople.Application
{
    /// <summary>
    /// Load scenes in the game and set them as active.
    /// </summary>
    public class SceneLoader : MonoBehaviour
    {
        [SerializeField] private Animator fadeAnimator;
        [SerializeField] private string firstScene;

        private static event Action<string, Action> OnChangeScene = delegate { };
        private static bool switchingScenes = false;

        private const string application = "Application";
        private const string fadeIn = "FadeIn";
        private const string fadeOut = "FadeOut";

        public void Start()
        {
            OnChangeScene += SwitchScene;

            List<Scene> scenes = new List<Scene>();
            for (int i = 0; i < SceneManager.sceneCount; i++)
                scenes.Add(SceneManager.GetSceneAt(i));

            if(!GameManager.Debugging)
            {
                StartCoroutine(InitCoroutine(firstScene));
            }
            else
            {
                foreach(Scene scene in scenes)
                {
                    if (scene.name != application)
                    {
                        fadeAnimator.Play(fadeIn);
                        SceneManager.SetActiveScene(scene);
                        break;
                    }
                }
            }
        }

        private void OnDestroy() => OnChangeScene -= SwitchScene;


        private IEnumerator InitCoroutine(string scene)
        {
            yield return LoadScene(scene);
            fadeAnimator.Play(fadeIn);
            yield return MainCoroutines.WaitAnimation(fadeAnimator);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));
        }

        /// <summary>
        /// Load the next scene, set it as active and unload the current one.
        /// </summary>
        [Button("Change Scene")]
        public static void ChangeScene(string nextScene, Action callback)
        {
            if (switchingScenes)
                return;
            OnChangeScene(nextScene, callback);
        }

        private void SwitchScene(string scene, Action callback) => StartCoroutine(SwitchSceneCoroutine(scene, callback));

        private IEnumerator SwitchSceneCoroutine(string scene, Action callback)
        {
            switchingScenes = true;
            fadeAnimator.Play(fadeOut);
            yield return MainCoroutines.WaitAnimation(fadeAnimator);

            string currentSceneActive = SceneManager.GetActiveScene().name;
            yield return UnloadScene(currentSceneActive);

            yield return LoadScene(scene);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));

            fadeAnimator.Play(fadeIn);
            yield return MainCoroutines.WaitAnimation(fadeAnimator);

            callback?.Invoke();
            switchingScenes = false;
        }

        private IEnumerator LoadScene(string scene)
        {
            AsyncOperation operation = SceneManager.LoadSceneAsync(scene, LoadSceneMode.Additive);
            yield return new WaitUntil(() => operation.isDone);
        }

        private IEnumerator UnloadScene(string scene)
        {
            AsyncOperation operation = SceneManager.UnloadSceneAsync(scene);
            yield return new WaitUntil(() => operation.isDone);
        }

    }
}