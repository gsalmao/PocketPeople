using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using PocketPeople.Inputs;
using PocketPeople.Interactables;
using PocketPeople.Items;
using PocketPeople.Items.UI;
using PocketPeople.UI;

namespace PocketPeople.Player
{
    /// <summary>
    /// Controls the player and sets the inventory init Items.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public static Transform PlayerBody { get; private set; }

        [SerializeField, FoldoutGroup("Initialization")] private List<EquipmentData> initEquipments;
        [SerializeField, FoldoutGroup("Initialization")] private List<ItemData> initItems;
        [SerializeField, FoldoutGroup("Initialization")] private int initMoney;

        [Space]

        [SerializeField, FoldoutGroup("References")] private Rigidbody2D rb2d;
        [SerializeField, FoldoutGroup("References")] private Animator animator;
        [SerializeField, FoldoutGroup("References")] private InventoryUI inventoryUI;
        [SerializeField, FoldoutGroup("References")] private GameObject interactionSight;
        [SerializeField, FoldoutGroup("References")] private float speed;

        [SerializeField, HideLabel] private PlayerEffects playerEffects;

        private MainInput mainInput;
        private Vector3 currentRotation = new Vector3(0f, 0f, 0f);
        private Vector2 moveDirection;
        private float playerRotation;

        private const string Idle = "Idle";
        private const string Walk = "Walk";

        private void Awake()
        {
            PlayerBody = animator.transform;
            PlayerInventory.Init(initItems, initMoney, initEquipments);
            playerEffects.Init();

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
