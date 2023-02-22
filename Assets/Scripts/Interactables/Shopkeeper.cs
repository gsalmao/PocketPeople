using PocketPeople.Items;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper : Interactable
{
    [SerializeField] private List<BaseItem> itemsForSale;

    protected override void Interact()
    {
        base.Interact();
        OnToggleInteraction(true);
    }
}
