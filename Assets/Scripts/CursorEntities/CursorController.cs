using UnityEngine;

namespace PocketPeople.CursorEntities
{
    /// <summary>
    /// Handles mouse sprite changes.
    /// </summary>
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private Texture2D idleCursor;
        [SerializeField] private Texture2D hoverCursor;
        [SerializeField] private Texture2D pressingCursor;

        private static Texture2D IdleCursor;
        private static Texture2D HoverCursor;
        private static Texture2D PressingCursor;

        private void Awake()
        {
            IdleCursor = idleCursor;
            HoverCursor = hoverCursor;
            PressingCursor = pressingCursor;
            SetCursor(CursorType.Idle);
        }

        public static void SetCursor(CursorType cursorMode)
        {
            switch(cursorMode)
            {
                case CursorType.Idle:
                    Cursor.SetCursor(IdleCursor, Vector2.zero, CursorMode.Auto);
                    break;

                case CursorType.Hover:
                    Cursor.SetCursor(HoverCursor, Vector2.zero, CursorMode.Auto);
                    break;

                case CursorType.Pressing:
                    Cursor.SetCursor(PressingCursor, Vector2.zero, CursorMode.Auto);
                    break;
            }
        }
    }
    public enum CursorType
    {
        Idle,
        Hover,
        Pressing
    }
}
