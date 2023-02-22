using PocketPeople.UI;
using PocketPeople.Items;
using PocketPeople.Items.UI;
using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopWindow : BasicWindow
{
    [SerializeField, FoldoutGroup("References")] private ItemMenuObjectPool playerItemsPool;
    [SerializeField, FoldoutGroup("References")] private ItemMenuObjectPool shopItemsPool;

    [SerializeField] private List<ItemButton> playerItems;
    [SerializeField] private List<ItemButton> shopItems;

    public void InitShopWindow()
    {
        playerItems = new List<ItemButton>();
        shopItems = new List<ItemButton>();

        playerItemsPool.InitItemMenu();

        //foreach (BaseItem item in items)
        //{
        //    ItemButton newButton = itemMenu.CreateButton().GetComponent<ItemButton>();
        //    newButton.SetButton(item, ShowDescription, HideDescription);
        //    newButton.SetOnClick(OnClickItem);

        //    itemButtons.Add(newButton);

        //}
    }


    public override void ToggleMenu()
    {
        base.ToggleMenu();

        //foreach (ItemButton itemButton in playerItems)
        //    itemButton.SetButtonActive(isOpening);
    }
}
