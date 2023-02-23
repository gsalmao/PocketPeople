using PocketPeople.CursorEntities;
using System;

namespace PocketPeople.Interactables
{
    /// <summary>
    /// Interactable scene objects, such as npcs, signs and shopkeepers.
    /// </summary>
    public class Interactable : CursorModifier
    {
        public static Action<bool> OnToggleInteractions = delegate { };

        protected virtual void Awake() => IsActive = false;

        protected override void OnEnable()
        {
            base.OnEnable();
            OnClickCallback += Interact;
        }

        protected override void OnDisable()
        {
            base.OnDisable();
            OnClickCallback -= Interact;
        }

        protected virtual void Interact() { }
    }
}