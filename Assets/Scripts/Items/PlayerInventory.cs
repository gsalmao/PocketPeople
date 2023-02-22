using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.Items
{
    /// <summary>
    /// Global values from the player's inventory.
    /// </summary>
    public static class PlayerInventory
    {
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

    }
}
