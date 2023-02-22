using Sirenix.OdinInspector;
using UnityEngine;
using PocketPeople.UI;

namespace PocketPeople.Items.UI
{
    public class InventoryUI : BasicWindow
    {

        [SerializeField, FoldoutGroup("References")] private ItemsMenu inventoryMenu;
        
        public void InitInventoryUI()
        {
            inventoryMenu.InitItemMenu();

            foreach(BaseItem item in PlayerInventory.Items)
                inventoryMenu.CreateButton(item, ShowDescription, HideDescription, OnClickItem);
        }

        private void OnClickItem(ItemButton itemButton)
        {
            Debug.Log($"Clicked on {itemButton.Item.ItemName}");   //TODO: use item, remove from inventory
        }

        public override void ToggleMenu()
        {
            base.ToggleMenu();

            foreach (ItemButton itemButton in inventoryMenu.ItemButtons)
                itemButton.SetButtonActive(isOpening);
        }

        private void ShowDescription(BaseItem item) => InventoryDescription.ShowDescription(item);
        private void HideDescription() => InventoryDescription.ShowDescription(null);
    }
}
