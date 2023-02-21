using PocketPeople.Inputs;
using UnityEngine;

namespace PocketPeople.Characters.Player
{
    public class PlayerController : BaseCharacter
    {
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Animator animator;
        [SerializeField] private float speed;

        private MainInput mainInput;
        private Vector3 currentRotation = new Vector3(0f, 0f, 0f);
        private Vector2 moveDirection;
        private float playerRotation;

        private void Awake() => mainInput = new MainInput();
        private void OnEnable() => mainInput.Enable();
        private void OnDisable() => mainInput.Disable();

        private void FixedUpdate()
        {
            moveDirection = mainInput.Gameplay.Move.ReadValue<Vector2>();
            rb2d.velocity = moveDirection * speed;
        }

        private void Update()
        {
            string animation = moveDirection.magnitude > 0f ? "Walk" : "Idle";
            
            if(moveDirection.x != 0f)
                playerRotation = moveDirection.x > 0f ? 0f : 180f;

            currentRotation.y = playerRotation;

            animator.Play(animation);
            animator.transform.rotation = Quaternion.Euler(currentRotation);
        }

    }
}
