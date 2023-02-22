using PocketPeople.CursorEntities;

/// <summary>
/// Interactable scene objects, such as npcs, buttons and levers.
/// </summary>
public class Interactable : CursorModifier
{
    private void Awake() => IsActive = false;
}
