using NodeCanvas.Framework;
using PocketPeople.Dialogues;
using Sirenix.OdinInspector;
using UnityEngine;

namespace PocketPeople.Interactables
{
    /// <summary>
    /// Variation of the interactableDialogue, that sends signals to the npc's behaviour tree to change its behaviour.
    /// </summary>
    public class InteractableNpc : InteractableDialogue
    {
        [SerializeField, FoldoutGroup("NodeCanvas References")] private Transform treeOwner;
        [SerializeField, FoldoutGroup("NodeCanvas References")] private SignalDefinition startDialogueSignal;
        [SerializeField, FoldoutGroup("NodeCanvas References")] private SignalDefinition endDialogueSignal;

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