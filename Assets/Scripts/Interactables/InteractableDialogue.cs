using NodeCanvas.Framework;
using PocketPeople.Dialogues;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PocketPeople.Interactables
{
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