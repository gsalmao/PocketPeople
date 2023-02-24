using Sirenix.OdinInspector;
using UnityEngine;
using PocketPeople.UI;
using TMPro;

namespace PocketPeople.Items.UI
{
    public class InventoryUI : BasicWindow
    {
        [SerializeField, FoldoutGroup("References")] private ItemsMenu inventoryMenu;
        [SerializeField, FoldoutGroup("References")] private ItemDescription description;
        [SerializeField, FoldoutGroup("References")] private TextMeshProUGUI playerMoney;

        public void InitInventoryUI()
        {
            inventoryMenu.Init();

            foreach(RuntimeItem item in PlayerInventory.Items)
                inventoryMenu.CreateButton(item, description.Show, description.Hide, OnClickItem);

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

        private void OnClickItem(ItemButton itemButton) => PlayerInventory.UseItem(itemButton.Item);

        public override void ToggleWindow()
        {
            base.ToggleWindow();

            foreach (ItemButton itemButton in inventoryMenu.ItemButtons)
                itemButton.SetButtonActive(isOpening);
        }

        private void CreateNewItemButton(RuntimeItem newItem) =>inventoryMenu.CreateButton(newItem, description.Show, description.Hide, OnClickItem);
        private void DeleteItemButton(RuntimeItem itemTaken) => inventoryMenu.DeleteButton(itemTaken);
        private void UpdateMoneyUI() => playerMoney.text = PlayerInventory.Money.ToString();
    }
}
