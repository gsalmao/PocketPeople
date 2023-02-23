using UnityEngine;

namespace PocketPeople.Interactables.Shopkeeper
{
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