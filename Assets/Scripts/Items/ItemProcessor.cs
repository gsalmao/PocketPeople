using UnityEngine;

namespace PocketPeople.Items
{
    /// <summary>
    /// Process the item usage.
    /// </summary>
    public class ItemProcessor
    {
        
        public static void UseItem(RuntimeItem item)
        {
            ItemData checkedItem = item.ItemData;

            Debug.Log("Checking new item to be used.");
            if(checkedItem is EquipmentData)
            {
                Debug.Log($"New Item is equipment:{checkedItem.ItemName}");
                Debug.Log($"Type is {(checkedItem as EquipmentData).Type.ToString()}");
                ProcessEquipment(checkedItem as EquipmentData);
                return;
            }

        }

        public static void ProcessEquipment(EquipmentData equipment)
        {
            
        }
    }
}
