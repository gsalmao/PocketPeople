using UnityEngine;

namespace PocketPeople.Items
{
    [CreateAssetMenu(fileName = "HungerEffect", menuName = "ScriptableObjects/Items/Item Effects/Hunger", order = 1)]
    public class HungerEffect : BaseEffect
    {
        [SerializeField] private float nutrition;
        [SerializeField] private float hydration;

        public float Nutrition => nutrition;
        public float Hydration => hydration;
    }
}
