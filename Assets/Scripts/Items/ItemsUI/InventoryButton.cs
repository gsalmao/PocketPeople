using PocketPeople.CursorEntities;
using PocketPeople.UI;
using UnityEngine;

namespace PocketPeople.Items.UI
{
    public class InventoryButton : CursorModifier
    {
        [SerializeField] private InventoryUI inventoryUI;

        public void OpenInventory()
        {
            if (!BasicWindow.WindowOnScreen)
                inventoryUI.ToggleMenu();
        }
    }
}
