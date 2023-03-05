using UnityEngine;

namespace PocketPeople.Items.Data
{
    /// <summary>
    /// Holds the basic data for the items. Items that can't be used/equipped are also created as this type.
    /// </summary>
    [CreateAssetMenu(fileName = "Simple Item", menuName = "ScriptableObjects/Items/Simple Item", order = 0)]
    public class ItemData : ScriptableObject
    {
        [SerializeField]
        private string itemName;
        [SerializeField, TextArea(3, 3)]
        private string description;
        [SerializeField]
        private int buyPrice;
        [SerializeField]
        private int sellPrice;
        [SerializeField]
        private Sprite icon;

        public Sprite Icon => icon;
        public string ItemName => itemName;
        public string Description => description;
        public int BuyPrice => buyPrice;
        public int SellPrice => sellPrice;
    }
}
