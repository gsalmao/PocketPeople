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

        public Dictionary<string, SwapperContainer> Containers;

        private void Awake()
        {
            Containers = new Dictionary<string, SwapperContainer>();

            foreach(SwapperContainer container in containers)
            {
                container.Swapper.Init(container.Data);
                Containers.Add(container.Key, container);
            }
        }
    }


    /// <summary>
    /// Container for holding the swapper's values. It's easier to set them all up in the inspector together.
    /// </summary>
    [System.Serializable]
    public class SwapperContainer
    {
        [SerializeField] private string key;
        [SerializeField] private Swapper swapper;
        [SerializeField] private SwapperData data;

        public string Key => key;
        public Swapper Swapper => swapper;
        public SwapperData Data
        {
            get => data;
            set
            {
                data = value;
                swapper.ChangeSwapperData(value);
            }
        }
    }
}
