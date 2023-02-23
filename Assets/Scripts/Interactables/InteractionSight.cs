using UnityEngine;

namespace PocketPeople.Interactables
{
    /// <summary>
    /// Activates/deactivates interactions. Only interactions near the player are supposed to be interacted with.
    /// </summary>
    public class InteractionSight : MonoBehaviour
    {
        private void OnTriggerEnter2D(Collider2D collision) => collision.GetComponent<Interactable>().IsActive = true;
        private void OnTriggerExit2D(Collider2D collision) => collision.GetComponent<Interactable>().IsActive = false;

    }
}