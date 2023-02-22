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

        
        [SerializeField, FoldoutGroup("References")] private Animator animator;
        [SerializeField, FoldoutGroup("References")] private Transform itemButtonPrefab;
        [SerializeField, FoldoutGroup("References")] private ItemMenu itemMenu;
        [SerializeField] private List<BaseItem> items;
        [SerializeField] private Equipment equipment;
        [SerializeField] private int money;

        
        private List<ItemButton> itemButtons;
        private bool isOpening;

        private const string Open = "Open";
        private const string Close = "Close";

        public void InitInventory()
        {
            itemButtons = new List<ItemButton>();
            itemMenu.InitItemMenu(itemButtonPrefab);

            foreach(BaseItem item in items)
            {
                ItemButton newButton = itemMenu.CreateButton().GetComponent<ItemButton>();
                newButton.SetButton(item);
                newButton.SetOnClick(OnClickItem);

                itemButtons.Add(newButton);

            }

            equipment.InitClothes();
        }

        private void OnClickItem(BaseItem item)
        {
            Debug.Log($"Clicked on {item.ItemName}");   //TODO: use item, remove from inventory
        }

        public void ToggleInventory()
        {
            isOpening = !isOpening;

            foreach (ItemButton itemButton in itemButtons)
                itemButton.SetButtonActive(isOpening);

            animator.Play(isOpening ? Open : Close);
            OnToggleMenu(isOpening);
        }
    }
}
