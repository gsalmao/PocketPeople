using PocketPeople.UI;
using PocketPeople.Items;
using PocketPeople.Items.UI;
using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ShopWindow : BasicWindow
{
    [SerializeField, FoldoutGroup("References")] private ItemsMenu playerMenu;
    [SerializeField, FoldoutGroup("References")] private ItemsMenu shopMenu;
    [SerializeField, FoldoutGroup("References")] private TextMeshProUGUI playerMoney;
    [SerializeField, FoldoutGroup("References")] private TextMeshProUGUI itemPrice;
    [SerializeField, FoldoutGroup("References")] private ItemDescription itemDescription;

    [SerializeField, FoldoutGroup("Shopkeeper Settings")] private Color buyColor;
    [SerializeField, FoldoutGroup("Shopkeeper Settings")] private Color sellColor;
    [SerializeField] private List<BaseItem> availableItems;

    public void InitShopWindow()
    {
        OnUnhover();

        playerMenu.Init();
        shopMenu.Init();

        foreach (BaseItem item in availableItems)
            shopMenu.CreateButton(item, OnBuyHover, OnUnhover, OnBuy);
    }

    public override void ToggleMenu()
    {
        base.ToggleMenu();

        if (isOpening)
        {
            
            foreach (BaseItem item in PlayerInventory.Items)
                playerMenu.CreateButton(item, OnSellHover, OnUnhover, OnSell);
        }
        else
            playerMenu.ClearMenu();

        foreach (ItemButton itemButton in playerMenu.ItemButtons)
            itemButton.SetButtonActive(isOpening);

        foreach (ItemButton itemButton in shopMenu.ItemButtons)
            itemButton.SetButtonActive(isOpening);
    }

    private void OnUnhover()
    {
        itemDescription.HideDescription();
        playerMoney.color = Color.white;
        itemPrice.text = "";
        playerMoney.text = PlayerInventory.Money.ToString();
    }


    #region Sell Methods
    private void OnSellHover(BaseItem item)
    {
        itemDescription.ShowDescription(item);
        playerMoney.color = sellColor;
        playerMoney.text = (PlayerInventory.Money + item.SellPrice).ToString();
        itemPrice.color = sellColor;
        itemPrice.text = $"+{item.SellPrice}";
    }

    private void OnSell(ItemButton itemButton)
    {
        if (itemButton.Item == null) return;

        PlayerInventory.ReceiveMoney(itemButton.Item.SellPrice);
        PlayerInventory.TakeItem(itemButton.Item);

        shopMenu.CreateButton(itemButton.Item, OnBuyHover, OnUnhover, OnBuy);
        playerMenu.DeleteButton(itemButton);
        OnUnhover();
    }
    #endregion


    #region Buy Methods
    private void OnBuyHover(BaseItem item)
    {
        itemDescription.ShowDescription(item);
        playerMoney.color = buyColor;
        playerMoney.text = item.BuyPrice > PlayerInventory.Money ? "~" : (PlayerInventory.Money - item.BuyPrice).ToString();
        itemPrice.color = buyColor;
        itemPrice.text = $"-{item.BuyPrice}";
    }

    private void OnBuy(ItemButton itemButton)
    {
        if (itemButton.Item.BuyPrice > PlayerInventory.Money)
            return;

        PlayerInventory.ReceiveItem(itemButton.Item);
        PlayerInventory.TakeMoney(itemButton.Item.BuyPrice);

        playerMenu.CreateButton(itemButton.Item, OnSellHover, OnUnhover, OnSell);
        shopMenu.DeleteButton(itemButton);
        OnUnhover();
    }

    #endregion


}
