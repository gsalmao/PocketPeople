using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.SpriteSwap
{
    public class RandomSpriteSwapper : SpriteSwapper
    {
        [SerializeField] private List<SpriteSwapperData> swapperDatas;

        private void Awake() => data = swapperDatas[Random.Range(0, swapperDatas.Count)];
    }
}
