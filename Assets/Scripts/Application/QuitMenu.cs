using PocketPeople.Inputs;
using UnityEngine;
namespace PocketPeople.ApplicationManager
{
    /// <summary>
    /// Simple script to open/close the quit menu.
    /// </summary>
    public class QuitMenu : MonoBehaviour
    {
        [SerializeField] private Animator animator;

        private MainInput mainInput;
        private bool isOpen;

        private void Awake()
        {
            mainInput = new MainInput();
            mainInput.Gameplay.Esc.performed += ctx => ToggleQuitMenu();
        }

        private void OnEnable() => mainInput.Enable();
        private void OnDisable() => mainInput.Disable();

        public void ToggleQuitMenu()
        {
            if (isOpen)
                CloseMenu();
            else
                OpenMenu();

            isOpen = !isOpen;
        }

        public void QuitGame() => Application.Quit();

        private void OpenMenu()
        {
            Time.timeScale = 0f;
            animator.CrossFade("Open", 0.2f);
        }

        private void CloseMenu()
        {
            Time.timeScale = 1f;
            animator.CrossFade("Close", 0.2f);
        }
    }
}
