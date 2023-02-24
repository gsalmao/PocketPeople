using System;
using UnityEngine;

namespace PocketPeople.Items.Effects
{
    /// <summary>
    /// Holds the effect of the items.
    /// </summary>
    public abstract class BaseEffect : ScriptableObject
    {
        public static event Action<BaseEffect> OnActivate;
        public void Activate() => OnActivate(this);
    }
}
