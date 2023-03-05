using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FMODUnity;
using PocketPeople.UI;
using PocketPeople.Items;
using PocketPeople.Items.UI;
using PocketPeople.Items.Data;

namespace PocketPeople.Interactables.Shopkeeper
{
    /// <summary>
    /// Responsible for the shop's items and the player's items, where both can be traded.
    /// </summary>
    public class ShopWindow : BasicWindow
    {
        [SerializeField] private ItemsMenu playerMenu;
        [SerializeField] private ItemsMenu shopMenu;
        [SerializeField] private TextMeshProUGUI playerMoney;
        [SerializeField] private TextMeshProUGUI itemPrice;
        [SerializeField] private ItemDescription itemDescription;

        [SerializeField] private Color buyColor;
        [SerializeField] private Color sellColor;

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
                foreach (RuntimeItem item in Inventory.Items)
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
            playerMoney.text = Inventory.Money.ToString();
        }

        #region Sell Methods
        private void OnSellHover(RuntimeItem item)
        {
            itemDescription.Show(item);
            playerMoney.color = sellColor;
            playerMoney.text = (Inventory.Money + item.ItemData.SellPrice).ToString();
            itemPrice.color = sellColor;
            itemPrice.text = $"+{item.ItemData.SellPrice}";
        }

        private void OnSell(ItemButton itemButton)
        {
            if (itemButton.Item == null) return;

            Inventory.ReceiveMoney(itemButton.Item.ItemData.SellPrice);
            Inventory.TakeItem(itemButton.Item);
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
            playerMoney.text = item.ItemData.BuyPrice > Inventory.Money ? "~" : (Inventory.Money - item.ItemData.BuyPrice).ToString();
            itemPrice.color = buyColor;
            itemPrice.text = $"-{item.ItemData.BuyPrice}";
        }

        private void OnBuy(ItemButton itemButton)
        {
            if (itemButton.Item.ItemData.BuyPrice > Inventory.Money)
                return;

            Inventory.ReceiveItem(itemButton.Item);
            Inventory.TakeMoney(itemButton.Item.ItemData.BuyPrice);
            RuntimeManager.PlayOneShot(tradeSound);
            playerMenu.CreateButton(itemButton.Item, OnSellHover, OnUnhover, OnSell);
            shopMenu.DeleteButton(itemButton);
            OnUnhover();
        }

        #endregion

    }
}