using PocketPeople.CursorEntities;
using System;

/// <summary>
/// Interactable scene objects, such as npcs, buttons and levers.
/// </summary>
public class Interactable : CursorModifier
{
    public static Action<bool> OnToggleInteraction = delegate { };

    private void Awake() => IsActive = false;

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
