using FMODUnity;
using PocketPeople.Items;
using UnityEngine;

namespace PocketPeople.Interactables
{
    /// <summary>
    /// When interacted with, adds an item to the player's inventory and destroys itself.
    /// </summary>
    public class InteractableCollect : Interactable
    {
        [SerializeField] private ItemData item;
        [SerializeField] private EventReference collectSound;
        [SerializeField] private GameObject mainGameObject;
        protected override void Interact()
        {
            base.Interact();
            PlayerInventory.ReceiveItem(new RuntimeItem(item));
            RuntimeManager.PlayOneShot(collectSound);
            Destroy(mainGameObject);
        }
    }
}
