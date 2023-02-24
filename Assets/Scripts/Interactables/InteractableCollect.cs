using FMODUnity;
using UnityEngine;
using PocketPeople.Items;
using PocketPeople.Items.Data;

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
            Inventory.ReceiveItem(new RuntimeItem(item));
            RuntimeManager.PlayOneShot(collectSound);
            Destroy(mainGameObject);
        }
    }
}
