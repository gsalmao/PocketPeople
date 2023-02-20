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
        [SerializeField] private Animator animator;
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
            animator.Play(fadeIn);
            yield return MainCoroutines.WaitAnimation(animator);
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
            animator.Play(fadeOut);
            yield return MainCoroutines.WaitAnimation(animator);

            string currentSceneActive = SceneManager.GetActiveScene().name;
            yield return UnloadScene(currentSceneActive);

            yield return LoadScene(scene);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(scene));

            animator.Play(fadeIn);
            yield return MainCoroutines.WaitAnimation(animator);

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