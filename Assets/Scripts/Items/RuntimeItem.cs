using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.Items
{
    /// <summary>
    /// For managing the item's instances in-game.
    /// </summary>
    public class RuntimeItem
    {
        public RuntimeItem(Item item)
        {
            ItemData = item;
        }

        public Item ItemData { get; private set; }
        
    }
}
