using UnityEngine;

namespace PocketPeople.SpriteSwap
{
    /// <summary>
    /// Scriptable object holding the sprite data of the spriteSwapper.
    /// </summary>
    [CreateAssetMenu(fileName = "SpriteSwapperData", menuName = "ScriptableObjects/SpriteSwapperData", order = 0)]
    public class SwapperData : ScriptableObject
    {
        [SerializeField] private Sprite[] sprites;
        public Sprite[] Sprites => sprites;
    }
}
