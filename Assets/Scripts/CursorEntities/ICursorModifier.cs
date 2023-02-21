namespace PocketPeople.CursorEntities
{
    /// <summary>
    /// Interface for every entity that requires cursor interactions, both scene objects and UI objects.
    /// </summary>
    public interface ICursorModifier
    {
        public void OnCursorEnter();
        public void OnCursorExit();
        public void OnPointerDown();
        public void OnPointerUp();
    }
}
