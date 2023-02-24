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

            foreach(RuntimeItem item in Inventory.Items)
                inventoryMenu.CreateButton(item, description.Show, description.Hide, OnClickItem);

            playerMoney.text = Inventory.Money.ToString();

            Inventory.OnChangeMoney += UpdateMoneyUI;
            Inventory.OnReceiveItem += CreateNewItemButton;
            Inventory.OnTakeItem += DeleteItemButton;
        }

        private void OnDestroy()
        {
            Inventory.OnReceiveItem -= CreateNewItemButton;
            Inventory.OnTakeItem -= DeleteItemButton;
        }

        private void OnClickItem(ItemButton itemButton) => Inventory.UseItem(itemButton.Item);

        public override void ToggleWindow()
        {
            base.ToggleWindow();
            foreach (ItemButton itemButton in inventoryMenu.ItemButtons)
                itemButton.SetButtonActive(isOpening);
        }

        private void CreateNewItemButton(RuntimeItem newItem) =>inventoryMenu.CreateButton(newItem, description.Show, description.Hide, OnClickItem);
        private void DeleteItemButton(RuntimeItem itemTaken) => inventoryMenu.DeleteButton(itemTaken);
        private void UpdateMoneyUI() => playerMoney.text = Inventory.Money.ToString();
    }
}
