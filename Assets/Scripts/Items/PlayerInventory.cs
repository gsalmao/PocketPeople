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
        public static event Action OnChangeInventory = delegate { };

        public static List<BaseItem> Items { get; private set; }
        public static int Money { get; private set; }

        private static bool initialized = false;

        public static void Initialize(List<BaseItem> newItems, int newMoney)
        {
            if (initialized)
                return;

            Items = newItems;
            Money = newMoney;
            initialized = true;
        }


        #region Item Operations
        public static void ReceiveItem(BaseItem item)
        {
            Items.Add(item);
            OnChangeInventory();
        }

        public static void TakeItem(BaseItem item)
        {
            Items.Remove(item);
            OnChangeInventory();
        }
        #endregion

        #region Money Operations
        public static void ReceiveMoney(int amount)
        {
            Money += amount;
        }

        public static void TakeMoney(int amount)
        {
            if (amount > Money)
                Money = 0;
            else
                Money -= amount;
        }
        #endregion

    }
}
