using UnityEngine;

namespace PocketPeople.Items
{
    [CreateAssetMenu(fileName = "FoodItem", menuName = "ScriptableObjects/Items/Consummable/Food", order = 0)]
    public class FoodItem : ConsummableItem
    {
        [SerializeField] private float foodAmount;
        [SerializeField] private float waterAmount;

        public override void Use()
        {
                //TODO: Use
        }
    }
}
