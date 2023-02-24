using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.Items
{
    /// <summary>
    /// Handles player's equipped items.
    /// </summary>
    public class PlayerEquipment
    {
        private Dictionary<EquipmentSlot, RuntimeItem> slots;
        private List<RuntimeItem> equippedItems;

        public PlayerEquipment(List<RuntimeItem> newEquipments)
        {
            slots = new Dictionary<EquipmentSlot, RuntimeItem>();
            equippedItems = new List<RuntimeItem>();

            foreach(RuntimeItem newEquip in newEquipments)
            {
                EquipmentData equipmentData = newEquip.ItemData as EquipmentData;
                EquipmentSlot newEquipSlot = equipmentData.Slot;

                if (slots.ContainsKey(newEquipSlot))   //Safety measure to prevent initializing two items in the same slot.
                    continue;

                equippedItems.Add(newEquip);
                slots.Add((newEquip.ItemData as EquipmentData).Slot, newEquip);
                equipmentData.EquipEffect.Activate();
            }
        }

        public void EquipItem(RuntimeItem newEquipment)
        {
            EquipmentSlot newEquipmentSlot = (newEquipment.ItemData as EquipmentData).Slot;
            
            if(slots.ContainsKey(newEquipmentSlot))
            {
                PlayerInventory.ReceiveItem(slots[newEquipmentSlot]);
                slots.Remove(newEquipmentSlot);
            }

            slots.Add(newEquipmentSlot, newEquipment);
            PlayerInventory.TakeItem(newEquipment);
        }
    }
}
