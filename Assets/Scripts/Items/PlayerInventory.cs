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

        public static void Initialize(List<Item> initItems, int newMoney)
        {
            if (initialized)
                return;

            Items = new List<RuntimeItem>();
            
            foreach (Item item in initItems)
                Items.Add(new RuntimeItem(item));

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
