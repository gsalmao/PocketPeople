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
    [SerializeField, FoldoutGroup("References")] private TextMeshProUGUI price;
    [SerializeField, FoldoutGroup("References")] private ItemDescription itemDescription;

    [SerializeField, FoldoutGroup("Shopkeeper Settings")] private Color buyColor;
    [SerializeField, FoldoutGroup("Shopkeeper Settings")] private Color sellColor;
    [SerializeField] private List<BaseItem> availableItems;

    public void InitShopWindow()
    {
        OnUnhover();

        playerMenu.Init();
        shopMenu.Init();

        foreach (BaseItem item in PlayerInventory.Items)
            playerMenu.CreateButton(item, OnSellHover, OnUnhover, OnSell);

        foreach (BaseItem item in availableItems)
            shopMenu.CreateButton(item, OnBuyHover, OnUnhover, OnBuy);
    }

    public override void ToggleMenu()
    {
        base.ToggleMenu();

        foreach (ItemButton itemButton in playerMenu.ItemButtons)
            itemButton.SetButtonActive(isOpening);

        foreach (ItemButton itemButton in shopMenu.ItemButtons)
            itemButton.SetButtonActive(isOpening);
    }

    private void OnUnhover()
    {
        itemDescription.HideDescription();
        price.color = Color.white;
        price.text = PlayerInventory.Money.ToString();
    }


    #region Sell Methods
    private void OnSellHover(BaseItem item)
    {
        itemDescription.ShowDescription(item);
        price.color = sellColor;
        price.text = (PlayerInventory.Money + item.SellPrice).ToString();
    }

    private void OnSell(ItemButton itemButton)
    {
        PlayerInventory.TakeItem(itemButton.Item);
        PlayerInventory.ReceiveMoney(itemButton.Item.SellPrice);

        shopMenu.CreateButton(itemButton.Item, OnBuyHover, OnUnhover, OnBuy);
        playerMenu.DeleteButton(itemButton);

    }
    #endregion


    #region Buy Methods
    private void OnBuyHover(BaseItem item)
    {
        itemDescription.ShowDescription(item);
        price.color = buyColor;
        price.text = item.BuyPrice > PlayerInventory.Money ? "~" : (PlayerInventory.Money - item.BuyPrice).ToString();
    }

    private void OnBuy(ItemButton itemButton)
    {
        if (itemButton.Item.BuyPrice > PlayerInventory.Money)
            return;

        PlayerInventory.ReceiveItem(itemButton.Item);
        PlayerInventory.TakeMoney(itemButton.Item.BuyPrice);

        playerMenu.CreateButton(itemButton.Item, OnSellHover, OnUnhover, OnSell);
        shopMenu.DeleteButton(itemButton);
    }

    #endregion


}
