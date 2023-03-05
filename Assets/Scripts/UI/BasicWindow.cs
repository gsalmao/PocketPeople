using FMODUnity;
using System;
using UnityEngine;

namespace PocketPeople.UI
{
    /// <summary>
    /// Basic window to be used whenever a new UI is shown on screen (inventory, shop's windows, dialogues).
    /// </summary>
    public class BasicWindow : MonoBehaviour
    {
        [SerializeField] private EventReference openMenuSound;
        [SerializeField] private EventReference closeMenuSound;

        /// <summary>
        /// Bool to check if any screen is already loaded, to prevent multiple windows on screen.
        /// </summary>
        public static bool WindowOnScreen;

        public static Action<bool> OnToggleMenu = delegate { };

        [SerializeField] protected Animator animator;

        protected bool isOpening;

        protected const string Open = "Open";
        protected const string Close = "Close";

        public virtual void ToggleWindow()
        {
            isOpening = !isOpening;

            if (isOpening)
                RuntimeManager.PlayOneShot(openMenuSound);
            else
                RuntimeManager.PlayOneShot(closeMenuSound);

            WindowOnScreen = isOpening;
            animator.Play(isOpening ? Open : Close);
            OnToggleMenu(isOpening);
        }
    }
}
