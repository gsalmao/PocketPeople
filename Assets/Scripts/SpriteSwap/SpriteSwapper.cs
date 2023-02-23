using UnityEngine;

namespace PocketPeople.SpriteSwap
{

    /// <summary>
    /// Allows to set and change sprites at will, without the need of an animation clip for each sprite.
    /// Use the Animator to change the spriteIndex and change the SpriteSwapperData to switch the animation's sprites.
    /// </summary>
    public class SpriteSwapper : MonoBehaviour
    {
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] protected SpriteSwapperData data;
        public int spriteIndex;

        private void Update() => spriteRenderer.sprite = data?.Sprites[Mathf.Clamp(spriteIndex, 0, data.Sprites.Length - 1)];

    }
}
