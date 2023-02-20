using PocketPeople.SpriteSwap;
using UnityEngine;
using Sirenix.OdinInspector;

namespace PocketPeople.Items
{
    public abstract class EquippableItem : BaseItem
    {
        [SerializeField, FoldoutGroup("Equippable Properties")] public SpriteSwapperData spritesData;
        public abstract void Equip();
    }
}
