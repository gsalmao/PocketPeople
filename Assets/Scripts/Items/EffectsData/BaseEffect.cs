using UnityEngine;

namespace PocketPeople.Items
{
    /// <summary>
    /// Holds the effect of the items.
    /// </summary>
    public abstract class BaseEffect : ScriptableObject
    {
        public abstract void Activate();
    }
}
