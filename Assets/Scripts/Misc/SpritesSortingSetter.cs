using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.Misc
{
    /// <summary>
    /// Sets the spriteRenderer's sorting order according to Y position.
    /// </summary>
    public class SpritesSortingSetter : MonoBehaviour
    {
        [SerializeField] private List<SpriteLayer> spriteLayers;

        void Update()
        {
            foreach(SpriteLayer spriteLayer in spriteLayers)
                spriteLayer.SpriteRenderer.sortingOrder = Mathf.RoundToInt(-transform.position.y * 300 + spriteLayer.Modifier);
        }
    }

    /// <summary>
    /// Holds a layer of the spriteRenderer, to decide which skin part goes on top of which.
    /// </summary>
    [System.Serializable]
    public class SpriteLayer
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private int modifier;

        public SpriteRenderer SpriteRenderer => spriteRenderer;
        public int Modifier => modifier;
    }
}
