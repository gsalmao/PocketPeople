using UnityEngine;

namespace PocketPeople.Items
{
    [CreateAssetMenu(fileName = "SceneryItem", menuName = "ScriptableObjects/Items/Consummable/Scenery", order = 1)]
    public class SceneryItem : ConsummableItem
    {
        [SerializeField] private Transform prefab;
        public override void Use()
        {
            //TODO: Use
        }
    }
}
