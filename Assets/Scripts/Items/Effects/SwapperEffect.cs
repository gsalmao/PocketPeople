using PocketPeople.SpriteSwap;
using UnityEngine;

namespace PocketPeople.Items.Effects
{
    [CreateAssetMenu(fileName = "SwapperEffect", menuName = "ScriptableObjects/Items/Item Effects/Swapper", order = 0)]
    public class SwapperEffect : BaseEffect
    {
        [SerializeField] private SwapperData swapperData;
        [SerializeField] private string swapperKey;

        public SwapperData SwapperData => swapperData;
        public string SwapperKey => swapperKey;
    }
}
