using UnityEngine;
using FMODUnity;

namespace PocketPeople.Interactables
{
    /// <summary>
    /// Plays an animation when clicked.
    /// </summary>
    public class InteractableAnimation : Interactable
    {

        [SerializeField] private EventReference soundEvent;
        [SerializeField] private Animator animator;
        [SerializeField] private string animationName;

        protected override void Interact()
        {
            base.Interact();
            animator.Play(animationName);
            RuntimeManager.PlayOneShot(soundEvent);
        }
    }
}