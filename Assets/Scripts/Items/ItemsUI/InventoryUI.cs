using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using PocketPeople.UI;

namespace PocketPeople.Items.UI
{
    public class InventoryUI : BasicWindow
    {

        [SerializeField, FoldoutGroup("References")] private ItemMenuObjectPool menu;

        private List<ItemButton> itemButtons;
        
        public void InitInventoryUI()
        {
            itemButtons = new List<ItemButton>();
            menu.InitItemMenu();

            foreach(BaseItem item in PlayerInventory.Items)
            {
                ItemButton newButton = menu.CreateButton();
                newButton.SetButton(item, ShowDescription, HideDescription);
                newButton.SetOnClick(OnClickItem);
                itemButtons.Add(newButton);
            }
        }

        private void OnClickItem(BaseItem item)
        {
            Debug.Log($"Clicked on {item.ItemName}");   //TODO: use item, remove from inventory
        }

        public override void ToggleMenu()
        {
            base.ToggleMenu();

            foreach (ItemButton itemButton in itemButtons)
                itemButton.SetButtonActive(isOpening);
        }

        private void ShowDescription(BaseItem item) => InventoryDescription.ShowDescription(item);
        private void HideDescription() => InventoryDescription.ShowDescription(null);
    }
}
