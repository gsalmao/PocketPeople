using UnityEngine;
using Sirenix.OdinInspector;

namespace PocketPeople.Items
{
    /// <summary>
    /// Holds the data for the items.
    /// </summary>
    [CreateAssetMenu(fileName = "Simple Item", menuName = "ScriptableObjects/Items/Item", order = 0)]
    public class ItemData : ScriptableObject
    {
        [SerializeField, LabelText("Name"), FoldoutGroup("Item Properties")]
        private string itemName;
        [SerializeField, TextArea(3, 3), FoldoutGroup("Item Properties")]
        private string description;
        [SerializeField, FoldoutGroup("Item Properties")]
        private int buyPrice;
        [SerializeField, FoldoutGroup("Item Properties")]
        private int sellPrice;
        [SerializeField, HideLabel, PreviewField(ObjectFieldAlignment.Left, Height = 100f), FoldoutGroup("Item Properties")]
        private Sprite icon;

        public Sprite Icon => icon;
        public string ItemName => itemName;
        public string Description => description;
        public int BuyPrice => buyPrice;
        public int SellPrice => sellPrice;
    }
}
