using UnityEngine;

namespace PocketPeople.Items
{
    [System.Serializable]
    public class Equipment
    {
        [SerializeField] private ShirtItem shirt;
        [SerializeField] private PantsItem pants;
        [SerializeField] private HatItem hat;

        public ShirtItem Shirt => shirt;
        public PantsItem Pants => pants;
        public HatItem Hat => hat;

        internal void InitClothes()
        {
            shirt?.Equip();
            pants?.Equip();
            hat?.Equip();
        }
    }
}
