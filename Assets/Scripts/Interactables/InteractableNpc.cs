using NodeCanvas.Framework;
using PocketPeople.Dialogues;
using UnityEngine;

namespace PocketPeople.Interactables
{
    /// <summary>
    /// Sends signals to the Npc's behaviour tree to change its behaviour.
    /// </summary>
    public class InteractableNpc : InteractableDialogue
    {
        [SerializeField] private Transform treeOwner;
        [SerializeField] private SignalDefinition startDialogueSignal;
        [SerializeField] private SignalDefinition endDialogueSignal;

        protected override void Interact()
        {
            base.Interact();
            startDialogueSignal.Invoke(treeOwner, treeOwner, false);
            DialogueController.OnEndDialogue += DialogueFinished;
        }

        private void DialogueFinished()
        {
            DialogueController.OnEndDialogue -= DialogueFinished;
            endDialogueSignal.Invoke(treeOwner, treeOwner, false);
        }
    }
}