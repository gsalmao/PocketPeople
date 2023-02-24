using UnityEngine;

namespace PocketPeople.Interactables.Shopkeeper
{
    /// <summary>
    /// Open the shop window.
    /// </summary>
    public class Shopkeeper : Interactable
    {
        [SerializeField] private ShopWindow shopWindow;

        protected override void Awake()
        {
            base.Awake();
            shopWindow.InitShopWindow();
        }

        protected override void Interact()
        {
            base.Interact();
            OnToggleInteractions(true);
            shopWindow.ToggleWindow();
        }
    }
}