using PocketPeople.UI;
using PocketPeople.Items;
using PocketPeople.Items.UI;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;

namespace PocketPeople.Interactables.Shopkeeper
{
    public class ShopWindow : BasicWindow
    {
        [SerializeField, FoldoutGroup("References")] private ItemsMenu playerMenu;
        [SerializeField, FoldoutGroup("References")] private ItemsMenu shopMenu;
        [SerializeField, FoldoutGroup("References")] private TextMeshProUGUI playerMoney;
        [SerializeField, FoldoutGroup("References")] private TextMeshProUGUI itemPrice;
        [SerializeField, FoldoutGroup("References")] private ItemDescription itemDescription;

        [SerializeField, FoldoutGroup("Shopkeeper Settings")] private Color buyColor;
        [SerializeField, FoldoutGroup("Shopkeeper Settings")] private Color sellColor;

        [SerializeField] private EventReference tradeSound;

        [SerializeField] private List<ItemData> availableItems;

        public void InitShopWindow()
        {
            OnUnhover();

            playerMenu.Init();
            shopMenu.Init();

            foreach (ItemData itemData in availableItems)
                shopMenu.CreateButton(new RuntimeItem(itemData), OnBuyHover, OnUnhover, OnBuy);
        }

        public override void ToggleWindow()
        {
            base.ToggleWindow();

            if (isOpening)
            {
                playerMenu.ClearMenu();
                foreach (RuntimeItem item in PlayerInventory.Items)
                    playerMenu.CreateButton(item, OnSellHover, OnUnhover, OnSell);
            }

            foreach (ItemButton itemButton in playerMenu.ItemButtons)
                itemButton.SetButtonActive(isOpening);

            foreach (ItemButton itemButton in shopMenu.ItemButtons)
                itemButton.SetButtonActive(isOpening);
        }

        private void OnUnhover()
        {
            itemDescription.Hide();
            playerMoney.color = Color.white;
            itemPrice.text = "";
            playerMoney.text = PlayerInventory.Money.ToString();
        }

        #region Sell Methods
        private void OnSellHover(RuntimeItem item)
        {
            itemDescription.Show(item);
            playerMoney.color = sellColor;
            playerMoney.text = (PlayerInventory.Money + item.ItemData.SellPrice).ToString();
            itemPrice.color = sellColor;
            itemPrice.text = $"+{item.ItemData.SellPrice}";
        }

        private void OnSell(ItemButton itemButton)
        {
            if (itemButton.Item == null) return;

            PlayerInventory.ReceiveMoney(itemButton.Item.ItemData.SellPrice);
            PlayerInventory.TakeItem(itemButton.Item);
            RuntimeManager.PlayOneShot(tradeSound);
            shopMenu.CreateButton(itemButton.Item, OnBuyHover, OnUnhover, OnBuy);
            playerMenu.DeleteButton(itemButton);
            OnUnhover();
        }
        #endregion

        #region Buy Methods
        private void OnBuyHover(RuntimeItem item)
        {
            itemDescription.Show(item);
            playerMoney.color = buyColor;
            playerMoney.text = item.ItemData.BuyPrice > PlayerInventory.Money ? "~" : (PlayerInventory.Money - item.ItemData.BuyPrice).ToString();
            itemPrice.color = buyColor;
            itemPrice.text = $"-{item.ItemData.BuyPrice}";
        }

        private void OnBuy(ItemButton itemButton)
        {
            if (itemButton.Item.ItemData.BuyPrice > PlayerInventory.Money)
                return;

            PlayerInventory.ReceiveItem(itemButton.Item);
            PlayerInventory.TakeMoney(itemButton.Item.ItemData.BuyPrice);
            RuntimeManager.PlayOneShot(tradeSound);
            playerMenu.CreateButton(itemButton.Item, OnSellHover, OnUnhover, OnSell);
            shopMenu.DeleteButton(itemButton);
            OnUnhover();
        }

        #endregion

    }
}