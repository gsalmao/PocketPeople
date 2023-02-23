using Sirenix.OdinInspector;
using UnityEngine;
using PocketPeople.UI;
using TMPro;

namespace PocketPeople.Items.UI
{
    public class InventoryUI : BasicWindow
    {
        [SerializeField, FoldoutGroup("References")] private ItemsMenu inventoryMenu;
        [SerializeField, FoldoutGroup("References")] private ItemDescription itemDescription;
        [SerializeField, FoldoutGroup("References")] private TextMeshProUGUI playerMoney;

        public void InitInventoryUI()
        {
            inventoryMenu.Init();

            foreach(BaseItem item in PlayerInventory.Items)
                inventoryMenu.CreateButton(item, itemDescription.ShowDescription, itemDescription.HideDescription, OnClickItem);

            playerMoney.text = PlayerInventory.Money.ToString();

            PlayerInventory.OnChangeMoney += UpdateMoneyUI;
            PlayerInventory.OnReceiveItem += CreateNewItemButton;
            PlayerInventory.OnTakeItem += DeleteItemButton;
        }

        private void OnDestroy()
        {
            PlayerInventory.OnReceiveItem -= CreateNewItemButton;
            PlayerInventory.OnTakeItem -= DeleteItemButton;
        }

        private void OnClickItem(ItemButton itemButton)
        {
            Debug.Log($"Clicked on {itemButton.Item.ItemName}");   //TODO: use item, remove from inventory
        }

        public override void ToggleWindow()
        {
            base.ToggleWindow();

            foreach (ItemButton itemButton in inventoryMenu.ItemButtons)
                itemButton.SetButtonActive(isOpening);
        }

        private void CreateNewItemButton(BaseItem newItem)
        {
            inventoryMenu.CreateButton(newItem, itemDescription.ShowDescription, itemDescription.HideDescription, OnClickItem);
        }

        private void DeleteItemButton(BaseItem itemTaken) => inventoryMenu.DeleteButton(itemTaken);

        private void UpdateMoneyUI() => playerMoney.text = PlayerInventory.Money.ToString();
    }
}
