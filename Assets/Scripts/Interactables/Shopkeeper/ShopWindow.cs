using PocketPeople.UI;
using PocketPeople.Items;
using PocketPeople.Items.UI;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : BasicWindow
{
    [SerializeField, FoldoutGroup("References")] private ItemMenuObjectPool playerMenu;
    [SerializeField, FoldoutGroup("References")] private ItemMenuObjectPool shopMenu;
    [SerializeField] private List<BaseItem> availableItems;

    private List<ItemButton> shopButtons;
    private List<ItemButton> playerButtons;

    public void InitShopWindow()
    {
        playerButtons = new List<ItemButton>();
        shopButtons = new List<ItemButton>();

        playerMenu.InitItemMenu();
        shopMenu.InitItemMenu();

        foreach (BaseItem item in PlayerInventory.Items)
        {
            ItemButton newButton = playerMenu.CreateButton();
            newButton.SetButton(item, null, null);
            newButton.SetOnClick(null);
            playerButtons.Add(newButton);
        }

        foreach (BaseItem item in availableItems)
        {
            ItemButton newButton = shopMenu.CreateButton();
            newButton.SetButton(item, null, null);
            newButton.SetOnClick(null);
            shopButtons.Add(newButton);
        }
    }

    public override void ToggleMenu()
    {
        base.ToggleMenu();

        foreach (ItemButton itemButton in playerButtons)
            itemButton.SetButtonActive(isOpening);

        foreach (ItemButton itemButton in shopButtons)
            itemButton.SetButtonActive(isOpening);
    }
}
