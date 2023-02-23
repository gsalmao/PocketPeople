using Sirenix.OdinInspector;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.SpriteSwap
{
    /// <summary>
    /// Handles the sprite swappers of each skin part of the character.
    /// </summary>
    public class CharacterSwapper : MonoBehaviour
    {
        [SerializeField] private List<SwapperContainer> containers;

        private void Awake()
        {
            foreach(SwapperContainer container in containers)
                container.Swapper.Init(container.Data);
        }
    }

    [System.Serializable]
    public class SwapperContainer
    {
        [SerializeField] private string key;
        [SerializeField] private Swapper swapper;
        [SerializeField] private SwapperData data;

        public string Key => key;
        public Swapper Swapper => swapper;
        public SwapperData Data => data;
    }
}
