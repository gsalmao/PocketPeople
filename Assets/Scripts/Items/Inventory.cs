using Sirenix.OdinInspector;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;
using System;

namespace PocketPeople.Items
{
    public class Inventory : MonoBehaviour
    {
        public event Action<bool> OnToggleMenu = delegate { };

        [SerializeField, FoldoutGroup("References")] private Transform inventoryContent;
        [SerializeField, FoldoutGroup("References")] private Animator animator;
        [SerializeField, FoldoutGroup("References")] private ItemButton itemButtonPrefab;

        [SerializeField] private List<BaseItem> items;
        [SerializeField] private Equipment equipment;
        [SerializeField] private int money;

        private ObjectPool<ItemButton> buttonsPool;
        private List<ItemButton> buttons;
        private bool isOpening;

        private const string Open = "Open";
        private const string Close = "Close";

        public void InitInventory()
        {
            //Object Pooling
            buttonsPool = new ObjectPool<ItemButton>(
            () => Instantiate(itemButtonPrefab),
            button => button.gameObject.SetActive(true),
            button => button.gameObject.SetActive(false),
            button => Destroy(button), false, 30, 50);

            buttons = new List<ItemButton>();

            foreach(BaseItem item in items)
            {
                ItemButton newButton = buttonsPool.Get();
                newButton.transform.SetParent(inventoryContent);
                newButton.transform.localScale = Vector3.one;
                newButton.SetButton(item);
                buttons.Add(newButton);
            }

            equipment.InitClothes();
        }

        public void ToggleInventory()
        {
            isOpening = !isOpening;
            animator.Play(isOpening ? Open : Close);
            OnToggleMenu(isOpening);
        }
    }
}
