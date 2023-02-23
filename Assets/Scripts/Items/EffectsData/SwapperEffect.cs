using PocketPeople.SpriteSwap;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.Items
{
    [CreateAssetMenu(fileName = "SwapperEffect", menuName = "ScriptableObjects/Items/Item Effects/Swapper", order = 0)]
    public class SwapperEffect : BaseEffect
    {
        [SerializeField] private string swapperKey;
        [SerializeField] private SwapperData swapperData;
        public string SwapperKey => swapperKey;

        public override void Activate()
        {
            
        }
    }
}
