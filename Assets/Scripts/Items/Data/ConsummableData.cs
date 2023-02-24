using UnityEngine;
using PocketPeople.Items.Effects;

namespace PocketPeople.Items.Data
{
    /// <summary>
    /// Consummable items.
    /// </summary>
    [CreateAssetMenu(fileName = "Consummable Item", menuName = "ScriptableObjects/Items/Consummable", order = 2)]
    public class ConsummableData : ItemData
    {
        [SerializeField] private BaseEffect useEffect;
        [SerializeField] private bool oneTime;

        public BaseEffect UseEffect => useEffect;
        public bool OneTime => oneTime;
    }
}
