using Sirenix.OdinInspector;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.UI
{
    /// <summary>
    /// Basic window to be used whenever a new UI is shown on screen (inventory, shop's windows, etc).
    /// </summary>
    public class BasicWindow : MonoBehaviour
    {
        public static Action<bool> OnToggleMenu = delegate { };

        [SerializeField, FoldoutGroup("References")] private Animator animator;

        protected bool isOpening;

        protected const string Open = "Open";
        protected const string Close = "Close";

        public virtual void ToggleMenu()
        {
            isOpening = !isOpening;
            animator.Play(isOpening ? Open : Close);
            OnToggleMenu(isOpening);
        }
    }
}
