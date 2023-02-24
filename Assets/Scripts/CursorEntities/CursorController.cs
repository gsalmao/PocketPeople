using System.Collections.Generic;
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

        private static Dictionary<CursorType, Texture2D> cursorTextures;

        private void Awake()
        {
            cursorTextures = new Dictionary<CursorType, Texture2D>();
            cursorTextures.Add(CursorType.Idle, idleCursor);
            cursorTextures.Add(CursorType.Hover, hoverCursor);
            cursorTextures.Add(CursorType.Pressing, pressingCursor);
            SetCursor(CursorType.Idle);
        }

        public static void SetCursor(CursorType cursorMode) => Cursor.SetCursor(cursorTextures[cursorMode], Vector2.zero, CursorMode.Auto);

    }
    public enum CursorType
    {
        Idle,
        Hover,
        Pressing
    }
}
