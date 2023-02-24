using PocketPeople.Dialogues;
using UnityEngine;

namespace PocketPeople.Interactables
{
    /// <summary>
    /// Shows a dialogue.
    /// </summary>
    public class InteractableDialogue : Interactable
    {
        [SerializeField] private Dialogue dialogue;

        protected override void Interact()
        {
            base.Interact();
            DialogueController.ShowDialogue(dialogue);   
        }
    }
}