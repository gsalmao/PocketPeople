using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PocketPeople.Items;
using PocketPeople.SpriteSwap;
using Sirenix.OdinInspector;

namespace PocketPeople.Player
{
    /// <summary>
    /// This script is used to receive the effects of the items.
    /// </summary>
    [System.Serializable]
    public class PlayerEffects
    {
        [SerializeField, FoldoutGroup("Effects References")] private CharacterSwapper characterSwapper;

        public void Init() => BaseEffect.OnActivate += ApplyEffect;
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
