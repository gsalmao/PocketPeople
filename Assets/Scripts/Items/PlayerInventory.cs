using System;
using System.Collections.Generic;

namespace PocketPeople.Items
{
    /// <summary>
    /// Global values of the player's inventory.
    /// </summary>
    public static class PlayerInventory
    {
        public static event Action OnChangeMoney = delegate { };
        public static event Action<RuntimeItem> OnReceiveItem = delegate { };
        public static event Action<RuntimeItem> OnTakeItem = delegate { };

        public static List<RuntimeItem> Items { get; private set; }
        public static int Money { get; private set; }

        private static bool initialized = false;

        public static PlayerEquipment PlayerEquipment { get; private set; }

        public static void Initialize(List<ItemData> initItems, int newMoney, List<EquipmentData> initEquipments)
        {
            if (initialized)
                return;

            //Inventory
            Items = new List<RuntimeItem>();

            foreach (ItemData item in initItems)
                Items.Add(new RuntimeItem(item));

            //Equipment
            List<RuntimeItem> initEquipmentsRuntime = new List<RuntimeItem>();

            foreach (EquipmentData initEquip in initEquipments)
                initEquipmentsRuntime.Add(new RuntimeItem(initEquip));

            PlayerEquipment = new PlayerEquipment(initEquipmentsRuntime);

            //Money
            Money = newMoney;

            initialized = true;
        }


        #region Item Operations
        public static void ReceiveItem(RuntimeItem item)
        {
            Items.Add(item);
            OnReceiveItem(item);
        }

        public static void TakeItem(RuntimeItem item)
        {
            Items.Remove(item);
            OnTakeItem(item);
        }
        #endregion

        #region Money Operations
        public static void ReceiveMoney(int amount)
        {
            Money += amount;
            OnChangeMoney();
        }

        public static void TakeMoney(int amount)
        {
            if (amount > Money)
                Money = 0;
            else
                Money -= amount;
            OnChangeMoney();
        }
        #endregion

    }
}
