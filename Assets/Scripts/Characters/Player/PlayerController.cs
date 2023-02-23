using PocketPeople.Inputs;
using PocketPeople.Items;
using PocketPeople.Items.UI;
using PocketPeople.UI;
using System.Collections.Generic;
using UnityEngine;

namespace PocketPeople.Characters.Player
{
    /// <summary>
    /// Controls the player and sets the inventory init Items.
    /// </summary>
    public class PlayerController : BaseCharacter
    {
        public static Transform PlayerBody { get; private set; }

        [SerializeField] private List<BaseItem> initItems;
        [SerializeField] private int initMoney;
        
        [Space]

        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Animator animator;
        [SerializeField] private InventoryUI inventoryUI;
        [SerializeField] private GameObject interactionSight;
        [SerializeField] private float speed;

        private MainInput mainInput;
        private Vector3 currentRotation = new Vector3(0f, 0f, 0f);
        private Vector2 moveDirection;
        private float playerRotation;

        private const string Idle = "Idle";
        private const string Walk = "Walk";

        private void Awake()
        {
            PlayerBody = animator.transform;
            PlayerInventory.Initialize(initItems, initMoney);
            mainInput = new MainInput();
            inventoryUI.InitInventoryUI();
            BasicWindow.OnToggleMenu += TogglePlayerController;
            Interactable.OnToggleInteractions += TogglePlayerController;
        }

        private void OnDestroy()
        {
            BasicWindow.OnToggleMenu -= TogglePlayerController;
            Interactable.OnToggleInteractions -= TogglePlayerController;
        }

        private void OnEnable() => mainInput.Enable();
        private void OnDisable() => mainInput.Disable();

        private void TogglePlayerController(bool value)
        {
            rb2d.velocity = Vector2.zero;
            interactionSight.gameObject.SetActive(!value);
            animator.Play(Idle);
            enabled = !value;
        }

        private void FixedUpdate()
        {
            moveDirection = mainInput.Gameplay.Move.ReadValue<Vector2>();
            rb2d.velocity = moveDirection * speed;
        }

        private void Update()
        {
            string animation = moveDirection.magnitude > 0f ? Walk : Idle;
            
            if(moveDirection.x != 0f)
                playerRotation = moveDirection.x > 0f ? 0f : 180f;

            currentRotation.y = playerRotation;

            animator.Play(animation);
            animator.transform.rotation = Quaternion.Euler(currentRotation);
        }

    }
}
