using UnityEngine;

namespace PocketPeople.Items
{
    /// <summary>
    /// Equipment item data.
    /// </summary>
    [CreateAssetMenu(fileName = "Simple Item", menuName = "ScriptableObjects/Items/Equipment", order = 1)]
    public class EquipmentData : ItemData
    {
        [SerializeField] private BaseEffect EquipEffect;
        [SerializeField] private EquipmentType type;

        public void OnEquip() => EquipEffect.Activate();
        public EquipmentType Type => type;
    }

    public enum EquipmentType
    {
        Shirt,
        Pants,
        Hat
    }
}
