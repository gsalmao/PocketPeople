using UnityEngine;

namespace PocketPeople.SpriteSwap
{
    /// <summary>
    /// Allows to set and change sprites at will, without the need of an animation clip for each sprite.
    /// Use the Animator to change the spriteIndex and change the SpriteSwapperData to switch the animation's sprites.
    /// </summary>
    [RequireComponent(typeof(SpriteRenderer))]
    public class Swapper : MonoBehaviour
    {
        public int spriteIndex;
        protected SwapperData swapperData;
        private SpriteRenderer spriteRenderer;


        protected virtual void Awake() => spriteRenderer = GetComponent<SpriteRenderer>();

        public void Init(SwapperData swapperData) => this.swapperData = swapperData;

        public void ChangeSwapperData(SwapperData newData) => swapperData = newData;

        private void Update()
        {
            if (!swapperData)
                return;
            spriteRenderer.sprite = swapperData.Sprites[Mathf.Clamp(spriteIndex, 0, swapperData.Sprites.Length - 1)];
        }
    }
}
