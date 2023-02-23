using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.SpriteSwap
{
    public class RandomSwapper : Swapper
    {
        [SerializeField] private List<SwapperData> swapperDatas;

        protected override void Awake()
        {
            base.Awake();
            swapperData = swapperDatas[Random.Range(0, swapperDatas.Count)];
        }
    }
}
