using UnityEngine;

namespace PocketPeople.Items
{
    /// <summary>
    /// Equipment item data.
    /// </summary>
    [CreateAssetMenu(fileName = "Simple Item", menuName = "ScriptableObjects/Items/Equipment", order = 1)]
    public class EquipmentData : ItemData
    {
        [SerializeField] private EquipmentSlot slot;
        [SerializeField] private BaseEffect equipEffect;

        public EquipmentSlot Slot => slot;
        public BaseEffect EquipEffect => equipEffect;
    }

    public enum EquipmentSlot
    {
        Shirt,
        Pants,
        Hat
    }
}
