using UnityEngine;
using PocketPeople.SpriteSwap;
using PocketPeople.Items.Effects;

namespace PocketPeople.Player
{
    /// <summary>
    /// This script is used to receive the effects of the items.
    /// </summary>
    [System.Serializable]
    public class PlayerEffects
    {
        private CharacterSwapper characterSwapper;

        public void Init(CharacterSwapper characterSwapper)
        {
            this.characterSwapper = characterSwapper;
            BaseEffect.OnActivate += ApplyEffect;            
        }
        
        ~PlayerEffects() => BaseEffect.OnActivate -= ApplyEffect;

        private void ApplyEffect(BaseEffect effect)
        {
            switch(effect)
            {
                case SwapperEffect:
                    SwapSkin(effect as SwapperEffect);
                    break;
            }
        }

        private void SwapSkin(SwapperEffect swapperEffect)
        {
            characterSwapper.Containers[swapperEffect.SwapperKey].Data = swapperEffect.SwapperData;
        }

    }
}
