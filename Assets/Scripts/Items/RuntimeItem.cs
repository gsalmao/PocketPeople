using PocketPeople.Items.Data;

namespace PocketPeople.Items
{
    /// <summary>
    /// For managing the item's instances in-game.
    /// </summary>
    public class RuntimeItem
    {
        public RuntimeItem(ItemData item)
        {
            ItemData = item;
        }

        public ItemData ItemData { get; private set; }
        
        public bool Equipped { get; set; }
    }
}
