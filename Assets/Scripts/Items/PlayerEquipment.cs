using System.Collections.Generic;

namespace PocketPeople.Items
{
    /// <summary>
    /// Handles player's equipped items.
    /// </summary>
    public class PlayerEquipment
    {
        private List<RuntimeItem> equippedItems;

        public PlayerEquipment(List<RuntimeItem> newEquipments)
        {
            equippedItems = new List<RuntimeItem>();

            foreach(RuntimeItem newEquip in newEquipments)
                equippedItems.Add(newEquip);
        }
    }
}
