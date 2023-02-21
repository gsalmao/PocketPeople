using NodeCanvas.Framework;
using UnityEngine;

namespace PocketPeople.UI
{
    /// <summary>
    /// This class holds the button methods from the MainMenu.
    /// </summary>
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] public SignalDefinition mainMenuButtonSignal;

        public void OnNewGame() => mainMenuButtonSignal.Invoke(transform, transform, false, true);
        public void OnQuitGame() => mainMenuButtonSignal.Invoke(transform, transform, false, false);
    }
}
