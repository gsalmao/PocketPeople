using System;

namespace PocketPeople.CursorEntities
{
    /// <summary>
    /// Callbacks to be used whenever extra funcionality within the cursors are necessary.
    /// </summary>
    public interface ICursorCallbacks
    {
        event Action OnPointerEnterCallback;
        event Action OnPointerDownCallback;
        event Action OnPointerExitCallback;
        event Action OnPointerUpCallback;
        event Action OnClickCallback;
    }
}
