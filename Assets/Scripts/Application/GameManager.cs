using UnityEngine;

namespace PocketPeople.Application
{
    /// <summary>
    /// Initializes the application.
    /// </summary>
    public class GameManager : MonoBehaviour
    {
        [SerializeField] private bool debugging;

        public static bool Debugging { get; private set; }

        private void Awake()
        {
            Debugging = debugging;
            Cursor.visible = false;
            Screen.SetResolution(1920, 1080, true);
        }

    }
}
