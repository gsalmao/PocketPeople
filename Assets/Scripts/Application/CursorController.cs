using UnityEngine;

namespace PocketPeople.Application
{
    public class CursorController : MonoBehaviour
    {
        [SerializeField] private Texture2D idleCursor;
        [SerializeField] private Texture2D hoverCursor;
        [SerializeField] private Texture2D pressingCursor;
        private void Awake()
        {
            Cursor.SetCursor(idleCursor, Vector2.zero, CursorMode.ForceSoftware);
        }
    }
}
