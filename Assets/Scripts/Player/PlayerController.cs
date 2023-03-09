using System.Collections.Generic;
using UnityEngine;
using PocketPeople.Input;
using PocketPeople.Interactables;
using PocketPeople.Items;
using PocketPeople.Items.UI;
using PocketPeople.UI;
using FMODUnity;
using PocketPeople.Items.Data;
using PocketPeople.SpriteSwap;

namespace PocketPeople.Player
{
    /// <summary>
    /// Controls the player and sets the inventory init Items.
    /// </summary>
    public class PlayerController : MonoBehaviour
    {
        public static Transform PlayerBody { get; private set; }

        [SerializeField] private List<EquipmentData> initEquipments;
        [SerializeField] private List<ItemData> initItems;
        [SerializeField] private int initMoney;
        [SerializeField] private EventReference useItemSound;
        [SerializeField] private CharacterSwapper characterSwapper;
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Animator animator;
        [SerializeField] private InventoryUI inventoryUI;
        [SerializeField] private GameObject interactionSight;
        [SerializeField] private float speed;

        
        private PlayerEffects playerEffects;
        private MainInput mainInput;
        private Vector3 currentRotation = new Vector3(0f, 0f, 0f);
        private Vector2 moveDirection;
        private float playerRotation;

        private const string Idle = "Idle";
        private const string Walk = "Walk";

        private void Awake()
        {
            PlayerBody = animator.transform;
            playerEffects = new PlayerEffects();
            playerEffects.Init(characterSwapper);
            Inventory.Init(initItems, initMoney, initEquipments, useItemSound);

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
