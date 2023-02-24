using System;
using System.Collections;
using UnityEngine;

namespace PocketPeople.Coroutines
{
    /// <summary>
    /// Holds main purpose coroutines.
    /// </summary>
    public static class MainCoroutines
    {
        public static IEnumerator WaitAnimation(Animator animator, Action callback = null, int layer = 0)
        {
            yield return new WaitForEndOfFrame();
            while (animator.GetCurrentAnimatorStateInfo(layer).normalizedTime < 1)
                yield return new WaitForFixedUpdate();
            callback?.Invoke();
        }
    }
}
